using UnityEngine;
using System.Collections;
//Put on the hero with skillsholder set
public class HeroSkillTrigger : MonoBehaviour
{

    Hero hero;

    private GameObject SkillsHolder;

    private float normalSkillCoolDown;
    private float normalSkillCoolDownLeft;

    private float ultimateSkillCoolDown;
    private float ultimateSkillCoolDownLeft;

    private Collider2D normalSkillCollider;
    private Collider2D ultimateSkillCollider;

    void Awake()
    {
        hero = GetComponent<Hero>();

        SkillsHolder = transform.FindChild("SkillsHolder").gameObject;
        SkillsHolder.SetActive(false);
        normalSkillCollider = SkillsHolder.transform.FindChild("NormalSkill").GetComponent<Collider2D>();
        ultimateSkillCollider = SkillsHolder.transform.FindChild("UltimateSkill").GetComponent<Collider2D>();
    }

    void Update()
    {
        normalSkillCoolDownLeft -= Time.deltaTime;
        ultimateSkillCoolDownLeft -= Time.deltaTime;
        if (normalSkillCoolDownLeft <= 0.0f)
        {
            normalSkillCollider.enabled = true;
        }
        if (ultimateSkillCoolDownLeft <= 0.0f)
        {
            ultimateSkillCollider.enabled = true;
        }
    }

    public void setNormalSkillCoolDown(float coolDown)
    {
        normalSkillCoolDown = coolDown;
    }

    public void setUltimateSkillCoolDown(float coolDown)
    {
        ultimateSkillCoolDown = coolDown;
    }

    public void resetNormalSkillCoolDownLeft()
    {
        normalSkillCoolDownLeft = normalSkillCoolDown;
        normalSkillCollider.enabled = false;
    }

    public void resetUltimateSkillCoolDownLeft()
    {
        ultimateSkillCoolDownLeft = ultimateSkillCoolDown;
        ultimateSkillCollider.enabled = false;
    }

    void OnMouseDown()
    {
        if (SkillsHolder.active)
            HideSkillsHolder();
        else
            ShowSkillsHolder();
    }

    public void ShowSkillsHolder()
    {
        SkillsHolder.SetActive(true);
    }

    public void HideSkillsHolder()
    {
        SkillsHolder.SetActive(false);
    }

    public void PauseHeroAnimation()
    {
        hero.anim.enabled = false;
    }

    public void ResumeHeroAnimation()
    {
        hero.anim.enabled = true;
    }

    public void RestartHeroAnimation()
    {
        hero.anim.Play(hero.idleStateHash, -1, float.NegativeInfinity);
    }
}