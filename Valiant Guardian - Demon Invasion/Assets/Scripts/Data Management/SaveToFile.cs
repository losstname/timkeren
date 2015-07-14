using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AssemblyCSharp;

public class SaveToFile : ISave
{
	//const string name used before
    //private const string saveDataFileName =  "/savedData.gd";
	public SaveToFile(){

	}

	public void doSave(object data,string savedName){
		//using binaryformatter to format serialiazable class to binary file
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		//using filestream to create a new file/replace in persistent data path
		FileStream file = File.Create (Application.persistentDataPath + savedName); //you can call it anything you want
		//save class in data file
		bf.Serialize(file, data);
		//close the stream
		file.Close();
	}

	public object doLoad(string savedName) {
		if(isHaveData(savedName)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + savedName, FileMode.Open);
			object data = bf.Deserialize(file);
			file.Close();
			return data;
		}
		return null;
	}

	public bool isHaveData(string savedName){
		//for check file only, if there is no file in path return false
		return File.Exists(Application.persistentDataPath +savedName);
	}
}

