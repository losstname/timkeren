using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private int countCoin = 0;
	private Text coinText;

	void Awake()
	{
		coinText = GameObject.Find("CoinText").GetComponent<Text>();
		countCoin =	DataPlayer.getInstance().coin;
		coinText.text = countCoin.ToString();
	}

	public void addCoin(){
		countCoin += 10;
		DataPlayer.getInstance().coin = countCoin;
		coinText.text = countCoin.ToString();
	}
}
