using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataPlayer {
    private const string saveDataFileName = "player";
//this class is serializeable, it means can be save and load through data stream like binary file.
	//instance variable for main access to this class, singleton class
	private static DataPlayer instance;
    private int coin;
    private int[] lastHeroUsed;

	private DataPlayer () {
		//in every Application Load, this data player will be load and check to SaveData. is there any save data or not
        if (SaveData.isHaveData(saveDataFileName))
        {
            instance = SaveData.Load(saveDataFileName);
			//set coin from loaded data
			coin = instance.coin;
			//set last hero used from loaded data
            if (instance.lastHeroUsed != null)
			    lastHeroUsed = instance.lastHeroUsed;
            else
                lastHeroUsed = new int[4] { 0,0,0,0 };
		}else{
			//if there are no save data , then
			coin = 0;
            lastHeroUsed = new int[4] { 0, 0, 0, 0 };
		}
	}

	public static DataPlayer getInstance(){
		if(instance == null)
			instance = new DataPlayer();

		return instance;
	}

    public int Coin {
        //get coin used from local database
        get {
            return coin;
        }

        set{
            //use this to save current coin to local database.
            coin = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public int[] LastHeroUsed {
        //Load last hero used from local database
        get{
            return lastHeroUsed;
        }

        set {
            //use this to save current last hero used to local database.
            lastHeroUsed = value;
            //un-Comment below debug to see selected hero
           /*foreach(int e in lastHeroUsed){
                Debug.Log("hehe " + e);
            }*/
            SaveData.Save(saveDataFileName);
        }
    }

}