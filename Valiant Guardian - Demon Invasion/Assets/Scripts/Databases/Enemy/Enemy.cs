using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Temp_Databases.Enemy
{
    public class Enemy
    {
        private int attackSpeed;
        private int range;
        private int attackDamage;
        private int defense;
        private int hitPoints;
        //skill & buff?

        public Enemy(int attackSpeed, int range, int attackDamage, int defense, int hitPoints)
        {
            this.attackSpeed = attackSpeed;
            this.range = range;
            this.attackDamage = attackDamage;
            this.defense = defense;
            this.hitPoints = hitPoints;
        }


        public int AttackSpeed
        {
            get { return attackSpeed; }
            private set { attackSpeed = value; }
        }
        public int Range
        {
            get { return range; }
            private set { range = value; }
        }
        public int AttackDamage
        {
            get { return attackDamage; }
            private set { attackDamage = value; }
        }
        public int Defense
        {
            get { return defense; }
            private set { defense = value; }
        }
        public int Hitpoints
        {
            get { return hitPoints; }
            private set { hitPoints = value; }
        }
    }
}
