using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//attach to CharacterSelectionCanvas
//do not rename the panel inside this canvas
public class StageSelection : MonoBehaviour {

    public Sprite[] Stages;         //Collections of stage image

    private GameObject StageListPanel;
    private GameObject SelectedStagePanel;

    void Awake()
    {
        //to get stage list panel
        StageListPanel = gameObject.transform.GetChild(0).FindChild("StageListPanel").gameObject;
        //to get selected stage panel
        SelectedStagePanel = gameObject.transform.GetChild(0).FindChild("SelectedStagePanel").gameObject;
        //set the initial character list
        initStagesList();
        initStagePreview();
    }

    void initStagesList()
    {
        for (int i = 0; i < Stages.Length; i++)
        {
            StageListPanel.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Stages[i];
        }
    }

    void initStagePreview()
    {
        SelectedStagePanel.GetComponent<Image>().sprite = Stages[0];
    }

    public void setStagePreviewToThis(int index)
    {
        SelectedStagePanel.GetComponent<Image>().sprite = Stages[index];
    }
}