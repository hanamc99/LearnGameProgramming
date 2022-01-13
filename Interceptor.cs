using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Interceptor : Unit
    {
        private int hp;
        private int damage;
        private string weapon;

        public Interceptor(string name) : base(name)
        {
            this.unitType = eUnitType.Interceptor;
            this.hp = 2;
            this.damage = 1;
            this.weapon = "machine gun";
        }

        public override void Attack(Unit attacker, ref Unit target, string weapon)
        {
            if(target != null)
            {
                base.Attack(this, ref target, this.weapon);
                target = target.Hit(this, this.damage, 1, "z", target);
            } else
            {
                Console.WriteLine("타겟이 존재하지 않습니다.");
            }
        }

        public override Unit Hit(Unit sender, int damage, int hp, string bloodColor, Unit target)
        {
            this.hp -= damage;
            base.Hit(sender, damage, this.hp, "z", target);
            if (this.hp > 0)
            {
                return this;
            }
            base.Destroy();
            return null;
        }
    }
}
