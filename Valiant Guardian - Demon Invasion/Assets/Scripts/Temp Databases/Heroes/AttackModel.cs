using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Temp_Databases.Heroes
{
    public class AttackModel
    {
        private int cooldown;
        //[X,Y]
        private int[] radius;
        private int damage;

        public AttackModel(int cooldown, int[] radius, int damage)
        {
            this.cooldown = cooldown;
            this.radius = radius;
            this.damage = damage;
        }

        public int Cooldown { get; set; }

        public int[] Radius { get; set; }

        public int Damage {
            get { return damage; }
            private set {; }
        }

    }
}
