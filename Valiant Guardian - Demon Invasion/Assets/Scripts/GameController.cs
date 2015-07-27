using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public float y1Pos;
    public float y2Pos;
    public float xPos;
    public float wavesWait;
    public GameObject[] Enemies;

    public float timeLimit = 180.0f;
    private float timeLeft;
    private Text timeLeftText;

    public float preparationTime = 60.0f;
    private float preparationTimeLeft;
    private bool isPreparationTime = false;
    private GameObject preparationPanel;

    void Awake()
    {
        preparationPanel = GameObject.Find("PreparationPanel");
        preparationPanel.SetActive(false);
    }

	void Start () {
        timeLeft = timeLimit;
        timeLeftText = GameObject.Find("TimeLeftText").GetComponent<Text>();
        timeLeftText.text = timeLeft.ToString();
        //To Start Enemy Spawning waves using IEnumeratir function
        StartCoroutine(EnemySpawning());
	}

    void Update() {
        //time is decreasing when there is time left
        //prevent minus time when enemy not spawning
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = ((int)timeLeft).ToString();
        }
		else{
            //No player win in survival mode
			//ScriptableObject.FindObjectOfType<PlayerBase>().PlayerWin();
            if(GameObject.FindGameObjectWithTag("Enemy")==null && isPreparationTime==false)
                StartCoroutine(PreparationTime());
		}
    }

    IEnumerator EnemySpawning(){
		while(timeLeft > 0){
            Vector3 InstantiatePos = new Vector3(xPos, Random.Range(y1Pos, y2Pos), 0f); //Set spawning position
            int EnemyToSpawnIndex = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[EnemyToSpawnIndex], InstantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(wavesWait); //Waiting until wavesWait seconds to spawn next enemy
        }
    }

    IEnumerator PreparationTime()
    {
        Text preparationTimeLeftText = preparationPanel.transform.FindChild("Time").GetChild(0).GetComponent<Text>();
        TooglePrepPanel();
        isPreparationTime = true;
        setHeroesAttackCapability(false);
        preparationTimeLeft = preparationTime;
        while (preparationTimeLeft >= 0.0f)
        {
            preparationTimeLeftText.text = preparationTimeLeft.ToString();
            yield return new WaitForSeconds(1.0f);
            preparationTimeLeft--;
        }
        if (preparationTimeLeft < 0.0f && isPreparationTime)
        {
            EndPreparationTime();
        }
    }

    public void EndPreparationTime()
    {
        //to make sure the panel don't show up when the ready button used
        preparationTimeLeft = -1.0f;
        TooglePrepPanel();
        isPreparationTime = false;
        timeLeft = timeLimit;
        //When preparation time ends start spawning enemies again
        StartCoroutine(EnemySpawning());
        setHeroesAttackCapability(true);
    }

    void TooglePrepPanel()
    {
        if (preparationPanel.active == false)
            preparationPanel.SetActive(true);
        else
            preparationPanel.SetActive(false);
    }

    void setHeroesAttackCapability(bool capability)
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < heroes.Length; i++)
        {
            heroes[i].GetComponent<HeroAttack>().setHeroAttackCapability(capability);
        }
    }
}