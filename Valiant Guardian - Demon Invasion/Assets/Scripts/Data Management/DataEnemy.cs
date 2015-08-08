using Assets.Scripts.Temp_Databases.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DataEnemy
{
    private static DataEnemy instance;
    private MasterEnemy meleeImp;
    private MasterEnemy rangedImp;
    private MasterEnemy bigMeleeImp;
    private MasterEnemy overLord;
    private MasterEnemy impBomber;
    private MasterEnemy impOjek;

    private DataEnemy()
    {
        //set status enemy here
        meleeImp = new MasterEnemy(1, 200, 10, 60, 50, 1, true);
        rangedImp = new MasterEnemy(45, 160, 10, 50, 50, 1, true);

        bigMeleeImp = new MasterEnemy(1, 500, 5, 135, 75, 1.8, true);
        overLord = new MasterEnemy(1, 160, 10, 50, 50, 1, true);

        impBomber = new MasterEnemy(1, 200, 10, 60, 50, 100, true);
        impOjek = new MasterEnemy(1, 160, 10, 50, 50, 0.1, true);
    }
    public static DataEnemy getInstance()
    {
        if (instance == null)
        {
            instance = new DataEnemy();
        }
        return instance;
    }
    public MasterEnemy MeleeImp
    {
        get { return meleeImp; }
        private set { meleeImp = value; }
    }
    public MasterEnemy RangedImp
    {
        get { return rangedImp; }
        private set { rangedImp = value; }
    }
    public MasterEnemy BigMeleeImp
    {
        get { return bigMeleeImp; }
        private set { bigMeleeImp = value; }
    }
    public MasterEnemy OverLord
    {
        get { return overLord; }
        private set { overLord = value; }
    }
    public MasterEnemy ImpBomber
    {
        get { return impBomber; }
        private set { impBomber = value; }
    }
    public MasterEnemy ImpOjek
    {
        get { return impOjek; }
        private set { impOjek = value; }
    }
}
