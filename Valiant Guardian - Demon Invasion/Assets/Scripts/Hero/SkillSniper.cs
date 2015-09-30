using UnityEngine;
using System.Collections;

public class SkillSniper : MonoBehaviour
{

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;
	public GameObject ultiProjectilesV2;
	public Vector3 arah2;

    private Hero hero;

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
		Vector3 targetDir = arah2 - transform.position;
		float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//projectile.GetComponent<Transform> ().rotation = new Quaternion(0, 0, direction.z, direction.w);
	}

	public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
		GameObject projectile = Instantiate(normProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		projectile.transform.parent = this.transform;
    }


}