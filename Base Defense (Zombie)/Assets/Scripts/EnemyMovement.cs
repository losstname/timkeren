using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 1f;
    private bool ableMove = true;

	// Update is called once per frame
	void Update () {
        if(ableMove)
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

    void OnTriggerEnter2D(Collider2D other) {
        ableMove = false;
    }
}
