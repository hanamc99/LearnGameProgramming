using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Zealot : Unit
    {
        public int hp;
        public int damage;
        private string bloodColor;
        private string weapon;
        private int shield;

        public Zealot(string name) : base(name)
        {
        }

        public override void Init(Position posi)
        {
            this.weapon = "Thorn";
            this.bloodColor = "Purple";
            this.hp = 5;
            this.damage = 2;
            this.pos = posi;
            Console.WriteLine("유닛 이름 : {0}\n유닛 hp 상태 : {1}\n유닛 공격력 : {2}", this.Name, this.hp, this.damage);
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

        public override void Move(Position posi)
        {
            Console.Write("{2}가 ({0}, {1})에서 ", this.pos.x, this.pos.y, this.Name);
            this.pos = posi;
            base.Move(pos);
        }
    }
}
