using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public void ExitApplication() {
        Application.Quit();
    }

	public void RestartApplication(){
		GameManager.instance.restartScene();
		Application.LoadLevel(0);
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}