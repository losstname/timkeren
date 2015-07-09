using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {
	public float DistanceFromHero;
    public float protectionRadius = 10f;
//    public float nearRadius = 3f;
    public float CoolDown = 1;
    public float CoolingDown;
    public float SkillCoolDown = 5f;
    public int SkillBoardNumber;

	public GameObject Enemies;
	public GameObject Projectiles;

    private Transform ProjectilePosTr;
    private Animator anim;
    private int isAttackingHash = Animator.StringToHash("isAttacking");
    private int useSkillHash = Animator.StringToHash("useSkill");
	private int idleStateHash = Animator.StringToHash("Base Layer.Archer-Idle-Anim");

	public static int archerAtk = 100;

	void Awake () {
	}

	void Start () {
        ProjectilePosTr = transform.GetChild(0);
        anim = GetComponent<Animator>();
        CoolingDown = CoolDown;
        //set skill cool down to skillboard
        GameObject.Find("SkillPanel").transform.GetChild(SkillBoardNumber).GetComponent<SkillBtn>().setSkillCoolDown(SkillCoolDown);
	}

	void Update () {
		Enemies = GameObject.FindGameObjectWithTag("Enemy");

		if(Enemies != null)
		{
			DistanceFromHero = Vector3.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position, transform.position);
            if (DistanceFromHero <= protectionRadius/* && DistanceFromHero > blindRadius*/)
            {
                //getting the anim state
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                //if cooldown finished -> fire
                CoolingDown -= Time.deltaTime;
                if (CoolingDown <= 0 && stateInfo.nameHash == idleStateHash)
                {
                    attackEnemy();
                    CoolingDown = CoolDown;
                }
            }
            //else Enemies = null;
		}
	}

	public void attackEnemy () {
        //Set projectile object to look at enemy
        //Projectile object is a child of hero object
        Quaternion direction = Quaternion.LookRotation(Enemies.transform.position - ProjectilePosTr.position, ProjectilePosTr.TransformDirection(Vector3.up));
        ProjectilePosTr.rotation = new Quaternion(0, 0, direction.z, direction.w);

        //change hero animation to attacking animation
        if(anim!=null)
            anim.SetTrigger(isAttackingHash);
        else
            Debug.Log(this.gameObject.name + " Doesn't has Atk animation");
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
            spawnProjectile();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void spawnProjectile()
    {
        //spawning projectile
        //called from animation
        Instantiate(Projectiles, ProjectilePosTr.position, ProjectilePosTr.rotation);
    }
}