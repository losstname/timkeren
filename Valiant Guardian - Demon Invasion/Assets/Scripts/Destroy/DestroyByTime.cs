using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{

    public float lifeTime = 5;
    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
