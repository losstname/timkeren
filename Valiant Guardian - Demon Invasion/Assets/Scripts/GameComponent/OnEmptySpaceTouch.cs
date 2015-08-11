using UnityEngine;
using System.Collections;

public class OnEmptySpaceTouch : MonoBehaviour
{

    HeroSkillTrigger[] heroesSkillTrigger;

    void Start()
    {
        Invoke("setHeroesSkillTrigger", 1f);
    }

    void OnMouseDown()
    {
        disableOtherActiveTrigger();
    }

    private void setHeroesSkillTrigger()
    {
        GameObject[] heroesGO = GameObject.FindGameObjectsWithTag("Hero");
        heroesSkillTrigger = new HeroSkillTrigger[heroesGO.Length];
        for (int i = 0; i < heroesGO.Length; i++)
        {
            heroesSkillTrigger[i] = heroesGO[i].GetComponent<HeroSkillTrigger>();
        }
    }

    public void disableOtherActiveTrigger()
    {
        //disable active skill button
        for (int i = 0; i < heroesSkillTrigger.Length; i++)
        {
            heroesSkillTrigger[i].HideSkillsHolder();
        }
    }
}