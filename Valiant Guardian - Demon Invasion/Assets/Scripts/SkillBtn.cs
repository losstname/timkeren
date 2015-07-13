using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillBtn : MonoBehaviour {

    private float coolDown;
    private float coolingDown;

    private GameObject skillsHolder;
    private Button normSkillBtn;

    void Start()
    {
        skillsHolder = transform.GetChild(0).gameObject;
        normSkillBtn = skillsHolder.transform.GetChild(0).GetComponent<Button>();
        //skillsHolder must be set active in unity editor
        skillsHolder.SetActive(false);
        coolingDown = coolDown;
    }

	// Update is called once per frame
	void Update () {

        coolingDown -= Time.deltaTime;
        if (coolingDown <= 0.0f)
        {
            normSkillBtn.interactable = true;
        }
	}

    public void resetCoolingDown()
    {
        coolingDown = coolDown;
        normSkillBtn.interactable = false;
    }

    public void setNormSkillCoolDown(float cd)
    {
        coolDown = cd;
    }

    public void toogleHeroSkillsHolder()
    {
        if (skillsHolder.active == true) {
            skillsHolder.SetActive(false);
        }
        else
            skillsHolder.SetActive(true);
    }
}