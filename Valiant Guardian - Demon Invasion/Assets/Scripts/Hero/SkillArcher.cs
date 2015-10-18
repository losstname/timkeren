using UnityEngine;
using System.Collections;

public class SkillArcher : MonoBehaviour
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
        //Start normal skill
        //Called from animation
        spawnNormProjectile();
    }

    public void ultimateSkill()
    {
        //make sure the projectile aiming at enemy
        hero.aimAtEnemy();
        spawnUltiProjectile();
    }

    public void spawnNormProjectile()
    {
        //spawning projectile
        GameObject projectile = Instantiate(normProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
        projectile.transform.parent = this.transform;

        //Passing the attack status from hero to projectile
        projectile.GetComponent<ReflectiveArrow>().GetDmgFromHero(hero.GetHeroAttackStat());
    }

    public void spawnUltiProjectile()
    {
        //spawning projectile for ultimate skill
        //called from animation
		GameObject projectile = Instantiate(ultiProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation) as GameObject;
		projectile.transform.parent = this.transform;
        //Instantiate(ultiProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }
}