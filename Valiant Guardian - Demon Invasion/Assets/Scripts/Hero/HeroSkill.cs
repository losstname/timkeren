using UnityEngine;
using System.Collections;

public class HeroSkill : MonoBehaviour {

    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void heroSkill()
    {
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.useSkillHash);
        //reset skill button cooldown
        GameObject.Find("SkillPanel").transform.GetChild(hero.SkillBoardNumber).GetComponent<SkillBtn>().resetNormCoolingDown();
    }

    public void heroUltiSkill()
    {
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.useUltiSkillHash);
        //reset skill button cooldown
        GameObject.Find("SkillPanel").transform.GetChild(hero.SkillBoardNumber).GetComponent<SkillBtn>().resetUltiCoolingDown();
    }
}