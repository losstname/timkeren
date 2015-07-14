using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private int countCoin = 0;
	private Text coinText;

	void Awake()
	{
        coinText = transform.FindChild("CoinText").GetComponent<Text>();
		//Always load coin from dataPlayer
		countCoin =	DataPlayer.getInstance().Coin;
		coinText.text = countCoin.ToString();
	}

	public void addCoin(){
		countCoin += 10;
		//set coin data in DataPlayer
        DataPlayer.getInstance().Coin = countCoin;
		coinText.text = countCoin.ToString();
		//always save coin data for every time get coin
		//todo in Future will be improved, because can (maybe) be a killer performance
		//because every state coin will access disk to write file
	}

    public int getCoin(){
        return DataPlayer.getInstance().Coin;
    }
}
