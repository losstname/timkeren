using UnityEngine;
using System.Collections;

public class SkillArcher : MonoBehaviour {

    public GameObject Projectiles;

    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void heroSkill()
    {
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.useSkillHash);
        GameObject.Find("SkillPanel").transform.GetChild(hero.SkillBoardNumber).GetComponent<SkillBtn>().resetCoolingDown();
    }

    public void skillArcher()
    {
        StartCoroutine(rapidArrow());
    }

    IEnumerator rapidArrow()
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

    public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
        Instantiate(Projectiles, hero.ProjectilePosTr.position, hero.ProjectilePosTr.rotation);
    }
}