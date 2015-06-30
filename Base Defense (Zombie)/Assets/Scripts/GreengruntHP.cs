using UnityEngine;
using System.Collections;

public class GreengruntHP : MonoBehaviour {
	public static GreengruntHP instance = null;
	public GameObject unit;
	// Use this for initialization
	void Start () {
		unit = GameObject.FindGameObjectWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {

}

	//void OnTriggerEnter2D(Collider2D collision) {
		//if(collision.gameObject.name == "LoS1"){
			//this.gghp --;

		//}
	//}
}