using UnityEngine;
using System.Collections;

public class StageUI : MonoBehaviour {

    private GameController gameController;

    private GameObject gameMenu;
    private GameObject startupDialog;

    void Awake()
    {
        gameController = GetComponent<GameController>();
        gameMenu = GameObject.Find("GameMenu");
        startupDialog = GameObject.Find("StartupDialog");
        gameMenu.SetActive(false);
        //startupDialog.SetActive(true);
    }

    public void ToogleGameMenu()
    {
        if (!gameMenu.activeInHierarchy)
        {
            //When the button pressed open the menu and pause the game
            gameMenu.SetActive(true);
            gameController.PauseGame();
        }
        else
        {
            //when the menu already opened, close the menu and unpause the game
            gameMenu.SetActive(false);
            gameController.UnPauseGame();
        }
    }

    public void StartWave()
    {
        startupDialog.SetActive(false);
        gameController.StartWave();
    }
}