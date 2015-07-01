using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed = 1f;
//    private bool ableMove = true;
	private Transform targetBase;
	public Transform sightStart, sightEnd;
	private bool moveToDoor = false;
	public int hitPoints = 3;

	void Start(){
		targetBase = GameObject.FindGameObjectWithTag ("Base").transform;
	}

	void Update () {
//		if(ableMove){
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
//		}
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Base"){
			other.gameObject.GetComponent<Door>().AttackBase();
			Destroy(gameObject);
		}
    }

	public void Attacked(){
		hitPoints--;
	}
}