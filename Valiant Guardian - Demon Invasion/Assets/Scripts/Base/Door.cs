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

    void Awake()
    {
        //gateHp = GameObject.Find("BaseHPText").GetComponent<Text>();
        gateHpSlider = GameObject.Find("GateHP").GetComponent<Slider>();
        //gateHp.text = "Gate HP: " + hitPoints;
        doorObject = GameObject.FindGameObjectWithTag("Base");
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
            }
            else
            {
                //gateHp.text = "Gate Broken";
                if (destroyable)
                {
                    attackable = false;
                    GameController gameCtrl = GameObject.FindObjectOfType<GameController>();
                    gameCtrl.StopAllCoroutines();
                    doorObject.SetActive(false);
                }
            }
        }
    }

    public bool isAttackAble()
    {
        return hitPoints > 0;
    }
}