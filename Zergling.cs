using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Zergling : Unit
    {
        private string bloodColor;
        private string weapon;
        private int hp;
        public int damage;

        public Zergling(string name) : base(name){
            unitType = eUnitType.Zergling;
        }

        public override void Init(Position posi)
        {
            base.Init(posi);
            this.weapon = "Claw";
            this.bloodColor = "Green";
            this.hp = 2;
            this.damage = 1;
            this.pos = posi;
            Console.WriteLine("유닛 hp 상태 : {0}\n유닛 공격력 : {1}\n", this.hp, this.damage);
        }

        public override void Attack(Unit attacker, ref Unit target, string weapon)
        {
            Console.WriteLine("{0}이 {1}을 {2}으로 공격합니다.", Name, target.Name, weapon);
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
