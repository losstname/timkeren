using UnityEngine;
using System.Collections;

public class BlinkAlphaChange : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public float[] alphaStop;
    public float speed = 0.5f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(BlinkingAlpha());
    }

    IEnumerator BlinkingAlpha()
    {
        for (int i = 0; i < alphaStop.Length; i++)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = alphaStop[i];
            spriteRenderer.color = newColor;
            yield return new WaitForSeconds(speed);

            //To reset the counter when end of array reached
            if (i == alphaStop.Length - 1) { i = -1; }
        }
    }
}