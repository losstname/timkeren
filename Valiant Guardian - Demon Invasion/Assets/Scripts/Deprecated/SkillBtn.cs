using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillBtn : MonoBehaviour {

    private float normCoolDown;
    private float normCoolingDown;

    private float ultiCoolDown;
    private float ultiCoolingDown;

    private GameObject skillsHolder;
    private Button normSkillBtn;
    private Button ultiSkillBtn;

    void Awake()
    {
        skillsHolder = transform.GetChild(0).gameObject;
        normSkillBtn = skillsHolder.transform.GetChild(0).GetComponent<Button>();
        ultiSkillBtn = skillsHolder.transform.GetChild(1).GetComponent<Button>();
        normCoolingDown = normCoolDown;
    }

	// Update is called once per frame
	void Update () {

        normCoolingDown -= Time.deltaTime;
        ultiCoolingDown -= Time.deltaTime;
        if (normCoolingDown <= 0.0f) {
            normSkillBtn.interactable = true;
        }
        if (ultiCoolingDown <= 0.0f) {
            ultiSkillBtn.interactable = true;
        }
	}

    public void resetNormCoolingDown()
    {
        normCoolingDown = normCoolDown;
        normSkillBtn.interactable = false;
    }

    public void setNormSkillCoolDown(float cd) {
        normCoolDown = cd;
    }

    public void resetUltiCoolingDown()
    {
        ultiCoolingDown = ultiCoolDown;
        ultiSkillBtn.interactable = false;
    }

    public void setUltiSkillCoolDown(float cd)
    {
        ultiCoolDown = cd;
    }

    public void toogleHeroSkillsHolder() {
        if (skillsHolder.active == true) {
            skillsHolder.SetActive(false);
        }
        else
            skillsHolder.SetActive(true);
    }
}