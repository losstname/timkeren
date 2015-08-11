using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    CharacterList characterList;

    public float y1Pos;
    public float y2Pos;
    public float xPos;
    private float zOffset = -1f;

    public float wavesWait;
    public GameObject[] Enemies;

    public float timeLimit = 180.0f;
    private float timeLeft;
    private Text timeLeftText;

    public float preparationTime = 60.0f;
    private float preparationTimeLeft;
    private bool isPreparationTime = false;
    private GameObject preparationPanel;

    //wave board info management using these three variables
    private int wave;
    public Sprite[] waveTextList;
    private Image[] waveTextUnit = new Image[2];

    void Awake()
    {
        characterList = GameObject.Find("GameManager").GetComponent<CharacterList>();

        //Panel used to prepare anything between waves
        preparationPanel = GameObject.Find("PreparationPanel");

        //Set inactive for the initial gameplay
        preparationPanel.SetActive(false);
    }

    void Start()
    {
        //set wave board number from set of sprite numbers
        wave = 1;
        waveTextUnit[0] = GameObject.Find("WaveBoard").transform.FindChild("Unit").GetComponent<Image>();
        waveTextUnit[1] = GameObject.Find("WaveBoard").transform.FindChild("Dozens").GetComponent<Image>();
        setWaveBoardNumber(wave);

        //spawn heroes which have been selected in character selection screen
        SpawnHeroes();

        //manage time left for each wave
        timeLeft = timeLimit;
        timeLeftText = GameObject.Find("TimeLeftText").GetComponent<Text>();
        timeLeftText.text = timeLeft.ToString();

        //To Start Enemy Spawning waves using IEnumeratir function
        StartCoroutine(EnemySpawning());
    }

    void Update()
    {
        //time is decreasing when there is time left
        //prevent minus time when enemy not spawning
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = ((int)timeLeft).ToString();
        }
        else
        {
            //No player win in survival mode
            //ScriptableObject.FindObjectOfType<PlayerBase>().PlayerWin();
            if (GameObject.FindGameObjectWithTag("Enemy") == null && isPreparationTime == false)
                StartCoroutine(PreparationTime());
        }
    }

    private void SpawnHeroes()
    {
        GameObject heroesHolder = GameObject.Find("Hero");
        int[] heroesOrder = DataPlayer.getInstance().LastHeroUsed;
        for (int i = 0; i < heroesHolder.transform.childCount; i++)
        {
            GameObject tempHero = Instantiate(characterList.HeroesPrefab[heroesOrder[i]], heroesHolder.transform.GetChild(i).position, Quaternion.identity) as GameObject;
            tempHero.transform.parent = heroesHolder.transform.GetChild(i).transform;
        }
    }

    IEnumerator EnemySpawning(){
		while(timeLeft > 0){
            //Set initial yPos
            float yPos = Random.Range(y1Pos, y2Pos);

            float zPos = yPos + zOffset - y1Pos;
            Vector3 InstantiatePos = new Vector3(xPos, yPos, zPos); //Set spawning position
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

    //make this public function so the ready button can trigger it
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

        //update the Wave information
        setWaveBoardNumber(++wave);
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

    void setWaveBoardNumber(int wave)
    {
        int a = wave % 10;
        waveTextUnit[0].sprite = waveTextList[a];
        int b = wave / 10;
        waveTextUnit[1].sprite = waveTextList[b];
    }
}