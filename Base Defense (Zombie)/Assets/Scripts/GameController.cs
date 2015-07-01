using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float y1Pos;
    public float y2Pos;
    public float xPos;
    public float wavesWait;
    public GameObject Enemy;

	void Awake(){

	}

	void Start () {
        //To Start Enemy Spawning waves using IEnumeratir function
	    StartCoroutine(EnemySpawning());
	}

    IEnumerator EnemySpawning(){
        //Enemy spawns when Base HP not zero
		while(true){
            Vector3 InstantiatePos = new Vector3(xPos, Random.Range(y1Pos, y2Pos), 0f); //Set spawning position
            Instantiate(Enemy, InstantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(wavesWait); //Waiting untik wavesWait seconds to spawn next enemy
        }
    }
}