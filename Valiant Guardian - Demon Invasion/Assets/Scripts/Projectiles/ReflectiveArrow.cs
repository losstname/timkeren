using UnityEngine;
using System.Collections;

public class ReflectiveArrow : MonoBehaviour {

    private int countEnemiesHit;
    private string[] enemiesRealName;
    private string enemiesHitName;
    public string targetName;

    void Start()
    {
        countEnemiesHit = 0;
        enemiesHitName = "ReflectiveArrowVictim";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other.gameObject.name == targetName)
        {
            enemiesRealName[countEnemiesHit] = other.gameObject.name;
            other.gameObject.name = enemiesHitName + countEnemiesHit;
            countEnemiesHit++;
            other.gameObject.GetComponent<Enemy>().Attacked();
        }
    }
}