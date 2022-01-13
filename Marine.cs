using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Marine : Unit
    {
        public int hp;
        public int damage;
        private string bloodColor;
        private string weapon;

        public delegate void OnDieMarine();

        public OnDieMarine odm;

        

        public Marine(string name) : base(name){
            unitType = eUnitType.Marine;
        }

        public override void Init(Position posi)
        {
            base.Init(posi);
            this.weapon = "gun";
            this.bloodColor = "Red";
            this.hp = 4;
            this.damage = 1;
            Console.WriteLine("유닛 hp 상태 : {0},  유닛 공격력 : {1}\n", this.hp, this.damage);
        }

        public override void Attack(Unit attacker, ref Unit target, string weapon)
        {
            base.Attack(this, ref target, this.weapon);
            target.Hit(this, this.damage, 1, "z", target);
        }

        public override Unit Hit(Unit sender, int damage, int hp, string bloodColor, Unit target)
        {
            this.hp -= damage;
            base.Hit(sender, damage, this.hp, this.bloodColor, target);
            if (this.hp > 0)
            {
                return this;
            }
            base.Destroy();
            return null;
        }
    }
}
