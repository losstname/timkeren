using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float maxHitPoints;
    private Transform hitPoints;

    void Start()
    {
        maxHitPoints = transform.parent.GetComponent<Enemy>().hitPoints;
        hitPoints = transform.FindChild("HitPoints");
    }

    public void setHitPoints(float dmg)
    {
        float scaling = dmg / maxHitPoints;
        Vector3 newScale = new Vector3(scaling, 0f, 0f);
        //To make sure nothing has negative values
        if(hitPoints.localScale.x > newScale.x)
        {
            hitPoints.localScale -= newScale;
        }
        else
        {
            hitPoints.localScale = Vector3.zero;
        }
    }
}