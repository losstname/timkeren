using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreparationTime : MonoBehaviour {

    private GameController gameController;

    public float preparationTime = 60.0f;
    private float preparationTimeLeft;

    private GameObject preparationPanelCanvas;
    private GameObject preparationPanel;
    private GameObject trapShop;
    private GameObject mercenaryShop;
    private GameObject hireMercenaryTab;
    private GameObject fireMercenaryTab;

    private GameObject countDownDialog;

    void Awake()
    {
        gameController = GetComponent<GameController>();

        //Preparation panel canvas
        preparationPanelCanvas = GameObject.Find("PreparationPanelCanvas");

        //Panel used to prepare anything between waves
        preparationPanel = GameObject.Find("PreparationPanel");

        //Trap shop panel
        trapShop = GameObject.Find("TrapShop");

        //Mercenary shop panel
        mercenaryShop = GameObject.Find("MercenaryShop");

        //Hire and Fire tab GO
        hireMercenaryTab = mercenaryShop.transform.FindChild("HireTab").gameObject;
        fireMercenaryTab = mercenaryShop.transform.FindChild("FireTab").gameObject;

        //3 seconds countdown dialog to show before each wave start
        countDownDialog = GameObject.Find("CountdownDialog").gameObject;

        ResetAllPanel();
        preparationPanelCanvas.SetActive(false);
    }

    public void StartPreparationTime()
    {
        StartCoroutine(PreparationTimeCountDown());
        OpenCanvas();
    }

    public void FinishPreparationTime()
    {
        //to make sure the panel don't show up when the ready button used
        preparationTimeLeft = -1.0f;

        ResetAllPanel();

        //Prevent panel active when countdown dialog show up
        preparationPanel.SetActive(false);

        //Start 3 seconds countdown before next wave
        StartCoroutine(CountDownDialog());
    }

    IEnumerator PreparationTimeCountDown()
    {
        Text preparationTimeLeftText = preparationPanel.transform.FindChild("Time").GetChild(0).GetComponent<Text>();
        Text trapShopTimeLeftText = trapShop.transform.FindChild("Time").GetChild(0).GetComponent<Text>();
        Text mercenaryShopTimeLeftText = mercenaryShop.transform.FindChild("Time").GetChild(0).GetComponent<Text>();
        preparationTimeLeft = preparationTime;
        while (preparationTimeLeft >= 0.0f)
        {
            preparationTimeLeftText.text = preparationTimeLeft.ToString();
            trapShopTimeLeftText.text = preparationTimeLeft.ToString();
            mercenaryShopTimeLeftText.text = preparationTimeLeft.ToString();
            yield return new WaitForSeconds(1.0f);
            preparationTimeLeft--;
        }
        if (preparationTimeLeft < 0.0f && gameController.isPreparationTime)
        {
            FinishPreparationTime();
        }
    }

    IEnumerator CountDownDialog()
    {
        countDownDialog.SetActive(true);
        Text text = countDownDialog.transform.FindChild("Text").GetComponent<Text>();
        int count = 3;
        for (int i = count; i > 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        CloseCanvas();

        //Tell the gamecontroller when the preparation times up
        gameController.EndPreparationTime();
    }

    /*------------------------------- Preparation Panel Visibility --------------------------*/
    public void OpenCanvas() { preparationPanelCanvas.SetActive(true); }
    public void CloseCanvas()
    {
        preparationPanelCanvas.SetActive(false);
        ResetAllPanel();
    }

    //Reset all panel
    public void ResetAllPanel()
    {
        preparationPanel.SetActive(true);
        trapShop.SetActive(false);
        mercenaryShop.SetActive(false);

        //Exception for countdown dialog assumed as panel here
        countDownDialog.SetActive(false);
    }

    /*------------------------------- Preparation Panel Navigation ---------------------------*/
    public void BackToMainPanel()
    {
        //set the main panel visible
        preparationPanel.SetActive(true);

        if (trapShop.activeInHierarchy) { trapShop.SetActive(false); }
        if (mercenaryShop.activeInHierarchy) { mercenaryShop.SetActive(false); }
    }

    public void OpenTrapShop()
    {
        //set the trap shop visible
        trapShop.SetActive(true);

        if (preparationPanel.activeInHierarchy) { preparationPanel.SetActive(false); }
    }

    public void OpenMercenaryShop()
    {
        //set the mercenary shop visible
        mercenaryShop.SetActive(true);

        //Set the first tab to open is hire mercenary tab
        OpenHireMercenaryTab();

        if (preparationPanel.activeInHierarchy) { preparationPanel.SetActive(false); }
    }

    public void OpenHireMercenaryTab()
    {
        //Hire Mercenary Tab is inside Mercenary Shop
        hireMercenaryTab.SetActive(true);

        if (fireMercenaryTab.activeInHierarchy) { fireMercenaryTab.SetActive(false); }
    }

    public void OpenFireMercenaryTab()
    {
        //Fire Mercenary Tab is inside Mercenary Shop
        fireMercenaryTab.SetActive(true);

        if (hireMercenaryTab.activeInHierarchy) { hireMercenaryTab.SetActive(false); }
    }
}