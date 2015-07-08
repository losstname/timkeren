using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public float y1Pos;
    public float y2Pos;
    public float xPos;
    public float wavesWait;
    public GameObject Enemy;
    public float timeLimit = 180.0f;
    private Text timeLimitText;

	void Start () {
        timeLimitText = GameObject.Find("TimeLimitText").GetComponent<Text>();
        timeLimitText.text = timeLimit.ToString();
        //To Start Enemy Spawning waves using IEnumeratir function
	    StartCoroutine(EnemySpawning());
	}

    void Update() {
        timeLimit -= Time.deltaTime;
        timeLimitText.text = ((int)timeLimit).ToString();
    }

    IEnumerator EnemySpawning(){
		while(timeLimit > 0){
            Vector3 InstantiatePos = new Vector3(xPos, Random.Range(y1Pos, y2Pos), 0f); //Set spawning position
            Instantiate(Enemy, InstantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(wavesWait); //Waiting until wavesWait seconds to spawn next enemy
        }
    }
}