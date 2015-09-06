using UnityEngine;
using System.Collections;

public class BlinkSwapSprite : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public Sprite[] icons;
    public float speed;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	void Start () {
        StartCoroutine(SwappingSprite());
	}

    IEnumerator SwappingSprite()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            spriteRenderer.sprite = icons[i];
            yield return new WaitForSeconds(speed);
            if (i == icons.Length - 1) { i = -1; }
        }
    }
}