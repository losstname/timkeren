using UnityEngine;
static class SaveData {

    internal static void Save(string saveDataFileName)
    {
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		save.doSave(DataPlayer.getInstance(),saveDataFileName);
	}

    internal static DataPlayer Load(string saveDataFileName)
    {
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return (DataPlayer)save.doLoad(saveDataFileName);
	}

    internal static bool isHaveData(string saveDataFileName)
    {
		SaveToPlayerPrefs save = new SaveToPlayerPrefs();
		return save.isHaveData(saveDataFileName);
	}
}
	