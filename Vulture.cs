using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Vulture : Unit
    {
        public int hp;
        private List<Mine> mines;
        private int minesCapacity;
        private int damage;
        private string weapon;
        private string bloodColor;

        public Vulture(string name) : base(name){}

        public override void Init(Position posi)
        {
            this.unitType = eUnitType.Machines;
            base.Init(posi);
            this.bloodColor = "Purple";
            this.weapon = "machine gun";
            this.hp = 3;
            this.damage = 2;
            this.mines = new List<Mine>();
            mines.Add(new Mine());
            mines.Add(new Mine());
            mines.Add(new Mine());
            minesCapacity = mines.Count;
            Console.WriteLine("유닛 이름 : {0}\n유닛 hp 상태 : {1}\n유닛 공격력 : {2}\n보유 마인 갯수 : {3}/{4}\n", this.Name, this.hp, this.damage, this.mines.Count, this.minesCapacity);
        }

        public override void Attack(Unit attacker, ref Unit target, string weapon)
        {
            base.Attack(this, ref target, this.weapon);
            target = target.Hit(this, this.damage, 1, "z", target);
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
            base.Move(posi);
        }

        public Mine InstallMine()
        {
            if(mines.Count > 0)
            {
                mines[0].MineInstalled(this.pos);
                Mine mine = mines[0];
                mines.RemoveAt(0);
                Console.WriteLine("현재 마인 갯수 : {0}/{1}\n", this.mines.Count, this.minesCapacity);
                return mine;
            }

            Console.WriteLine("보유 마인 부족.\n");
            return null;
        }

        public override void CheckPos()
        {
            base.CheckPos();
        }
    }
}
