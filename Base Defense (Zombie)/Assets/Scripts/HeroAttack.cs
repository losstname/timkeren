using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {
	public static HeroAttack instance = null;

	public float DistanceFromCastle,CoolDown;
	public GameObject Enemies;
	public GameObject Projectiles;
	public int protectionRadius,bulletSpeed;

	// Use this for initialization

	void Awake () {
		Projectiles = GameObject.FindGameObjectWithTag ("Projectiles");

	}

	void Start () {
		protectionRadius = 10;
		bulletSpeed = 50;
		CoolDown = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Enemies = GameObject.FindGameObjectWithTag("Enemy");
		
		if(Enemies != null)
		{
			DistanceFromCastle = Vector3.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position,GameObject.FindGameObjectWithTag("Hero").transform.position);
			//print (DistanceFromCastle);
			if(DistanceFromCastle <= protectionRadius)
			{
				attackEnemy();
			}
			
		}
	}


	public void attackEnemy () {
		transform.LookAt(Enemies.transform);
		CoolDown -= Time.deltaTime;
		if (CoolDown <= 0)
		{

			const int SPAWN_DISTANCE = 5;
			Instantiate(Projectiles, transform.position + SPAWN_DISTANCE * transform.forward, transform.rotation);
			if (EnemyMovement.gghp > 1) {
			EnemyMovement.gghp -=1;
			CoolDown = 1;
			} else {
				Destroy(Enemies);
				CoolDown = 1;
			}
		}
	}
}