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
			other.GetComponent<Enemy>().Slow(3);
		}
	}

	void poisonAttacked()
	{
		// check enemy in circle area
		Collider2D[] col = Physics2D.OverlapCircleAll (transform.position, GetComponent<CircleCollider2D> ().radius);
		for(int i =0 ;i<col.Length;i++)
		{
			if(!col[i].GetComponent<Enemy>())
			{
				return;
			}
			col[i].GetComponent<Enemy>().AttackedV3();
			col[i].GetComponent<Enemy>().isPoisoned=true;
		}
	}
}