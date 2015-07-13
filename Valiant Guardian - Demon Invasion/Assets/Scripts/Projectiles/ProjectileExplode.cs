using UnityEngine;
using System.Collections;

public class ProjectileExplode : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //instantiate the explosion
            Instantiate(explosion, transform.position, transform.rotation);
            //Projectile hit enemy
            disableProjectileVisulization();
            GetComponent<ProjectileSound>().hitTargetSound();
            float waitToDestroy = GetComponent<ProjectileSound>().getSoundClipLength();
            Destroy(gameObject, waitToDestroy);
        }
    }

    private void disableProjectileVisulization()
    {
        //disabling projectile existence to maintain hit sound
        //while the proectile didn't affect anything in game world
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
    }
}
