using UnityEngine;
using System.Collections;

public class ReflectiveArrow : MonoBehaviour {

    private int countEnemiesHit;
    private string[] enemiesRealName;
    private string enemiesHitName;
    public string targetName;

    private CircleCollider2D circleCollider;
    public float enemyDetectionTime = 0.5f;

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    void Start()
    {
        countEnemiesHit = 0;
        enemiesHitName = "ReflectiveArrowVictim";
        circleCollider.enabled = true;                              //Only for testing
        Invoke("DisableDetectionCollider", enemyDetectionTime);     //Only for testing
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other.gameObject.name == targetName)
        {
            enemiesRealName[countEnemiesHit] = other.gameObject.name;
            other.gameObject.name = enemiesHitName + countEnemiesHit;
            countEnemiesHit++;
            other.gameObject.GetComponent<Enemy>().Attacked();
            circleCollider.enabled = true;
            Invoke("DisableDetectionCollider", enemyDetectionTime);
        }

        if (other.tag == "Enemy")
        {

        }
    }

    void DisableDetectionCollider()
    {
        circleCollider.radius = 0.1f;
        circleCollider.enabled = false;
    }
}