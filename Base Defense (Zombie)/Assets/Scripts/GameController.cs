using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float y1Pos;
    public float y2Pos;
    public float xPos;
    public float wavesWait;

    public GameObject Enemy;

	void Start () {
	    StartCoroutine(EnemySpawning());
	}

    IEnumerator EnemySpawning(){
        while(true){
            Vector3 InstantiatePos = new Vector3(xPos, Random.Range(y1Pos, y2Pos), 0f);
            Instantiate(Enemy, InstantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(wavesWait);
        }
    }
}