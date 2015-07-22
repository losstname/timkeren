using UnityEngine;
using System.Collections;

public class CameraAdjustment : MonoBehaviour {

    void Awake()
    {
        float screenWidth = (float)Screen.width;
        float screenHeight = (float)Screen.height;
        float screenRatio = screenWidth / screenHeight;
        float camSize = 6.4f / screenRatio;
        Camera.main.orthographicSize = camSize;
    }
}