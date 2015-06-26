using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public void GoToMenuScreen(){
        Application.LoadLevel("MenuScreen");
    }

    public void GoToSurvival() {
        Application.LoadLevel("main");
    }

    public void ExitApplication() {
        Application.Quit();
    }

	public void RestartApplication(){
		//GameManager.instance.restartScene();
		Application.LoadLevel(Application.loadedLevel);
	}
}