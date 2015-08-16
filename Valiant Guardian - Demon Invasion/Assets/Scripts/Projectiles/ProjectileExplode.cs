using UnityEngine;
using System.Collections;

public class ProjectileExplode : MonoBehaviour
{

    public GameObject explosion;
	public float stunDelay;
	public int damage;
	public int radius;
	float tempTime;
	Vector3 temp2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //instantiate the explosion
			Invoke("spawnExplossionEffect",stunDelay);
			//tempTime=stunDelay;
			//spawnExplossionEffect();
			temp2 = other.gameObject.GetComponent<Transform>().position;
            //Instantiate(explosion, transform.position, transform.rotation);
            //Projectile hit enemy
            disableProjectileVisulization();
            GetComponent<ProjectileSound>().hitTargetSound();
			other.gameObject.GetComponent<Enemy>().Stun(stunDelay,damage);
            //float waitToDestroy = GetComponent<ProjectileSound>().getSoundClipLength();
            //Destroy(gameObject, waitToDestroy);
        }
    }
	void Update()
	{
		/*
		if (tempTime > 0) {
			tempTime-=Time.deltaTime;
			if(tempTime<0)
			{
				spawnExplossionEffect();
			}
		}
		*/
	}
	void spawnExplossionEffect()
	{
		GameObject temp = (GameObject) Instantiate(explosion, temp2, transform.rotation);
		temp.GetComponent<Transform> ().localScale = new Vector3 (radius, radius, 1);
		temp.GetComponent<Animator> ().Play ("FadeIn");
		Destroy(gameObject);
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
