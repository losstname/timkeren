using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public int hitPoints ;
	private Text levelText;
	private Text attackText;
	private Text destroyText;
	private GameObject baseDoor;
	public bool attackable = false;
	public bool destroyable = false;

	void Awake()
	{
		if (instance == null)

		//if not, set instance to this
		instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

		//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
		Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		//DontDestroyOnLoad(gameObject);
		InitGame();
	}

	void InitGame()
	{
		hitPoints = 10;
		attackable = true;
		destroyable = true;
		levelText = GameObject.Find("BaseHPText").GetComponent<Text>();
		baseDoor = GameObject.Find("Door");
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
					baseDoor.SetActive(false);
				}
			}
		}
	}

	public void restartScene(){
		InitGame();
	}
}