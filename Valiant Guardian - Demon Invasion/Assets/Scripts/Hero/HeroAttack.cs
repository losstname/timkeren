using UnityEngine;
using System.Collections;
//Put on the hero
public class HeroAttack : MonoBehaviour
{

    public GameObject Projectiles;

    public static int archerAtk = 100;

    private Hero hero;

    private bool ableAttack = true;
    void Awake() {
        hero = GetComponent<Hero>();
    }

    void Update()
    {
        if (hero.DistanceFromHero <= hero.protectionRadius && hero.Enemies != null)
        {
            //getting the anim state
            AnimatorStateInfo stateInfo = hero.anim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.nameHash == hero.idleStateHash)
            {
                //if cooldown finished -> fire
                hero.coolDown -= Time.deltaTime;
            }
            //if cool down finish then attack the enemy
            if (hero.coolDown <= 0 && ableAttack)
            {
                attackEnemy();
                hero.coolDown = hero.idleTime;
            }
        }
    }

    public void attackEnemy()
    {
        //change hero animation to attacking animation
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.isAttackingHash);
        else
            Debug.Log(this.gameObject.name + " Doesn't has Atk animation");
    }

    public void spawnProjectile()
    {
        //make sure the projectile aiming at enemy
        hero.aimAtEnemy();
        //spawning projectile
        //called from animation
        Instantiate(Projectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }

    public void setHeroAttackCapability(bool capability)
    {
        ableAttack = capability;
    }
}