using UnityEngine;

public static class SaveData {

	//it's static so we can call it from anywhere
	private const string saveDataFileName =  "savedData";
	public static void Save() {
		//		SaveToFile save = new SaveToFile();
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		save.doSave(DataPlayer.getInstance(),saveDataFileName);
	}   
	
	public static DataPlayer Load() {
//		SaveToFile save = new SaveToFile();
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return (DataPlayer)save.doLoad(saveDataFileName);
	}

	public static bool isHaveData(){
		//for check file only, if there is no file in path return false
		//		SaveToFile save = new SaveToFile();
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return save.isHaveData(saveDataFileName);
	}
}
	