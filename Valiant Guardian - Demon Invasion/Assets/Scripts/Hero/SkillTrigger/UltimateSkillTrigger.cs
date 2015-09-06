using UnityEngine;
using System.Collections;
//Put on the ultimate skill button imitation sprite
public class UltimateSkillTrigger : MonoBehaviour
{
    private HeroSkill heroSkill;
    private HeroSkillTrigger heroSkillTrigger;

    void Awake()
    {
        heroSkill = transform.parent.parent.GetComponent<HeroSkill>();
        heroSkillTrigger = transform.parent.parent.GetComponent<HeroSkillTrigger>();
    }

    void OnMouseDown()
    {
        heroSkill.heroUltiSkill();
        heroSkillTrigger.DestroyReadySkillNotif();
    }
}