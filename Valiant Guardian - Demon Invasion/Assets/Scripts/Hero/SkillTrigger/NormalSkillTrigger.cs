using UnityEngine;
using System.Collections;
//Put on the normal skill button imitation sprite
public class NormalSkillTrigger : MonoBehaviour
{

    private HeroSkill heroSkill;

    void Awake()
    {
        heroSkill = transform.parent.parent.GetComponent<HeroSkill>();
    }

    void OnMouseDown()
    {
        heroSkill.heroSkill();
    }
}