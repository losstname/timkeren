using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private int countCoin = 0;
	private Text coinText;

	void Awake()
	{
		coinText = GameObject.Find("CoinText").GetComponent<Text>();
	}

	public void addCoin(){
		countCoin += 10;
		coinText.text = countCoin.ToString();
	}
}
