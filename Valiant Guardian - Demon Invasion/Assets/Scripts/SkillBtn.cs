using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillBtn : MonoBehaviour {

    private float coolDown;
    private float coolingDown;

    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        coolingDown = coolDown;
    }

	// Update is called once per frame
	void Update () {
        coolingDown -= Time.deltaTime;
        if (coolingDown <= 0.0f)
        {
            btn.interactable = true;
        }
	}

    public void resetCoolingDown()
    {
        coolingDown = coolDown;
        btn.interactable = false;
    }

    public void setSkillCoolDown(float cd)
    {
        coolDown = cd;
    }
}