using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {
	public static HeroAttack instance = null;

	public float DistanceFromHero;
    public int protectionRadius = 10;
    public float CoolDown = 1;
	public GameObject Enemies;
	public GameObject Projectiles;
    //public int bulletSpeed;

	// Use this for initialization

	void Awake () {
		//Projectiles = GameObject.FindGameObjectWithTag ("Projectiles");
	}

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Enemies = GameObject.FindGameObjectWithTag("Enemy");

		if(Enemies != null)
		{
			DistanceFromHero = Vector3.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position, transform.position);
			//print (DistanceFromCastle);
			if(DistanceFromHero <= protectionRadius)
			{
				attackEnemy();
			}

		}
	}


	public void attackEnemy () {
        //Set projectile to look at enemy
        Quaternion direction = Quaternion.LookRotation(Enemies.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, direction.z, direction.w);

        //if cooldown finished -> fire
		CoolDown -= Time.deltaTime;
		if (CoolDown <= 0)
		{
            Instantiate(Projectiles, transform.position, transform.rotation);
            CoolDown = 1;
		}
	}
}