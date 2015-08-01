using UnityEngine;
using System.Collections;

public class ReflectiveArrow : MonoBehaviour {

    public GameObject target;
    HeroSkillTrigger heroSkillTrigger;

    private int countEnemiesHit;
    private string[] enemiesRealName = new string[4];
    public GameObject[] enemiesCaught = new GameObject[4];
    private string markedTargetName;    //All targeted enemies marked by this name

    public float radius;
    public float speed;

    private bool readyLaunch = false;

    public GameObject[] enemiesOnRadius;
    void Start()
    {
        heroSkillTrigger = transform.parent.parent.GetComponent<HeroSkillTrigger>();
        countEnemiesHit = 0;
        markedTargetName = "ReflectiveArrowVictim";
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            setFirstEnemyOnTap();

        //Set the object rotation
        if (target != null)
        {
            Quaternion direction = Quaternion.LookRotation(target.transform.position - this.transform.position, this.transform.TransformDirection(Vector3.up));
            this.transform.rotation = new Quaternion(0, 0, direction.z, direction.w);
        }

        //move projectile towards target
        if (readyLaunch)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    void setFirstEnemyOnTap()
    {
        RaycastHit2D hitObject = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitObject.transform.tag == "Enemy")
        {
            if (Vector2.Distance(transform.position, hitObject.transform.position) <= radius)
            {
                TargetAnEnemy(hitObject.collider);
                readyLaunch = true;
            }
        }
        else
        {
            heroSkillTrigger.HideSkillsHolder();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other.name == markedTargetName)
        {
            //after marked target hit, ASAP find the next target
            FindTargetOnRadius();

            other.gameObject.GetComponent<Enemy>().Attacked();
        }
    }

    void TargetAnEnemy(Collider2D targetCollider)
    {
        //save the reference of the enemies in order
        enemiesCaught[countEnemiesHit] = targetCollider.gameObject;

        //save the name to be refund when the skills finished
        enemiesRealName[countEnemiesHit] = targetCollider.gameObject.name;
        targetCollider.gameObject.name = markedTargetName;

        //set the reference to current targeted enemy
        this.target = enemiesCaught[countEnemiesHit];

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
                if(Vector2.Distance(transform.position, enemiesFound[i].transform.position) <= radius)
                    enemiesOnRadius[enemiesOnRadiusCount++] = enemiesFound[i].gameObject;
            }
        }
        FindNearestTarget();
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
                float newDistance = Vector2.Distance(tempNearestTarget.transform.position, enemiesOnRadius[i].transform.position);
                //if the distance to the enemy closer than the previous distance then save it
                if (newDistance < tempDistance)
                    tempNearestTarget = enemiesOnRadius[i].gameObject;
            }
        }
        TargetAnEnemy(tempNearestTarget.GetComponent<Collider2D>());
    }
}