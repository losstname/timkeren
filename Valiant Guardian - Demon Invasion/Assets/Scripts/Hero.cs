using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{

    public float DistanceFromHero;
    public float protectionRadius = 10f;
    //    public float nearRadius = 3f;

    public float SkillCoolDown = 5f;
    public int SkillBoardNumber;

    public GameObject Enemies;

    public Transform ProjectilePosTr;
    public Animator anim;

    public float idleTime = 1f;
    public float coolDown;

    public float heroSpeed = 100f;
    private float speedScaleRatio = 100f;   //Speed Scaling ratio is 1:100

    public int isAttackingHash = Animator.StringToHash("isAttacking");
    public int useSkillHash = Animator.StringToHash("useSkill");
    public int idleStateHash = Animator.StringToHash("Base Layer.Archer-Idle-Anim");

    public GameObject Projectiles;

    void Start()
    {
        ProjectilePosTr = transform.GetChild(0);
        anim = GetComponent<Animator>();
        //set skill cool down to skillboard
        GameObject.Find("SkillPanel").transform.GetChild(SkillBoardNumber).GetComponent<SkillBtn>().setSkillCoolDown(SkillCoolDown);
        coolDown = idleTime;
    }

    void Update()
    {
        if (Enemies == null) {
            autoChangeEnemy();
        }
        else {
            DistanceFromHero = Vector3.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position, transform.position);
        }
    }

    public void changeEnemy(GameObject newEnemy)
    {
        Enemies = newEnemy;
    }

    public void autoChangeEnemy()
    {
        Enemies = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void setHeroSpeed(float speed)
    {
        //default anim scale speed is 100
        anim.speed = speed / speedScaleRatio;
        idleTime = idleTime / (speed / speedScaleRatio);
    }

    public void heroSkill()
    {
        if (anim != null)
            anim.SetTrigger(useSkillHash);
        GameObject.Find("SkillPanel").transform.GetChild(SkillBoardNumber).GetComponent<SkillBtn>().resetCoolingDown();
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
            Quaternion direction = Quaternion.LookRotation(Enemies.transform.position - ProjectilePosTr.position, ProjectilePosTr.TransformDirection(Vector3.up));
            ProjectilePosTr.rotation = new Quaternion(0, 0, direction.z, direction.w);
            spawnNormProjectile();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
        Instantiate(Projectiles, ProjectilePosTr.position, ProjectilePosTr.rotation);
    }
}