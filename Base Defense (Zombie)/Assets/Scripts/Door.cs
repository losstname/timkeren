using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
	public int hitPoints = 5000 ;
	public int hpPlayer = 5 ;
	private Text gateHp;
	private Text playerHp;
	private GameObject doorObject;
	public bool attackable = true;
	public bool destroyable = true;

	void Awake()
	{
		gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
		gateHp.text = "Gate HP: " + hitPoints;
		playerHp = GameObject.Find("PlayerHPText").GetComponent<Text>();
		playerHp.text = "Player HP: " + hpPlayer;		
		doorObject = GameObject.FindGameObjectWithTag("Base");
	}
	
	public void AttackBase(){
		if(attackable){
			if(gateHp == null)
				gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
			hitPoints -= 10;
			if(hitPoints >0)
				gateHp.text = "Gate HP:  " + hitPoints;
			else{
				gateHp.text = "Gate Broken";
				if(destroyable){
					attackable = false;
					GameController gameCtrl = GameObject.FindObjectOfType<GameController>();
					gameCtrl.StopAllCoroutines();
					doorObject.SetActive(false);
				}
			}
		}else{
			hpPlayer--;
			playerHp.text = "Player HP: " + hpPlayer;
			if(hpPlayer <=0){
				playerHp.text = "You Loseee";
				Time.timeScale = 0;
			}
		}
	}

	public bool isAttackAble(){
		Debug.Log("Hitpoints "+ hpPlayer);
		return hpPlayer > 0 ;
	}
}

