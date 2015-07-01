using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {
	public float DistanceFromHero;
    public int protectionRadius = 10;
    public float CoolDown = 1;
    public float CoolingDown;
	public GameObject Enemies;
	public GameObject Projectiles;

    private Transform ProjectilePosTr;
    private Animator anim;
    private int isAttackingHash = Animator.StringToHash("isAttacking");

	void Awake () {
	}

	void Start () {
        ProjectilePosTr = transform.GetChild(0);
        anim = GetComponent<Animator>();
        CoolingDown = CoolDown;
	}

	void Update () {
		Enemies = GameObject.FindGameObjectWithTag("Enemy");

		if(Enemies != null)
		{
			DistanceFromHero = Vector3.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position, transform.position);
			if(DistanceFromHero <= protectionRadius)
			{
				attackEnemy();
			}
		}
	}

	public void attackEnemy () {
        //Set projectile object to look at enemy
        //Projectile object is a child of hero object
        Quaternion direction = Quaternion.LookRotation(Enemies.transform.position - ProjectilePosTr.position, ProjectilePosTr.TransformDirection(Vector3.up));
        ProjectilePosTr.rotation = new Quaternion(0, 0, direction.z, direction.w);

        //if cooldown finished -> fire
		CoolingDown -= Time.deltaTime;
		if (CoolingDown <= 0)
		{
            //change hero animation to attacking animation
            if(anim!=null) anim.SetTrigger(isAttackingHash);
            //spawning projectile
            Instantiate(Projectiles, ProjectilePosTr.position, ProjectilePosTr.rotation);
            CoolingDown = CoolDown;
		}
	}
}