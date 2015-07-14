using Assets.Scripts.Temp_Databases.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class DataEnemy
    {
        private static DataEnemy instance;
        private Enemy meleeImp;
        private Enemy rangedImp;

        private DataEnemy() {
            //set status enemy here
            meleeImp = new Enemy(150, 0 , 70, 70,200);
            rangedImp = new Enemy(80, 40, 50, 30,150);
        }

        public static DataEnemy getInstance() {
            if (instance == null) 
            {
                instance = new DataEnemy();
            }
            return instance;
        }


        public Enemy MeleeImp
        {
            get { return meleeImp; }
            private set { meleeImp = value; }
        }
        public Enemy RangedImp
        {
            get { return rangedImp; }
            private set { rangedImp = value; }
        }
    }
