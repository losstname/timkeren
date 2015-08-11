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
    }

    public void spawnUltiProjectile()
    {
        //spawning projectile for ultimate skill
        //called from animation
        Instantiate(ultiProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }
}