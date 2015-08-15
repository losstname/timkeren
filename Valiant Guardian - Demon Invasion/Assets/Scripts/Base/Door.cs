using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int hitPoints = 100;
    //private Text gateHp;
    private Slider gateHpSlider;
    private GameObject doorObject;
    public bool attackable = true;
    public bool destroyable = true;

    //To store customizable image of door conditions
    public Sprite[] hitGateTransition;

    //To set the point to transition between two door condition
    private int[] hitPointsStop = new int[3];

    void Awake()
    {
        //gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
        gateHpSlider = GameObject.Find("GateHP").GetComponent<Slider>();
        //gateHp.text = "Gate HP: " + hitPoints;
        doorObject = GameObject.FindGameObjectWithTag("Base");
    }

    void Start()
    {
        hitPointsStop[0] = 0;
        hitPointsStop[1] = hitPoints / 2;
        hitPointsStop[2] = hitPoints;
    }

    public void AttackBase(int hpDecrease)
    {
        if (attackable)
        {
            //if(gateHp == null)
            //gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
            hitPoints -= hpDecrease;
            if (hitPoints > 0)
            {
                //gateHp.text = "Gate HP:  " + hitPoints;
                gateHpSlider.value = hitPoints;
                if (hitPoints < hitPointsStop[1])
                {
                    doorObject.GetComponent<SpriteRenderer>().sprite = hitGateTransition[1];
                }
            }
            else
            {
                //gateHp.text = "Gate Broken";
                if (destroyable)
                {
                    attackable = false;
                    GameController gameCtrl = GameObject.FindObjectOfType<GameController>();
                    gameCtrl.StopAllCoroutines();
                    doorObject.GetComponent<SpriteRenderer>().sprite = hitGateTransition[0];
                }
            }
        }
    }

    public bool isAttackAble()
    {
        return hitPoints > 0;
    }
}