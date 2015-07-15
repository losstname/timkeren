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
    private DataEnemy()
    {
        //set status enemy here
        meleeImp = new MasterEnemy(150, 0, 70, 70, 200);
        rangedImp = new MasterEnemy(80, 40, 50, 30, 150);
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
}
