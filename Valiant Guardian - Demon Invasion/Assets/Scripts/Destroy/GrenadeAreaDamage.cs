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
			other.GetComponent<Enemy>().AttackedV2();
		}
	}

}