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
    public float timeAdd = 20.0f;
    private float timeLeft;
    private Text timeLeftText;

    //preparation panel script
    PreparationTime preparationTime;
    public bool isPreparationTime = false;

    //wave board info management using these three variables
    private int wave;
    private Text waveText;

    private bool isPaused = false;
    private bool isStarted = false;

    void Awake()
    {
        characterList = GameObject.Find("GameManager").GetComponent<CharacterList>();
        preparationTime = GetComponent<PreparationTime>();
    }

    void Start()
    {
        //set wave board number from set of sprite numbers
        wave = 1;
        waveText = GameObject.Find("WaveBoard").transform.FindChild("WaveCount").GetComponent<Text>();
        setWaveBoardNumber(wave);

        //spawn heroes which have been selected in character selection screen
        SpawnHeroes();

        //manage time left for each wave
        timeLeft = timeLimit;
        timeLeftText = GameObject.Find("TimeLeftText").GetComponent<Text>();
        timeLeftText.text = timeLeft.ToString();

        //To Start Enemy Spawning waves using IEnumeratir function
        //StartCoroutine(EnemySpawning());
    }

    void Update()
    {
        //time is decreasing when there is time left
        //prevent minus time when enemy not spawning
        //only count when the game is started
        if (timeLeft > 0)
        {
            if(isStarted)
            {
                timeLeft -= Time.deltaTime;
                timeLeftText.text = ((int)timeLeft).ToString();
            }
        }
        else
        {
            //No player win in survival mode
            //ScriptableObject.FindObjectOfType<PlayerBase>().PlayerWin();
            if (GameObject.FindGameObjectWithTag("Enemy") == null && isPreparationTime == false)
            {
                BeginPreparationTime();
            }
        }
    }

    private void SpawnHeroes()
    {
        GameObject heroesHolder = GameObject.Find("HeroPos");
        int[] heroesOrder = DataPlayer.getInstance().LastHeroUsed;
        for (int i = 0; i < heroesHolder.transform.childCount; i++)
        {
            GameObject tempHero = Instantiate(characterList.HeroesPrefab[heroesOrder[i]], heroesHolder.transform.GetChild(i).position, Quaternion.identity) as GameObject;
            tempHero.transform.parent = heroesHolder.transform.GetChild(i).transform;
        }
    }

    public void StartWave()
    {
        isStarted = true;
        StartCoroutine(EnemySpawning());
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

    private void BeginPreparationTime()
    {
        isPreparationTime = true;

        //Tell preparation time class to start the countdown
        preparationTime.StartPreparationTime();

        setHeroesAttackCapability(false);
    }

    //make this public function so the ready button can trigger it
    public void EndPreparationTime()
    {
        isPreparationTime = false;
        timeLimit += timeAdd;
        timeLeft = timeLimit;
        //When preparation time ends start spawning enemies again
        StartCoroutine(EnemySpawning());
        setHeroesAttackCapability(true);

        //update the Wave information
        setWaveBoardNumber(++wave);
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
        waveText.text = wave.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}