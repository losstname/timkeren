using UnityEngine;
using System.Collections;
//Put on the normal skill button imitation sprite
public class NormalSkillTrigger : MonoBehaviour
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
        heroSkill.heroSkill();
        heroSkillTrigger.DestroyReadySkillNotif();
    }
}