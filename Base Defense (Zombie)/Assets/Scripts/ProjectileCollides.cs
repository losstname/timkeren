using UnityEngine;
using System.Collections;

public class ProjectileCollides : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<ProjectileSound>().hitTargetSound();
            other.gameObject.GetComponent<Enemy>().Attacked();
            Destroy(gameObject);
        }
    }
}