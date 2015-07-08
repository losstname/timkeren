using UnityEngine;

public static class SaveData {
	private const string saveDataFileName =  "savedData";

	public static void Save() {
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		save.doSave(DataPlayer.getInstance(),saveDataFileName);
	}   
	
	public static DataPlayer Load() {
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return (DataPlayer)save.doLoad(saveDataFileName);
	}

	public static bool isHaveData(){
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return save.isHaveData(saveDataFileName);
	}
}
	