using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Temp_Databases.Enemy
{
    public class MasterEnemy
    {

        private int moveSpeed;
        private int range;
        private int attackDamage;
        private int defense;
        private int hitPoints;
        private double idleTime;
        private bool miniBossAvail;

        public MasterEnemy(int range, int hitPoints, int moveSpeed,
            int attackDamage, int defense, double idleTime
            , bool miniBossAvail)
        {
            this.moveSpeed = moveSpeed;
            this.range = range;
            this.attackDamage = attackDamage;
            this.defense = defense;
            this.hitPoints = hitPoints;
            this.idleTime = idleTime;
            this.miniBossAvail = miniBossAvail;
        }

        public double IdleTime
        {
            get { return idleTime; }
            set { idleTime = value; }
        }


        public int MoveSpeed
        {
            get { return moveSpeed; }
            private set { moveSpeed = value; }
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
