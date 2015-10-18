using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this class must be attached to OptionBoard gameobject

public class OptionMenu : MonoBehaviour {

    private GameObject optionBoard;
    private GameObject[] frameCheckList = new GameObject[2];

    void Awake()
    {
        optionBoard = this.gameObject;
        frameCheckList[0] = optionBoard.transform.GetChild(0).gameObject;
        frameCheckList[1] = optionBoard.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        CloseOptionBoard();
    }

    public void OpenOptionBoard()
    {
        optionBoard.SetActive(true);
    }

    public void CloseOptionBoard()
    {
        optionBoard.SetActive(false);
    }

    public void CheckList(int index)
    {
        //this method called by clicking the FrameCheckList to enable CheckListImage
        frameCheckList[index].transform.GetChild(0).gameObject.SetActive(true);

        //to make the frame inactive while maintaining the visual image
        frameCheckList[index].GetComponent<Button>().enabled = false;
    }

    public void UncheckList(int index)
    {
        //this method called by clicking the CheckListImage to self disable
        frameCheckList[index].transform.GetChild(0).gameObject.SetActive(false);

        //to make the FrameCheckList active again
        frameCheckList[index].GetComponent<Button>().enabled = true;
    }
}