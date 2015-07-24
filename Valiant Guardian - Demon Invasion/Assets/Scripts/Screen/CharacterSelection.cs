using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//attach to CharacterSelectionCanvas
//do not rename the panel inside this canvas
public class CharacterSelection : MonoBehaviour {

    private CharacterList characterList;

    private GameObject CharacterListPanel;
    private GameObject SelectedHeroPanel;
    private GameObject HeroesPositionPanel;
    private GameObject useFourHeroesPromptGO;

    private int selectedHero;
    private bool isFourHeroesSet = false;
    //used only to temporary save CURRENT selected hero. not hero saved before.
    //for saved hero before , get data from Data player
    private int[] listSelectedHero;

    void Awake()
    {
        characterList = GameObject.Find("GameManager").GetComponent<CharacterList>();
        //to get character list panel
        CharacterListPanel = gameObject.transform.GetChild(0).FindChild("CharacterListPanel").gameObject;
        //to get selected hero panel
        SelectedHeroPanel = gameObject.transform.GetChild(0).FindChild("SelectedHeroPanel").gameObject;
        //to get heroes position panel
        HeroesPositionPanel = gameObject.transform.GetChild(0).FindChild("HeroesPositionPanel").gameObject;
        //set the initial character list
        //get the use 4 heroes prompt and disable it
        useFourHeroesPromptGO = GameObject.Find("useFourHeroesPromptBox");
        //use four heroes prompt box must be set active in editor!
        useFourHeroesPromptGO.SetActive(false);

        //initialize selected hero
        listSelectedHero = new int[4] { 0,0,0,0 };
        //Todo -->  load last selected hero
        //set active hero automatically based on this selected hero

        initHeroesList();
        initHeroPreview();
        initHeroesPositioning();
    }

    void initHeroesList()
    {
        for (int i = 0; i < characterList.HeroesThumbnail.Length; i++)
        {   //changing the sprite as array defined
            CharacterListPanel.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = characterList.HeroesThumbnail[i];
        }
    }

    void initHeroesPositioning()
    {
        for (int i = 0; i < 4; i++)
        {
            HeroesPositionPanel.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    public void setHeroPosition() {
        for (int i = 0; i < 4; i++)
        {
            if (HeroesPositionPanel.transform.GetChild(i).GetComponent<Image>().enabled == false)
            {
                HeroesPositionPanel.transform.GetChild(i).GetComponent<Image>().sprite = characterList.HeroesSprite[selectedHero];
                HeroesPositionPanel.transform.GetChild(i).GetComponent<Image>().enabled = true;
                //set current selected hero to new index
                listSelectedHero[i] = selectedHero;
                break;
            }
        }
        //check if the fourth hero has been set, of course it is third index
        if (HeroesPositionPanel.transform.GetChild(3).GetComponent<Image>().enabled == true) {
            isFourHeroesSet = true;
        }
    }

    public void setSelectedHero(int index)
    {
        selectedHero = index;
        setPreviewCharacterToThis(index);
    }

    void initHeroPreview()
    {
        //set the first heroes in array as default preview
        SelectedHeroPanel.transform.GetChild(0).GetComponent<Image>().sprite = characterList.HeroesSprite[0];
    }

    public void setPreviewCharacterToThis(int index)
    {
        //index sent by button's parameter
        SelectedHeroPanel.transform.GetChild(0).GetComponent<Image>().sprite = characterList.HeroesSprite[index];
    }

    public void fourHeroUsedValidate()
    {
        //if four heroes is selected then go to survival
        if (isFourHeroesSet) {
            ScriptableObject.FindObjectOfType<Navigation>().GoToSurvival();
            //save current selected hero to database
            DataPlayer.getInstance().LastHeroUsed = listSelectedHero;
        }
        //if heroes selected less then 4, cannot continue
        else {
            showUseFourHeroesPrompt();
        }
    }

    public void showUseFourHeroesPrompt(){
        useFourHeroesPromptGO.SetActive(true);
    }

    public void hideUseFourHeroesPrompt(){
        useFourHeroesPromptGO.SetActive(false);
    }
}