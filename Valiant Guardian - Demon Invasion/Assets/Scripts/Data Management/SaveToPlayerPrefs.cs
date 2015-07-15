using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SaveToPlayerPrefs : ISave
{
	public SaveToPlayerPrefs(){
        if (PlayerPrefs.HasKey("savedData"))
        {
            //key used before will be deleted...sorry
            PlayerPrefs.DeleteKey("savedData");
        }

        if (PlayerPrefs.HasKey("savedHeroes"))
        {
            //key used before will be deleted...sorry
            PlayerPrefs.DeleteKey("savedHeroes");
        }

        if (PlayerPrefs.HasKey("savedPlayer"))
        {
            //key used before will be deleted...sorry
            PlayerPrefs.DeleteKey("savedPlayer");
        }
	}

	public void doSave (object data,string savedName)
	{
		string savedData = ObjectToString.ToString(data);
		PlayerPrefs.SetString(savedName,savedData);
	}

	public object doLoad (string savedName)
	{
		if(isHaveData(savedName)){
			string savedData = PlayerPrefs.GetString(savedName);
			object data = ObjectToString.ToObject(savedData);
			return data;
		}
		return null;
	}

	public bool isHaveData (string savedName)
	{
		string savedData = PlayerPrefs.GetString(savedName,"");
		return !savedData.Trim().Equals("");
	}
}

