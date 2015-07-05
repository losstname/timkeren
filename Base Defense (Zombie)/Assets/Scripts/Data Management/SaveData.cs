using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveData {

	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
		bf.Serialize(file, DataPlayer.getInstance());
		file.Close();
	}   
	
	public static DataPlayer Load() {
		if(isHaveData()) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			DataPlayer data = (DataPlayer)bf.Deserialize(file);
			file.Close();
			return data;
		}
		return null;
	}

	public static bool isHaveData(){
		return File.Exists(Application.persistentDataPath + "/savedGames.gd");
	}
}
	