using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Temp_Databases.Heroes;

//this class is used for databases heroes holder and manager.
//get actual hero status and save data heroes using this singleton class.
[System.Serializable]
public class DataHeroes
{
    //don't ever change this const below
    private const string saveDataFileName = "heroes";
    //dynamic data which is save to local database
    //use this variable below to save / update data heroes to local database
    private Int32 archerExp;
    private Int32 sniperExp;
    private Int32 rogueExp;
    private Int32 dukunExp;
    private bool archerLocked;
    private bool sniperLocked;
    private bool rogueLocked;
    private bool dukunLocked;
    private static DataHeroes instance;
    //static data which is get from system databases
    //use this model for get real hero status
    private Archer archerModel;
    private Sniper sniperModel;
    private Dukun dukunModel;
    private Rogue rogueModel;

    private DataHeroes()
    {
        if (SaveData.isHaveData(saveDataFileName))
        {
            archerExp = instance.archerExp;
            sniperExp = instance.sniperExp;
            rogueExp = instance.rogueExp;
            dukunExp = instance.dukunExp;

            archerLocked = instance.archerLocked;
            sniperLocked = instance.sniperLocked;
            rogueLocked = instance.rogueLocked;
            dukunLocked = instance.dukunLocked;
        }
        else
        {
            archerExp = 0;
            sniperExp = 0;
            rogueExp = 0;
            dukunExp = 0;

            archerLocked = true;
            sniperLocked = true;
            rogueLocked = true;
            dukunLocked = true;
        }
        archerModel = new Archer(archerExp, archerLocked);
        sniperModel = new Sniper(sniperExp, sniperLocked);
        dukunModel = new Dukun(dukunExp, dukunLocked);
        rogueModel = new Rogue(rogueExp, rogueLocked);
    }
    public static DataHeroes getInstance()
    {
        if (instance == null)
            instance = new DataHeroes();

        return instance;
    }
    //use this method below to get actual status heroes
    public Archer DataArcher
    {
        get { return archerModel; }
        private set { archerModel = value; }
    }
    public Sniper DataSniper
    {
        get { return sniperModel; }
        private set { sniperModel = value; }
    }
    public Dukun DataDukun
    {
        get { return dukunModel; }
        private set { dukunModel = value; }
    }
    public Rogue DataRogue
    {
        get { return rogueModel; }
        private set { rogueModel = value; }
    }

    //actually anyone can get spesific attribute directly from method below
    //but preferred to get all of hero stat from dataModel above
    public Int32 ArcherExp
    {
        get { return archerExp; }
        set
        {
            archerExp = value;
            archerModel.Experience = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public Int32 SniperExp
    {
        get { return sniperExp; }
        set
        {
            sniperExp = value;
            sniperModel.Experience = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public Int32 RogueExp
    {
        get { return rogueExp; }
        set
        {
            rogueExp = value;
            rogueModel.Experience = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public Int32 DukunExp
    {
        get { return dukunExp; }
        set
        {
            dukunExp = value;
            dukunModel.Experience = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool ArcherLocked
    {
        get { return archerLocked; }
        set
        {
            archerLocked = value;
            archerModel.Locked = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool SniperLocked
    {
        get { return sniperLocked; }
        set
        {
            sniperLocked = value;
            sniperModel.Locked = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool DukunLocked
    {
        get { return dukunLocked; }
        set
        {
            dukunLocked = value;
            dukunModel.Locked = value;
            SaveData.Save(saveDataFileName);
        }
    }
    public bool RogueLocked
    {
        get { return rogueLocked; }
        set
        {
            rogueLocked = value;
            rogueModel.Locked = value;
            SaveData.Save(saveDataFileName);
        }
    }
}
