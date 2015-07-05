using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataPlayer { 
//this class is serializeable, it means can be save and load through data stream like binary file.
	//instance variable for main access to this class, singleton class
	private static DataPlayer instance;
	public int coin {get; set;}
	public int[] lastHeroUsed {get; set;}

	private DataPlayer () {
		//in every Application Load, this data player will be load and check to SaveData. is there any save data or not
		if(SaveData.isHaveData()){
			instance = SaveData.Load();
			//set coin from loaded data
			coin = instance.coin;
			//set last hero used from loaded data
			lastHeroUsed = instance.lastHeroUsed;
		}else{
			//if there are no save data , then 
			coin = 0;
			lastHeroUsed = new int[4]{1,2,3,4};
		}
	}

	public static DataPlayer getInstance(){
		if(instance == null)
			instance = new DataPlayer();

		return instance;
	}
}