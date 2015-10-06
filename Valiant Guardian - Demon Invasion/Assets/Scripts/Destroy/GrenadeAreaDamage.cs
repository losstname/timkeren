using UnityEngine;
using System.Collections;

public class GrenadeAreaDamage : MonoBehaviour
{

	void Start()
	{
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			//damage * 2
			other.GetComponent<Enemy>().AttackedV2();
		}
	}

}