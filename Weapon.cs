using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Weapon
    {
        public int id;
        public string name;
        public float damage;
        public int sellPrice;
        public int grade;
        public int reinforcement;
        public int durability;

        public Weapon(int id, string name, float damage, int price, int grade, int reinforcement, int durability)
        {
            this.id = id;
            this.name = name;
            this.sellPrice = price;
            this.grade = grade;
            this.reinforcement = reinforcement;
            this.damage = DataMgr.GetInstance().GetWeaponData(id).damage + (reinforcement - 1) * 1.5f;
            //this.damage = damage + reinforcement * 1 - 1; // 암시적으로 Weapon생성자가 호출되기 때문에 데미지가 계속해서 증가하는 문제가 있었다.
            this.durability = durability;
        }
    }
}
