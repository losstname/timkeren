using UnityEngine;
using System.Collections;
//Put on the ultimate skill button imitation sprite
public class UltimateSkillTrigger : MonoBehaviour
{

    private HeroSkill heroSkill;

    void Awake()
    {
        heroSkill = transform.parent.parent.GetComponent<HeroSkill>();
    }

    void OnMouseDown()
    {
        heroSkill.heroUltiSkill();
    }
}