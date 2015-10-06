using UnityEngine;
using System.Collections;

public class SkillSniper : MonoBehaviour
{

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;
	public GameObject ultiProjectilesV2;
	public Vector3 dir;
    private Hero hero;
	float height;

	
	Vector3 startJumpPoint;
	Vector3 endPoint;

	bool isJump;
	bool isRoll;
	bool isBack;


	/// <summary>
	/// This update is purely made for skill fullpressure
	/// fullpressure consist of 4 step: jump -> roll -> attack -> back
	/// in this cs, only 3 that will validate, that is jump, roll and back
	/// for the attack, you can see Fullpressure.cs
	/// </summary>
	void Update()
	{
		//set the position for sniper to jump
		if (isJump) {
			startJumpPoint = new Vector3(startJumpPoint.x+(5f*Time.deltaTime),startJumpPoint.y+(height*Time.deltaTime),0);
			transform.parent.transform.position = startJumpPoint;
		}
		//set how long the sniper will roll
		if(isRoll)
		{
			startJumpPoint = new Vector3(startJumpPoint.x+(0.1f*Time.deltaTime),startJumpPoint.y-(3*Time.deltaTime),0);
			transform.parent.transform.position = startJumpPoint;
			//oh no, the height range of jumping point is already lower the player tap?
			//then why you still roll!? stop it!
			if(startJumpPoint.y < dir.y)
			{
				StopRoll();
			}
		}
		//set the sniper to back to normal position
		if (isBack) 
		{
			//Vector3.zero -> back to 0,0,0 -> back to normal position
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

	/// <summary>
	/// Spawn the projectile where the projectile is only an animation
	/// </summary>
	public void spawnUltiProjectileV2()
	{
		//spawning projectile for ultimate skill
		//called from animation
		GameObject projectile = Instantiate(ultiProjectilesV2, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		//projectile.transform.parent = this.transform;

		//Quaternion direction = Quaternion.RotateTowards(projectile.transform.rotation,ara)  //Quaternion.LookRotation(projectile.transform.forward, projectile.transform.TransformDirection(Vector3.up));

		//set the laser direction
		//Vector3 targetDir = dir - transform.position;
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

	/// <summary>
	/// for skill fullpresure, where the sniper will jump to certain position
	/// </summary>
	public void jump()
	{
		height = dir.y - transform.parent.transform.position.y;
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

	/// <summary>
	/// Stops the jump for fullpressure.
	/// </summary>
	public void stopJump()
	{
		isJump = false;
	}

	/// <summary>
	/// for skill fullpresure, where the sniper will roll to certain position
	/// </summary>
	public void Roll()
	{
		isRoll = true;
		this.GetComponent<Animator> ().SetBool ("jumpReach",true);
	}

	/// <summary>
	/// Stops the roll for fullpressure.
	/// </summary>
	public void StopRoll()
	{
		isRoll = false;

	}

	/// <summary>
	/// for skill fullpressure, where the sniper will back to the normal position
	/// </summary>
	public void back()
	{
		//endPoint = transform.parent.transform.parent.transform.position;
		isBack = true;
	}

}