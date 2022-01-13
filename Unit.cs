using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Unit
    {
        public eUnitType unitType = eUnitType.None;
        public Position pos;
        public bool isTakingDropship = false;

        public string Name
        {
            get;
            private set;
        }

        public Unit(string name)
        {
            this.Name = name;
        }

        virtual public void Attack(Unit attacker, ref Unit target, string weapon)
        {
            Console.WriteLine("{0}이(가) {1}을(를) {2}으로 공격합니다.", attacker.Name, target.Name, weapon);
        }

        virtual public void Move(Position posi)
        {
            if (!isTakingDropship)
            {
                Console.WriteLine("{4}가 ({0}, {1})에서 ({2}, {3})으로 이동합니다.\n", this.pos.x, this.pos.y, posi.x, posi.y, this.Name);
                this.pos = posi;
            }
            else
            {
                Console.WriteLine("해당 유닛은 현재 드랍십 탑승 중입니다.");
            }
        }

        virtual public void CheckPos(){
            Console.WriteLine("현재 위치는 ({0}, {1})입니다.\n", this.pos.x, this.pos.y);
        }

        virtual public Unit Hit(Unit sender, int damage, int hp, string bloodColor, Unit target)
        {
            if(this.unitType != eUnitType.Marine && this.unitType != eUnitType.Zergling)
            {
                Console.WriteLine("{3}이(가) {0}에게 공격당해 {1}의 피해를 입었습니다. 현재 기체 내구도는 {2}입니다.", sender.Name, damage, hp, target.Name);
                return this;
            }
            Console.WriteLine("{4}이(가) {0}에게 공격당해 {3}색의 피를 흘리고 {1}의 피해를 입었습니다. 현재 생명력 상태는 {2}입니다.", sender.Name, damage, hp, bloodColor, target.Name);
            return this;
        }

        virtual public void Init(Position posi)
        {
            this.pos = posi;
            Console.WriteLine("유닛 이름 : {0}\n유닛 위치 : ({1}, {2})", this.Name, this.pos.x, this.pos.y);
        }

        virtual public void Destroy()
        {
            Console.WriteLine("{0} {1} destroyed.", this.unitType, this.Name);
        }
    }
}
