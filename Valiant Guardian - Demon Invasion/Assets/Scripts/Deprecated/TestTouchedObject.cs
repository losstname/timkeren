using UnityEngine;
using System.Collections;

public class TestTouchedObject : MonoBehaviour {

    public string message;

    void OnMouseDown()
    {
        Debug.Log(message);
    }
}