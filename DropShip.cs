using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class DropShip : Unit
    {
        public int hp;
        public Unit[] loadingCell;

        public DropShip(string name) : base(name)
        {
            this.unitType = eUnitType.Machines;
        }

        public override void Init(Position posi)
        {
            base.Init(posi);
            this.hp = 8;
            this.loadingCell = new Unit[8];
        }

        public void Load(Unit unit)
        {
            if(unit != this)
            {
                if (this.pos.x == unit.pos.x && this.pos.y == unit.pos.y)
                {
                    int index;
                    for (index = 0; index < loadingCell.Length; index++)
                    {
                        if (loadingCell[index] == null)
                        {
                            break;
                        }
                    }
                    if (index == loadingCell.Length)
                    {
                        Console.WriteLine("수용량 포화!");
                        return;
                    }
                    loadingCell[index] = unit;
                    unit.isTakingDropship = true;
                    Console.WriteLine("{0}, {1} 탑승 완료", unit.Name, this.Name);
                }
                else
                {
                    Console.WriteLine("더 가까이 접근해야 합니다.");
                }
            } else
            {
                Console.WriteLine("자기 자신을 수송시킬 순 없습니다.");
            }
        }

        public void UnloadAll()
        {
            for(int i = 0; i < loadingCell.Length; i++)
            {
                if (loadingCell[i] != null)
                {
                    loadingCell[i].isTakingDropship = false;
                    loadingCell[i] = null;
                }
            }
        }

        public override void Move(Position posi)
        {
            base.Move(posi);
            foreach(Unit unit in loadingCell)
            {
                if(unit != null)
                {
                    unit.pos = this.pos;
                }
            }
        }

        public override void CheckPos()
        {
            base.CheckPos();
        }
    }
}
