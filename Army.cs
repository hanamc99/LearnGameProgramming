using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Army
    {
        public Unit[] armies;
        
        public Army(int index)
        {
            armies = new Unit[index];
        }

        public void AddUnit(Unit unit)
        {
            int index;
            for (index = 0; index < armies.Length; index++)
            {
                if (armies[index] == null)
                {
                    break;
                }
            }
            if (index == armies.Length)
            {
                Console.WriteLine("부대 통솔력 부족");
                return;
            }
            armies[index] = unit;
        }

        public void CallAllSoldiers()
        {
            foreach(Unit army in armies)
            {
                if(army != null)
                {
                    Console.WriteLine("유닛의 타입 : {0}, 유닛의 네임 : {1}\n", army.unitType, army.Name);
                }
            }
        }

        public int GetCount()
        {
            int i = 0;
            foreach (Unit unit in armies)
            {
                if (unit != null)
                {
                    i++;
                }
            }
            return i;
        }

        public int GetMarinesCount()
        {
            int i = 0;
            foreach (Unit unit in armies)
            {
                if (unit != null)
                {
                    if(unit.unitType == eUnitType.Marine)
                    {
                        i++;
                    }
                }
            }
            return i;
        }

        public int GetZerglingCount()
        {
            int i = 0;
            foreach (Unit unit in armies)
            {
                if (unit != null)
                {
                    if (unit.unitType == eUnitType.Zergling)
                    {
                        i++;
                    }
                }
            }
            return i;
        }

        public Unit[] GetMarines()
        {
            int i = 0;
            Unit[] marines = new Unit[GetMarinesCount()];
            foreach (Unit unit in armies)
            {
                if (unit != null)
                {
                    if (unit.unitType == eUnitType.Marine)
                    {
                        marines[i++] = unit;
                    }
                }
            }
            return marines;
        }

        public Unit[] GetZergling()
        {
            int i = 0;
            Unit[] zergling = new Unit[GetZerglingCount()];
            foreach (Unit unit in armies)
            {
                if (unit != null)
                {
                    if (unit.unitType == eUnitType.Zergling)
                    {
                        zergling[i++] = unit;
                    }
                }
            }
            return zergling;
        }
    }
}
