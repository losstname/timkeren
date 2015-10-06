using UnityEngine;
using System.Collections;

public class BullseyeLaserDamage : MonoBehaviour
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
			//change enemy name
			other.name="enemyBullseye";
			//damage * 2
			other.GetComponent<Enemy>().AttackedV2();
			//if the enemy already dead when skill activate
			if(destroyOnFirstEnemy)
			{
				//no collider, projectile can attack the enemy behind them
				GetComponent<CircleCollider2D>().enabled = false;
			}
		}
	}
	
}