using UnityEngine;
using System.Collections;

public class GassyFlashBangDamage : MonoBehaviour
{
	void Start()
	{
		// every 3 second do poison attacked
		for(int i=1; i<=3; i++)
		{
			Invoke ("poisonAttacked", i);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			//the enemy will slow for 3 seconds
			other.GetComponent<Enemy>().Slow(3);
		}
	}

	/// <summary>
	/// do the poison attack
	/// </summary>
	void poisonAttacked()
	{
		// check enemy in circle area
		Collider2D[] col = Physics2D.OverlapCircleAll (transform.position, GetComponent<CircleCollider2D> ().radius);
		for(int i =0 ;i<col.Length;i++)
		{
			//no enemy? return
			if(!col[i].GetComponent<Enemy>())
			{
				return;
			}
			//damage * 0.4
			col[i].GetComponent<Enemy>().AttackedV3();
			col[i].GetComponent<Enemy>().isPoisoned=true;
		}
	}
}