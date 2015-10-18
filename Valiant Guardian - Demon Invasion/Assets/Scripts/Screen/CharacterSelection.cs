using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//attach to CharacterSelectionCanvas
//do not rename the panel inside this canvas
public class CharacterSelection : MonoBehaviour
{

    private CharacterList characterList;
    private float distanceBetweenCharThumbList;

    private GameObject CharThumbnailHolder;
    private GameObject PreviewHeroPanel;
    private GameObject HeroesPlacementHolder;
    private GameObject useFourHeroesPromptGO;
    private GameObject LockImageGO;

    private int selectedHero;
    private int filledHeroesPosition;
    //used only to temporary save CURRENT selected hero. not hero saved before.
    //for saved hero before , get data from Data player
    private int[] listSelectedHero;
    private RectTransform selectedHeroFrameTr;
    private RectTransform charThumbnailHolderRect;
    private int[] charThumbnailHolderMovementRange = new int[2];
    private int charThumbnailHolderCurrentPosition = 0;
    public float frameMovementSpeed = 1f;
    private bool frameCanMove = true;

    //momentarily locked status for heroes while connection with database on progress
    public bool[] lockedStat;

    void Awake()
    {
        characterList = GameObject.Find("GameManager").GetComponent<CharacterList>();

        //to get character list panel
        CharThumbnailHolder = GameObject.Find("CharThumbnailHolder").gameObject;
        charThumbnailHolderRect = GameObject.Find("CharThumbnailHolder").GetComponent<RectTransform>();
        selectedHeroFrameTr = GameObject.Find("SelectedFrame").GetComponent<RectTransform>();
        charThumbnailHolderMovementRange[0] = 0;
        charThumbnailHolderMovementRange[1] = CharThumbnailHolder.transform.childCount - 5;

        distanceBetweenCharThumbList = Vector2.Distance(CharThumbnailHolder.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition,
            CharThumbnailHolder.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition);

        //to get selected hero panel
        PreviewHeroPanel = GameObject.Find("PreviewHeroPanel").gameObject;

        //get lock image to show if the hero is locked
        LockImageGO = GameObject.Find("Lock").gameObject;

        //to get heroes position panel
        HeroesPlacementHolder = GameObject.Find("HeroesHolder").gameObject;

        //set the initial character list
        //get the use 4 heroes prompt and disable it
        useFourHeroesPromptGO = GameObject.Find("useFourHeroesPromptBox");
        //use four heroes prompt box must be set active in editor!
        useFourHeroesPromptGO.SetActive(false);

        //initialize selected hero
        listSelectedHero = new int[4] { 0, 0, 0, 0 };
        //Todo -->  load last selected hero
        //set active hero automatically based on this selected hero

        //initialize things in character selection
        selectedHero = 0;
        filledHeroesPosition = -1;
        initHeroesList();
        initHeroPreview();
        initHeroesPositioning();
        validateLockedHero(0);
    }

    void initHeroesList()
    {
        for (int i = 0; i < CharThumbnailHolder.transform.childCount; i++)
        {   //changing the sprite as array defined
            CharThumbnailHolder.transform.GetChild(i).GetComponent<Image>().sprite = characterList.HeroesThumbnail[i];
        }
    }

    void initHeroesPositioning()
    {
        //disable all empty sprite
        for (int i = 0; i < HeroesPlacementHolder.transform.childCount; i++)
        {
            HeroesPlacementHolder.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    //this function called when the assign button is clicked
    public void setHeroPosition()
    {
        //to validate whether the hero can be use or not
        if (!lockedStat[selectedHero] && filledHeroesPosition != HeroesPlacementHolder.transform.childCount - 1)
        {
            HeroesPlacementHolder.transform.GetChild(++filledHeroesPosition).GetComponent<Image>().sprite = characterList.HeroesSprite[selectedHero];
            HeroesPlacementHolder.transform.GetChild(filledHeroesPosition).GetComponent<Image>().enabled = true;
            listSelectedHero[filledHeroesPosition] = selectedHero;
        }
    }

    public void undoHeroPosition()
    {
        HeroesPlacementHolder.transform.GetChild(filledHeroesPosition--).GetComponent<Image>().enabled = false;
    }

    //this function called when the hero image in character list is clicked
    public void selectThisHero(int index)
    {
        Vector3 TargetPosition = CharThumbnailHolder.transform.GetChild(index).GetComponent<RectTransform>().anchoredPosition;
        StartCoroutine(moveSelectedHeroFrame(TargetPosition));
        setSelectedHero(index);
    }

    private void setSelectedHero(int index)
    {
        selectedHero = index;
        setPreviewCharacterToThis(index);
        validateLockedHero(index);
    }

    //validate hero is locked or not
    private void validateLockedHero(int index)
    {
        //if locked, show lock image
        //to do: show purchase button when heroes is available to purchase
        if (lockedStat[index])
        {
            LockImageGO.SetActive(true);
        }
        else
        {
            LockImageGO.SetActive(false);
        }
    }

    public void translateNextHeroList()
    {
        /*
        if (selectedHero + 1 < CharacterImagesHolder.transform.childCount && frameCanMove)
        {
            Vector3 TargetPosition = CharacterImagesHolder.transform.GetChild(selectedHero + 1).GetComponent<RectTransform>().anchoredPosition;
            StartCoroutine(moveSelectedHeroFrame(TargetPosition));
            setSelectedHero(selectedHero + 1);
        }
        */
        if (charThumbnailHolderCurrentPosition + 1 <= charThumbnailHolderMovementRange[1])
        {
            //move holder right
            float xTarget = charThumbnailHolderRect.anchoredPosition.x - distanceBetweenCharThumbList;
            Vector2 TargetPosition = new Vector2(xTarget, charThumbnailHolderRect.anchoredPosition.y);
            StartCoroutine(moveCharThumbnailHolder(TargetPosition));
            setSelectedHero(selectedHero + 1);
            charThumbnailHolderCurrentPosition++;
        }
    }

    public void translatePreviousHeroList()
    {
        /*
        if (selectedHero - 1 >= 0 && frameCanMove)
        {
            Vector2 TargetPosition = CharacterImagesHolder.transform.GetChild(selectedHero - 1).GetComponent<RectTransform>().anchoredPosition;
            StartCoroutine(moveSelectedHeroFrame(TargetPosition));
            setSelectedHero(selectedHero - 1);
        }
        */
        if (charThumbnailHolderCurrentPosition - 1 >= charThumbnailHolderMovementRange[0])
        {
            //move holder left
            float xTarget = charThumbnailHolderRect.anchoredPosition.x + distanceBetweenCharThumbList;
            Vector2 TargetPosition = new Vector2(xTarget, charThumbnailHolderRect.anchoredPosition.y);
            StartCoroutine(moveCharThumbnailHolder(TargetPosition));
            setSelectedHero(selectedHero - 1);
            charThumbnailHolderCurrentPosition--;
        }
    }

    IEnumerator moveSelectedHeroFrame(Vector2 TargetPosition)
    {
        //calculate offset if the char thumb holder moved/scrolled
        float xOffset = charThumbnailHolderCurrentPosition * distanceBetweenCharThumbList;
        TargetPosition = new Vector2(TargetPosition.x - xOffset, TargetPosition.y);
        frameCanMove = false;
        Vector2 StartPosition = selectedHeroFrameTr.anchoredPosition;
        float StartTime = Time.time;
        float distance = Vector2.Distance(StartPosition, TargetPosition);
        while (true)
        {
            float distCovered = (Time.time - StartTime) * frameMovementSpeed;
            float step = distCovered / distance;
            selectedHeroFrameTr.anchoredPosition = Vector3.Lerp(StartPosition, TargetPosition, step);
            yield return new WaitForEndOfFrame();
            if (selectedHeroFrameTr.anchoredPosition == TargetPosition)
                break;
        }
        frameCanMove = true;
    }

    IEnumerator moveCharThumbnailHolder(Vector2 TargetPosition)
    {
        Vector2 StartPosition = charThumbnailHolderRect.anchoredPosition;
        float StartTime = Time.time;
        float distance = Vector2.Distance(StartPosition, TargetPosition);
        while (true)
        {
            float distCovered = (Time.time - StartTime) * frameMovementSpeed;
            float step = distCovered / distance;
            charThumbnailHolderRect.anchoredPosition = Vector3.Lerp(StartPosition, TargetPosition, step);
            yield return new WaitForEndOfFrame();
            if (charThumbnailHolderRect.anchoredPosition == TargetPosition)
                break;
        }
    }

    void initHeroPreview()
    {
        //set the first heroes in array as default preview
        PreviewHeroPanel.transform.FindChild("HeroPreview").GetComponent<Image>().sprite = characterList.HeroesSprite[0];
    }

    public void setPreviewCharacterToThis(int index)
    {
        //index sent by button's parameter
        PreviewHeroPanel.transform.FindChild("HeroPreview").GetComponent<Image>().sprite = characterList.HeroesSprite[index];
    }

    public void fourHeroUsedValidate()
    {
        //if four heroes is selected then go to survival
        if (filledHeroesPosition == HeroesPlacementHolder.transform.childCount - 1)
        {
            ScriptableObject.FindObjectOfType<Navigation>().GoToSurvival();
            //save current selected hero to database
            DataPlayer.getInstance().LastHeroUsed = listSelectedHero;
        }
        //if heroes selected less then 4, cannot continue
        else
        {
            showUseFourHeroesPrompt();
        }
    }

    public void showUseFourHeroesPrompt()
    {
        useFourHeroesPromptGO.SetActive(true);
    }

    public void hideUseFourHeroesPrompt()
    {
        useFourHeroesPromptGO.SetActive(false);
    }
}