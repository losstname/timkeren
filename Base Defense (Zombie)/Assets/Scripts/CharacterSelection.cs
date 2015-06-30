using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//attach to CharacterSelectionCanvas
//do not rename the panel inside this canvas
public class CharacterSelection : MonoBehaviour {

    public Sprite[] HeroesThumb;    //face thumbnail for listing
    public Sprite[] EnemiesThumb;   //face thumbnail for listing

    public Sprite[] Heroes;         //full body image for preview
    public Sprite[] Enemies;        //full body image for preview

    private GameObject CharacterListPanel;
    private GameObject SelectedHeroPanel;
    private GameObject HeroesPositionPanel;

    void Awake()
    {
        //to get character list panel
        CharacterListPanel = gameObject.transform.GetChild(0).FindChild("CharacterListPanel").gameObject;
        //to get selected hero panel
        SelectedHeroPanel = gameObject.transform.GetChild(0).FindChild("SelectedHeroPanel").gameObject;
        //to get heroes position panel
        HeroesPositionPanel = gameObject.transform.GetChild(0).FindChild("HeroesPositionPanel").gameObject;
        //set the initial character list
        initCharList();
        initCharPreview();
        initHeroesPositioning();
    }

    void initHeroesPositioning()
    {
        for (int i = 0; i < 4; i++)
        {
            HeroesPositionPanel.transform.GetChild(i).GetComponent<Image>().sprite = Heroes[i];
        }
    }

    void initCharPreview()
    {
        //set the first heroes in array as default preview
        SelectedHeroPanel.transform.GetChild(0).GetComponent<Image>().sprite = Heroes[0];
    }

    void initCharList()
    {
        for (int i = 0; i < HeroesThumb.Length; i++)
        {   //changing the sprite as array defined
            CharacterListPanel.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = HeroesThumb[i];
        }
    }

    public void setPreviewCharacter(int index)
    {
        //index sent by button's parameter
        SelectedHeroPanel.transform.GetChild(0).GetComponent<Image>().sprite = Heroes[index];
    }
}
