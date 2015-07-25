using UnityEngine;
using System.Collections;
//Put on the hero
public class Hero : MonoBehaviour
{

    public float DistanceFromHero;
    public float protectionRadius = 10f;
    //public float nearRadius = 3f;

    public float normSkillCoolDown = 5f;
    public float ultiSkillCooldown = 20f;
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
    public int useUltiSkillHash = Animator.StringToHash("useUltiSkill");
    public int idleStateHash = Animator.StringToHash("Base Layer.Archer-Idle-Anim");

    void Start()
    {
        ProjectilePosTr = transform.GetChild(0);
        anim = GetComponent<Animator>();
        //set skill cool down to skill trigger
        GetComponent<HeroSkillTrigger>().setNormalSkillCoolDown(normSkillCoolDown);
        GetComponent<HeroSkillTrigger>().setUltimateSkillCoolDown(ultiSkillCooldown);
        //GameObject.Find("SkillPanel").transform.GetChild(SkillBoardNumber).GetComponent<SkillBtn>().setNormSkillCoolDown(normSkillCoolDown);
        //GameObject.Find("SkillPanel").transform.GetChild(SkillBoardNumber).GetComponent<SkillBtn>().setUltiSkillCoolDown(ultiSkillCooldown);
        coolDown = idleTime;
    }

    void Update()
    {
        if (Enemies == null) {
            autoChangeEnemy();
        }
        else if(Enemies != null) {
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
}