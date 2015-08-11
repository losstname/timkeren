using UnityEngine;
using System.Collections;
//Put on the hero
public class HeroSkill : MonoBehaviour
{

    private Hero hero;
    private HeroSkillTrigger heroSkillTrigger;

    void Awake()
    {
        hero = GetComponent<Hero>();
        heroSkillTrigger = GetComponent<HeroSkillTrigger>();
    }

    public void heroSkill()
    {
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.useSkillHash);
        //reset normal skill button cooldownleft
        heroSkillTrigger.resetNormalSkillCoolDownLeft();
        heroSkillTrigger.HideSkillsHolder();
    }

    public void heroUltiSkill()
    {
        if (hero.anim != null)
            hero.anim.SetTrigger(hero.useUltiSkillHash);
        //reset ultimate skill button cooldownleft
        heroSkillTrigger.resetUltimateSkillCoolDownLeft();
        heroSkillTrigger.HideSkillsHolder();
    }
}