using UnityEngine;
using System.Collections;

public class DmgFloater : MonoBehaviour {

    public float time = 0.5f;
    public float speed = 1f;
    public float fadeSpeed = 1f;
    private TextMesh textMesh;

    void Start()
    {
        Destroy(gameObject, time);
        textMesh = GetComponent<TextMesh>();
        StartCoroutine(FadeOut());
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(0f, Time.deltaTime * speed, 0f);
        transform.position += newPosition;
    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            Color newColor = textMesh.color;
            newColor.a -= (Time.deltaTime * fadeSpeed);
            textMesh.color = newColor;
            yield return new WaitForEndOfFrame();
        }
    }
}