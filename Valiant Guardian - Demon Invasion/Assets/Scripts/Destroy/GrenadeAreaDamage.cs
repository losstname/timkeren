using UnityEngine;
using System.Collections;

public class GrenadeAreaDamage : MonoBehaviour
{
	public bool destroyOnFirstEnemy;
	public string enemyName;
	void Start()
	{
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" && other.name=="markedBullseye")
		{
			other.name="enemyBullseye";
			other.GetComponent<Enemy>().AttackedV2();
			if(destroyOnFirstEnemy)
			{
				GetComponent<CircleCollider2D>().enabled = false;
			}
		}
	}

}