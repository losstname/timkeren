using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Temp_Databases.Heroes
{
    public class Dukun : Heroes
    {
        public Dukun(Int32 experience, bool locked)
            : base(experience, locked, 2)//dukun ID =2
        {
            preparingData();   
        }

        private void preparingData()
        {
            mainAttack = new AttackModel(2, new int[] { 15, 5 }, 40);
            skillAttack = new AttackModel(30, new int[] { 1, 1 }, 60);
            ultSkillAttack = new AttackModel(30, new int[] { 1, 1 }, 60);
            attackSpeed = 60;
            price = 100;
        }
    }
}
