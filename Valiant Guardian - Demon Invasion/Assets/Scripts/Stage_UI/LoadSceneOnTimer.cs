using UnityEngine;
using System.Collections;

public class LoadSceneOnTimer : MonoBehaviour
{

    public float loadTime = 3f;
    public string sceneToLoad;

    void Update()
    {
        loadTime -= Time.deltaTime;
        if (loadTime <= 0)
        {
            Application.LoadLevel(sceneToLoad);
        }
    }
}
