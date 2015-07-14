using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Temp_Databases.Heroes;

[System.Serializable]
public class DataHeroes {
    private const string saveDataFileName = "savedHeroes";
    private Int32 archerExp;
    private Int32 rogueExp;
    private Int32 dukunExp;
    private bool archerLocked;
    private bool rogueLocked;
    private bool dukunLocked;
    private static DataHeroes instance;
    private Dukun dukunModel;
    private Archer archerModel;
    private Rogue rogueModel;

    private DataHeroes() {
        if (SaveData.isHaveData(saveDataFileName))
        {
            archerExp = instance.archerExp;
            rogueExp = instance.rogueExp;
            dukunExp = instance.dukunExp;
            archerLocked = instance.archerLocked;
            rogueLocked = instance.rogueLocked;
            dukunLocked = instance.dukunLocked;
        }
        else 
        {
            archerExp = 0;
            rogueExp = 0;
            dukunExp = 0;
            archerLocked = true;
            rogueLocked = true;
            dukunLocked = true;
        }
        dukunModel = new Dukun(dukunExp, dukunLocked);
        archerModel = new Archer(archerExp, archerLocked);
        rogueModel = new Rogue(rogueExp, rogueLocked);
    }
    public static DataHeroes getInstance()
    {
        if (instance == null)
            instance = new DataHeroes();

        return instance;
    }

    public Dukun DataDukun
    {
        get { return dukunModel; }
        private set { dukunModel = value; }
    }
    public Archer DataArcher
    {
        get { return archerModel; }
        private set { archerModel = value; }
    }
    public Rogue DataRogue
    {
        get { return rogueModel; }
        private set { rogueModel = value; }
    }

    public Int32 ArcherExp
    {
        get { return archerExp; }
        set { 
            archerExp = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public Int32 RogueExp
    {
        get { return rogueExp; }
        set { 
            rogueExp = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public Int32 DukunExp
    {
        get { return dukunExp; }
        set
        {
            dukunExp = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool ArcherLocked
    {
        get { return archerLocked; }
        set
        {
            archerLocked = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool DukunLocked
    {
        get { return dukunLocked; }
        set
        {
            dukunLocked = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool RogueLocked
    {
        get { return rogueLocked; }
        set
        {
            rogueLocked = value;
            SaveData.Save(saveDataFileName);
        }
    }
}
