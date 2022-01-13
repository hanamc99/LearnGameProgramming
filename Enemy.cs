using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Enemy
    {
        DataMgr mgr = DataMgr.GetInstance();

        public int id;
        public string name;
        public float damage;
        public float hp;
        public int grade;
        public int reward;

        public Enemy(int id)
        {
            this.id = id;
        }

        public void Init()
        {
            this.name = mgr.GetMonsterData(this.id).name;
            this.damage = mgr.GetMonsterData(this.id).damage;
            this.hp = mgr.GetMonsterData(this.id).max_hp;
            this.grade = mgr.GetMonsterData(this.id).grade;
            this.reward = mgr.GetMonsterData(this.id).reward;
        }

        public void DisplayEnemyStatus()
        {
            Console.WriteLine("[Enemy Status]\n{0}\nHealth : {1}\nDamage : {2}",
                this.name, this.hp, this.damage);
        }
    }
}
