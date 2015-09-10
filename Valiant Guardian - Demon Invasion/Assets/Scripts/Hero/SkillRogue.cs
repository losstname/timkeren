using UnityEngine;
using System.Collections;

public class SkillRogue : MonoBehaviour
{

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;

    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void normalSkill()
    {
        //StartCoroutine(bulletBurst());
		//hero.aimAtEnemy ();
		spawnNormProjectile ();
    }

    IEnumerator bulletBurst()
    {
        for (int i = 0; i < 5; i++)
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
		 Instantiate(ultiProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }

    public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
		GameObject projectile = (GameObject)Instantiate(normProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
		projectile.transform.parent = this.transform;
    }
}