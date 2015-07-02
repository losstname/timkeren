using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public void GoToMenuScreen(){
        Application.LoadLevel("MenuScreen");
    }

    public void GoToSurvival() {
        Application.LoadLevel("Survival");
    }

    public void GoToStageSelection() {
        Application.LoadLevel("StageSelection");
    }

    public void GoToCharacterSelection() {
        Application.LoadLevel("CharacterSelection");
    }

    public void ExitApplication() {
        Application.Quit();
    }

	public void RestartApplication(){
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}
}