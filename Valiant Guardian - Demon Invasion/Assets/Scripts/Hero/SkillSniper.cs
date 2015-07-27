using UnityEngine;
using System.Collections;

public class SkillSniper : MonoBehaviour {

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;

    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void normalSkill()
    {
        StartCoroutine(bulletBurst());
    }

    IEnumerator bulletBurst()
    {
        for (int i = 0; i < 3; i++)
        {
            //Set projectile object to look at enemy
            //Projectile object is a child of hero object
            Quaternion direction = Quaternion.LookRotation(hero.Enemies.transform.position - hero.ProjectilePosTr.position, hero.ProjectilePosTr.TransformDirection(Vector3.up));
            hero.ProjectilePosTr.rotation = new Quaternion(0, 0, direction.z, direction.w);
            spawnNormProjectile();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ultimateSkill()
    {
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
        Instantiate(normProjectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }
}