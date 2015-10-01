using UnityEngine;
using System.Collections;

public class SkillSniper : MonoBehaviour
{

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;
	public GameObject ultiProjectilesV2;
	public Vector3 arah2;
    private Hero hero;
	float height;

	
	Vector3 startJumpPoint;
	Vector3 endPoint;

	bool isJump;
	bool isRoll;
	bool isBack;

	void Update()
	{
		if (isJump) {
			startJumpPoint = new Vector3(startJumpPoint.x+(5f*Time.deltaTime),startJumpPoint.y+(height*Time.deltaTime),0);
			transform.parent.transform.position = startJumpPoint;
		}
		if(isRoll)
		{
			startJumpPoint = new Vector3(startJumpPoint.x+(0.1f*Time.deltaTime),startJumpPoint.y-(3*Time.deltaTime),0);
			transform.parent.transform.position = startJumpPoint;
			if(startJumpPoint.y < arah2.y)
			{
				StopRoll();
			}
		}
		if (isBack) 
		{
			transform.parent.transform.localPosition = Vector3.zero;
			this.GetComponent<Animator> ().SetBool ("jumpReach",false);
			isBack = false;
			/*
			transform.parent.transform.localPosition = new Vector3(transform.parent.transform.localPosition.x-(4f*Time.deltaTime),Mathf.Lerp(transform.parent.transform.localPosition.y,0,Time.deltaTime),0);

			// = Vector3.Lerp(transform.parent.transform.localPosition,Vector3.zero,Time.deltaTime);
			if(transform.parent.transform.localPosition.x <0.01f)
			{
				transform.parent.transform.localPosition = Vector3.zero;
				this.GetComponent<Animator> ().SetBool ("jumpReach",false);
				isBack = false;
			}
			*/
		}
	}

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void normalSkill()
    {
        //StartCoroutine(bulletBurst());
		spawnNormProjectile();
    }

    IEnumerator bulletBurst()
    {
        for (int i = 0; i < 3; i++)
        {
            //make sure the projectile aiming at enemy
            hero.aimAtEnemy();
            spawnNormProjectile();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ultimateSkill()
    {
        //make sure the projectile aiming at enemy
        hero.aimAtEnemy();
        spawnUltiProjectile();
    }

    public void spawnUltiProjectile()
    {
        //spawning projectile for ultimate skill
        //called from animation
		GameObject projectile = Instantiate(ultiProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		gameObject.GetComponentInParent<HeroSkillTrigger> ().PauseHeroAnimation ();
		

		projectile.transform.parent = this.transform;
	}

	public void spawnUltiProjectileV2()
	{
		//spawning projectile for ultimate skill
		//called from animation
		GameObject projectile = Instantiate(ultiProjectilesV2, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		//projectile.transform.parent = this.transform;

		//Quaternion direction = Quaternion.RotateTowards(projectile.transform.rotation,ara)  //Quaternion.LookRotation(projectile.transform.forward, projectile.transform.TransformDirection(Vector3.up));

		//set the laser direction
		//Vector3 targetDir = arah2 - transform.position;
		//float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		projectile.transform.rotation = Quaternion.identity;
		//projectile.GetComponent<Transform> ().rotation = new Quaternion(0, 0, direction.z, direction.w);
	}

	public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
		GameObject projectile = Instantiate(normProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		projectile.transform.parent = this.transform;
    }

	public void jump()
	{
		height = arah2.y - transform.parent.transform.position.y;
		if (height < 0) {
			height =2;
		} 
		else {
			height = height + 4f;
		}
		startJumpPoint = transform.parent.transform.position;
		endPoint = new Vector3 (transform.parent.transform.position.x+2, transform.parent.transform.position.y-4, 0);
		isJump = true;
	}

	public void stopJump()
	{
		isJump = false;
	}

	public void Roll()
	{
		isRoll = true;
		this.GetComponent<Animator> ().SetBool ("jumpReach",true);
	}

	public void StopRoll()
	{
		isRoll = false;

	}
	public void back()
	{
		//endPoint = transform.parent.transform.parent.transform.position;
		isBack = true;
	}

}