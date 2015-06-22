using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public void ExitApplication() {
        Application.Quit();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}