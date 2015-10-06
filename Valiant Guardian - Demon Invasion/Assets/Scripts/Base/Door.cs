using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
	public int hitPoints = 100;
	//private Text gateHp;
	//this slider for Hitpoints UI
	private Slider gateHpSlider;
	//this for holding door gameobject
	private GameObject doorObject;
	//to determine this door is attackable/not
	public bool attackable = true;
	//to determine this door is destroyable/not
	public bool destroyable = true;

	//To store customizable image of door conditions
	public Sprite[] hitGateTransition;

	//To set the point to transition between two door condition
	private int[] hitPointsStop = new int[3];

	void Awake ()
	{
		//gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
		gateHpSlider = GameObject.Find ("GateHP").GetComponent<Slider> ();
		//gateHp.text = "Gate HP: " + hitPoints;
		doorObject = GameObject.FindGameObjectWithTag ("Base");
	}

	void Start ()
	{
		hitPointsStop [0] = 0; // set array data value with index 0 to 0 (0%)
		hitPointsStop [1] = hitPoints / 2;// set array data value with index 1 to half from hitpoints (50%)
		hitPointsStop [2] = hitPoints; // set last array with maximum value ( 100 % )
	}
	/// <summary>
	/// check if this door is attackable or not based on hit
	/// <seealso cref="Enemy.OnTriggerEnter2D"/>
	/// </summary>
	public void AttackBase (int hpDecrease)
	{
		//check if the base is attackable or not
		if (attackable) {
			//if(gateHp == null)
			//gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
			hitPoints -= hpDecrease;//Decrease hitpoints
			if (hitPoints > 0) {
				//gateHp.text = "Gate HP:  " + hitPoints;
				gateHpSlider.value = hitPoints;//set Slider value based on current Hitpoints
				if (hitPoints < hitPointsStop [1]) {//check if hitpoints below data on array.
					doorObject.GetComponent<SpriteRenderer> ().sprite = hitGateTransition [1];//change image.
				}
			} else {
				//gateHp.text = "Gate Broken";
				// if hitpoints below 0 go to here
				if (destroyable) {
					attackable = false;//set attackable to false
					GameController gameCtrl = GameObject.FindObjectOfType<GameController> ();//get gamecontroller object
					gameCtrl.StopAllCoroutines ();
					doorObject.GetComponent<SpriteRenderer> ().sprite = hitGateTransition [0];//change image again.
				}
			}
		}
	}
	/// <summary>
	/// check if this door is attackable or not based on hit
	/// </summary>
	public bool isAttackAble ()
	{
		return hitPoints > 0;
	}
}