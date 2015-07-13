using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour
{

    public GameObject Projectiles;

    public static int archerAtk = 100;

    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    void Update()
    {
        if (hero.DistanceFromHero <= hero.protectionRadius)
        {
            //getting the anim state
            AnimatorStateInfo stateInfo = hero.anim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.nameHash == hero.idleStateHash)
            {
                //if cooldown finished -> fire
                hero.coolDown -= Time.deltaTime;
            }
            //if cool down finish then attack the enemy
            if (hero.coolDown <= 0)
            {
                attackEnemy();
                hero.coolDown = hero.idleTime;
            }
        }
    }

    public void attackEnemy()
    {
        //Set projectile object to look at enemy
        //Projectile object is a child of hero object
        Quaternion direction = Quaternion.LookRotation(hero.Enemies.transform.position - hero.ProjectilePosTr.position, hero.ProjectilePosTr.TransformDirection(Vector3.up));
        hero.ProjectilePosTr.rotation = new Quaternion(0, 0, direction.z, direction.w);

        //change hero animation to attacking animation
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.isAttackingHash);
        else
            Debug.Log(this.gameObject.name + " Doesn't has Atk animation");
    }

    public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
        Instantiate(Projectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }
}