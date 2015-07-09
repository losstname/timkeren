using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
	private Text playerHp;
	public int hpPlayer = 5 ;

	void Awake(){
		playerHp = GameObject.Find("PlayerHPText").GetComponent<Text>();
		playerHp.text = "Player HP: " + hpPlayer;
	}

	public void AttackPlayer(){		
		hpPlayer--;
		playerHp.text = "Player HP: " + hpPlayer;
		if(hpPlayer <=0){
			playerHp.text = "You Loseee";
			Time.timeScale = 0;
		}
	}

	public bool isAttackAble(){
		return hpPlayer > 0 ;
	}

	public void PlayerWin ()
	{
		playerHp = GameObject.Find("PlayerHPText").GetComponent<Text>();
		playerHp.text = "You Wiiiin";
		Time.timeScale = 0;
	}
}

