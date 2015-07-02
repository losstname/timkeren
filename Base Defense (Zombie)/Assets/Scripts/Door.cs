using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
	public int hitPoints = 10 ;
	private Text levelText;
	public bool attackable = true;
	public bool destroyable = true;

	void Awake()
	{
		levelText = GameObject.Find("BaseHPText").GetComponent<Text>();
		levelText.text = "Base HP: " + hitPoints;
	}
	
	public void AttackBase(){
		if(attackable){
			if(levelText == null)
				levelText = GameObject.Find("BaseHPText").GetComponent<Text>();
			hitPoints--;
			if(hitPoints >0)
				levelText.text = "Base HP:  " + hitPoints;
			else{
				levelText.text = "You Lose ";
				if(destroyable){
					gameObject.SetActive(false);
					GameController gameCtrl = GameObject.FindObjectOfType<GameController>();
					gameCtrl.StopAllCoroutines();
				}
			}
		}
	}
}

