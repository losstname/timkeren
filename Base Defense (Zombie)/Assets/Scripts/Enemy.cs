using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed = 1f;
    //private bool ableMove = true;
	private Transform targetBase;
	public Transform sightStart, sightEnd;
	private bool moveToDoor = false;

    public float CoolDown = 2f;
	public int hitPoints = 10;

    private Animator anim;
    private int isAttackingHash = Animator.StringToHash("isAttacking");

    //initialize when enemy touch the gate
    private GameObject Base;

	void Start(){
		targetBase = GameObject.FindGameObjectWithTag ("Base").transform;
        anim = GetComponent<Animator>();
	}

	void Update () {
		if(ScriptableObject.FindObjectOfType<Door>().isAttackAble()){
			float step = Time.deltaTime * speed;
			//use LineCast to see if enemy get contact to invisWall
			//if got contact to invisWall LayerMask then enemy will move to door instead move toward left
			moveToDoor = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("InvisWall"));
			//un-Comment debug below to see LineCast on Enemy
			//Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
			if(moveToDoor){
				//un-Comment debug below to see if Enemy will move to door
				//Debug.Log("Enemy Move to Door");
				transform.position = Vector3.MoveTowards(transform.position, targetBase.position, step);
			}else{
				gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
			}
		}
        if (hitPoints <= 0)
        {
			Coin coin = GameObject.FindObjectOfType<Coin>();
			coin.addCoin();
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Base"){
            Base = other.gameObject;
            StartCoroutine(AttackingBase());
		}
    }

    IEnumerator AttackingBase()
    {
		while (ScriptableObject.FindObjectOfType<Door>().isAttackAble())
        {
            //set animation to attacking base
            anim.SetTrigger(isAttackingHash);
            yield return new WaitForSeconds(CoolDown);
        }
    }

    public void BaseAttacked()
    {
		if(ScriptableObject.FindObjectOfType<Door>().isAttackAble())
				ScriptableObject.FindObjectOfType<Door>().AttackBase();
    }

	public void Attacked(){
		hitPoints--;
	}
}