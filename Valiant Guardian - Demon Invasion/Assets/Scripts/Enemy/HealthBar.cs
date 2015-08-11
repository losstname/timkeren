using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public float maxHitPoints;
    public float fadeSpeed = 1f;
    private Transform hitPoints;
    private SpriteRenderer frameSR;
    private SpriteRenderer fillSR;
    private Color startColor;

    void Start()
    {
        maxHitPoints = transform.parent.GetComponent<Enemy>().hitPoints;
        hitPoints = transform.FindChild("HitPoints");
        frameSR = transform.FindChild("Frame").GetComponent<SpriteRenderer>();
        fillSR = hitPoints.GetChild(0).GetComponent<SpriteRenderer>();
        startColor = frameSR.color;
        this.gameObject.SetActive(false);
    }

    public void OnAttacked(float dmg)
    {
        setHitPoints(dmg);
        showHealthBar();
    }

    private void showHealthBar()
    {
        frameSR.color = startColor;
        fillSR.color = startColor;
        this.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private void setHitPoints(float dmg)
    {
        float scaling = dmg / maxHitPoints;
        Vector3 newScale = new Vector3(scaling, 0f, 0f);
        //To make sure nothing has negative values
        if (hitPoints.localScale.x > newScale.x)
        {
            hitPoints.localScale -= newScale;
        }
        else
        {
            hitPoints.localScale = Vector3.zero;
        }
    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            Color newColor = frameSR.color;
            if (newColor.a == 0)
                break;
            newColor.a -= (Time.deltaTime * fadeSpeed);
            frameSR.color = newColor;
            fillSR.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Enemy Health Bar FadeOutFinished");
        this.gameObject.SetActive(false);
    }
}