using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataPlayer { 
	
	private static DataPlayer instance;
	public int coin {get; set;}
	public int[] lastHeroUsed {get; set;}

	private DataPlayer () {
		if(SaveData.isHaveData()){
			instance = SaveData.Load();
		}else{
			coin = 0;
			lastHeroUsed = new int[4]{1,2,3,4};
		}
	}

	public static DataPlayer getInstance(){
		if(instance == null)
			instance = new DataPlayer();

		return instance;
	}

//	public int getCoin(){
//		return coin;
//	}
//
//	public int[] getLastHeroUsed(){
//		return lastHeroUsed;
//	}
}