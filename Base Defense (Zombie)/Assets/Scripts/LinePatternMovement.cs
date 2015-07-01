using UnityEngine;
using System.Collections;

public class LinePatternMovement : MonoBehaviour {

    public float speed = 10f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //minus enemy HP by one
            other.gameObject.GetComponent<EnemyMovement>().gghp -= 1;
            Destroy(gameObject);
            Debug.Log(other.gameObject.GetComponent<EnemyMovement>().gghp);
        }
    }
}