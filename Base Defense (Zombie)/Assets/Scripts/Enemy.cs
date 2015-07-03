using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed = 1f;
    private bool ableMove = true;
	private Transform targetBase;
	public Transform sightStart, sightEnd;
	private bool moveToDoor = false;

    public float CoolDown = 2f;
	public int hitPoints = 10;

    private Animator anim;
    private int isDeadHash = Animator.StringToHash("isDead");
    private int isAttackingHash = Animator.StringToHash("isAttacking");

	void Start(){
		targetBase = GameObject.FindGameObjectWithTag ("Base").transform;
        anim = GetComponent<Animator>();
	}

	void Update () {
		if(ableMove){
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
//				ableMove = transform.position != targetBase.position;
			}else{
				gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
			}
		}
	}

    void Death()
    {
        //make the enemy to stop moving
        ableMove = false;
        //let the projectile get through
        GetComponent<BoxCollider2D>().enabled = false;
        //untagged this enemy
        gameObject.tag = "DeadEnemy";
        //add coin
        Coin coin = GameObject.FindObjectOfType<Coin>();
        coin.addCoin();
        anim.SetTrigger(isDeadHash);
        //Destory dead enemy after 2s
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Base"){
            StartCoroutine(AttackingBase());
		}
    }

    IEnumerator AttackingBase()
    {
		while (true)
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
        if (hitPoints <= 0)
        {
            Death();
        }
	}
}