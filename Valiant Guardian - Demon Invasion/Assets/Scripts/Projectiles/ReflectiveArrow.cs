using UnityEngine;
using System.Collections;

public class ReflectiveArrow : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public GameObject target;
    HeroSkillTrigger heroSkillTrigger;

    public int enemyHitLimit = 4;
    private int countEnemiesTargeted;
    private string[] enemiesRealName;
    public GameObject[] enemiesCaught;
    private string markedTargetName;    //All targeted enemies marked by this name
    private int countEnemiesHit;

    public float radius;
    public float speed;

    private bool isFindingTarget = false;
    private bool projectileVisible = false;

    public GameObject soundHitGO;
    public AudioClip soundHit;

    public GameObject[] enemiesOnRadius;
    void Start()
    {
        //To mark the arrow not visible before launch
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        enemiesRealName = new string[enemyHitLimit];
        enemiesCaught = new GameObject[enemyHitLimit];

        heroSkillTrigger = transform.parent.GetComponent<HeroSkillTrigger>();
        countEnemiesTargeted = 0;
        countEnemiesHit = 0;
        markedTargetName = "ReflectiveArrowVictim";
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isFindingTarget)
            setFirstEnemyOnTap();

        //Set the object rotation
        if (target != null)
        {
            Quaternion direction = Quaternion.LookRotation(target.transform.position - this.transform.position, this.transform.TransformDirection(Vector3.up));
            this.transform.rotation = new Quaternion(0, 0, direction.z, direction.w);
        }

        //move projectile towards target
        if (isFindingTarget && target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    void setFirstEnemyOnTap()
    {
        RaycastHit2D hitObject = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitObject.transform.tag == "Enemy" && Vector2.Distance(transform.position, hitObject.transform.position) <= radius)
        {
            TargetAnEnemy(hitObject.collider);
            isFindingTarget = true;

            //To re enable the sprite renderer when the projectile launched
            spriteRenderer.enabled = true;

            //To continue the attacking animation
            heroSkillTrigger.ResumeHeroAnimation();

            //To play the sfx
            GetComponent<AudioSource>().Play();
        }
		//the skill must target the enemy!
		//not the enemy? then return!
		else if(hitObject.transform.tag != "Enemy")
		{
			return;
		}
        else
        {
            //To hide the skills button after clicking
            //heroSkillTrigger.HideSkillsHolder();
            heroSkillTrigger.ResumeHeroAnimation();
            heroSkillTrigger.RestartHeroAnimation();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other.name == markedTargetName)
        {
            //after marked target hit, ASAP find the next target
            //but remember if it is still look for next enemy
            if (isFindingTarget)
                FindTargetOnRadius();

            other.gameObject.GetComponent<Enemy>().AttackedV2();

            //Instantiate the object holding the audio source
            GameObject tmpSound = Instantiate(soundHitGO, this.transform.position, Quaternion.identity) as GameObject;
            tmpSound.GetComponent<AudioSource>().clip = soundHit;
            tmpSound.GetComponent<AudioSource>().Play();

            //Stop the projecetile to look for next enemy when hit the last enemy
            if (countEnemiesHit == enemyHitLimit)
            {
                isFindingTarget = false;
                RefundEnemiesName();

                Destroy(this.gameObject);
            }
        }
    }

    void TargetAnEnemy(Collider2D targetCollider)
    {
        //save the reference of the enemies in order
        enemiesCaught[countEnemiesTargeted] = targetCollider.gameObject;

        //save the name to be refund when the skills finished
        enemiesRealName[countEnemiesTargeted] = targetCollider.gameObject.name;
        targetCollider.gameObject.name = markedTargetName;

        //set the reference to current targeted enemy
        this.target = enemiesCaught[countEnemiesTargeted];

        countEnemiesTargeted++;
        countEnemiesHit++;
    }

    void TargetPreviousEnemy()
    {
        int tmpRandomTarget = Random.Range(0, countEnemiesTargeted);
        countEnemiesHit++;
    }

    //clasify off all enemies in the field to target in range of projectile
    void FindTargetOnRadius()
    {
        GameObject[] enemiesFound = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesOnRadius = new GameObject[enemiesFound.Length];
        int enemiesOnRadiusCount = 0;

        for (int i = 0; i < enemiesFound.Length; i++)
        {
            if (enemiesFound[i].name != markedTargetName)
            {
                if (Vector2.Distance(transform.position, enemiesFound[i].transform.position) <= radius)
                    enemiesOnRadius[enemiesOnRadiusCount++] = enemiesFound[i].gameObject;
            }
        }
        if (enemiesOnRadiusCount == 0)
        {
            TargetPreviousEnemy();
        }
        else
        {
            FindNearestTarget();
        }
    }

    //find the nearest target after clasified by FindTargetOnRadius() method
    void FindNearestTarget()
    {
        //temp variabel to be replace by nearest enemy found through looping
        GameObject tempNearestTarget = gameObject;

        //to make sure event the fartest enemy in radius got a chance
        float tempDistance = radius + 0.1f;

        for (int i = 0; i < enemiesOnRadius.Length; i++)
        {
            if (enemiesOnRadius[i] == null)     //because array is longer than it should
                continue;
            else
            {
                float newDistance = Vector2.Distance(transform.position, enemiesOnRadius[i].transform.position);
                //if the distance to the enemy closer than the previous distance then save it
                if (newDistance < tempDistance)
                {
                    tempNearestTarget = enemiesOnRadius[i].gameObject;
                    tempDistance = newDistance;
                }
            }
        }
        TargetAnEnemy(tempNearestTarget.GetComponent<Collider2D>());
    }

    void RefundEnemiesName()
    {
        //return the name
        for (int i = 0; i < enemiesCaught.Length; i++)
        {
            if (enemiesCaught[i] == null)
                continue;
            else
                enemiesCaught[i].name = enemiesRealName[i];
        }
    }
}