using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 1f;
    private bool ableMove = true;
	private Transform targetBase;

	void Start(){
			targetBase = GameObject.FindGameObjectWithTag ("Base").transform;
	}

	// Update is called once per frame
	void Update () {
		if(ableMove){
			//            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
			float step = Time.deltaTime * speed;
			transform.position = Vector3.MoveTowards(transform.position, targetBase.position, step);
		}
	}

    void OnTriggerEnter2D(Collider2D other) {
//		ableMove = false;
		if(other.tag == "Base"){
			GameManager.instance.AttackBase();
			Destroy(gameObject);
		}
    }
}
