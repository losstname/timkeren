using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataPlayer {
    private const string saveDataFileName = "player";
//this class is serializeable, it means can be save and load through data stream like binary file.
	//instance variable for main access to this class, singleton class
	private static DataPlayer instance;
    private int coin;
    private bool[] lastHeroUsed;

	private DataPlayer () {
		//in every Application Load, this data player will be load and check to SaveData. is there any save data or not
        if (SaveData.isHaveData(saveDataFileName))
        {
            instance = SaveData.Load(saveDataFileName);
			//set coin from loaded data
			coin = instance.coin;
			//set last hero used from loaded data
            /* because still experimentation , this line below will not used for now
            if (instance.lastHeroUsed != null)
			    lastHeroUsed = instance.lastHeroUsed;
            else
                lastHeroUsed = new bool[6] { false, false, false, false, false, false };
             */
		}else{
			//if there are no save data , then 
			coin = 0;
			//lastHeroUsed = new bool[6]{false,false,false,false,false,false};
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
    /*
    public bool[] LastHeroUsed { 
        //get last hero used from local database
        get{
            return lastHeroUsed;        
        }

        set {
            //use this to save current last hero used to local database.
            lastHeroUsed = value;
            //SaveData.Save(saveDataFileName);
        }
    }*/

}