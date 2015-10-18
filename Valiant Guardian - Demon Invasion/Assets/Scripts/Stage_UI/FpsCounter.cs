using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FpsCounter : MonoBehaviour
{

    float deltaTime = 0.0f;
    float resetTime = 0.05f;
    float reseting = 0.0f;
    Text fpsText;

    void Awake()
    {
        fpsText = GetComponent<Text>();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        reseting -= Time.deltaTime;
        if (reseting <= 0.0f)
        {
            setFpsText();
            reseting = resetTime;
        }
    }

    void setFpsText()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        //string text = string.Format("FPS : {0:0.}", fps);
        fpsText.text = text;
    }
}