using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//attach to CharacterSelectionCanvas
//do not rename the panel inside this canvas
public class StageSelection : MonoBehaviour {

    public Sprite[] Stages;         //Collections of stage image

    private GameObject StageListPanel;
    private GameObject SelectedStagePanel;
    private Image[] StageListImageComp;
    private int topIndex;
    public int bottomIndex;
    public float rangePerStagesBoard = 160f;
    void Awake()
    {
        //to get stage list panel
        StageListPanel = gameObject.transform.GetChild(0).FindChild("StageListPanel").gameObject;
        //to get selected stage panel
        SelectedStagePanel = gameObject.transform.GetChild(0).FindChild("SelectedStagePanel").gameObject;
        StageListImageComp = new Image[StageListPanel.transform.GetChild(0).childCount];
        //set the initial stage list
        initStagesList();
        initStagePreview();
    }

    void initStagesList()
    {
        topIndex = 0;
        bottomIndex = 2;
        for (int i = 0; i < StageListImageComp.Length; i++)
        {
            StageListPanel.transform.GetChild(0).GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Stages[i];
        }
    }

    public void NextStage()
    {
        //to check is there any next stage
        if ((bottomIndex + 1) < Stages.Length)
        {
            //move the StagesBoardHolder upward
            Vector2 newPos = new Vector2(0f, StageListPanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y + rangePerStagesBoard);
            StageListPanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = newPos;
            topIndex++;
            bottomIndex++;
        }
    }

    public void PreviousStage()
    {
        //to check is there any previous stage
        if ((topIndex - 1) >= 0)
        {
            //move the StagesBoardHolder downward
            Vector2 newPos = new Vector2(0f, StageListPanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y - rangePerStagesBoard);
            StageListPanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = newPos;
            topIndex--;
            bottomIndex--;
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