using System;

namespace helloworldConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new App();


            /*Hero knight = new Hero("김봉식");

            knight.AddItemToInventory(new Item("정밀한 단도", 3));
            knight.AddItemToInventory(new Item("정밀한 단도", 3));
            knight.AddItemToInventory(new Item("그레이트 소드", 3));
            knight.AddItemToInventory(new Item("그레이트 소드", 3));
            knight.AddItemToInventory(new Item("떡갈나무 지팡이", 3));
            knight.PrintInventory();
            knight.EquipWeapon("정밀한 단도");
            knight.PrintInventory();
            knight.UnEquipWeapon();
            knight.PrintInventory();

            /*arrier carrier = new Carrier("캐리어");
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();

            Unit vulture_Unit = new Vulture("벌쳐1");
            vulture_Unit.Init(new Position(2,3));

            Unit itct0 = carrier.interceptorRoom[0];
            vulture_Unit.Attack(vulture_Unit, ref itct0, "zdxv");
            carrier.interceptorRoom[0] = (Interceptor)itct0;
            carrier.BuildInterceptor();

            carrier.DestroyInterceptors();
            carrier.BuildInterceptor();
            carrier.BuildInterceptor();

            carrier.Attack(carrier, ref vulture_Unit, "z");


            /*Army army = new Army(11);
            Marine mar0 = new Marine("해리");
            Marine mar1 = new Marine("론");
            Marine mar2 = new Marine("헤르마오니");
            army.AddUnit(mar0);
            army.AddUnit(mar1);
            army.AddUnit(mar2);
            
            //캡슐화 
            //army.armies[0].Init(new Position(2, 3));
            //var unit = army.GetUnit(0);
            //unit.Init(new Position(2, 3));

            Zergling zerg0 = new Zergling("볼드");
            Zergling zerg1 = new Zergling("모르");
            Zergling zerg2 = new Zergling("모트");
            Zergling zerg3 = new Zergling("모모");
            Zergling zerg4 = new Zergling("모비");
            Zergling zerg5 = new Zergling("모스");
            Zergling zerg6 = new Zergling("모기");
            army.AddUnit(zerg0);
            army.AddUnit(zerg1);
            army.AddUnit(zerg2);
            army.AddUnit(zerg3);
            army.AddUnit(zerg4);
            army.AddUnit(zerg5);
            army.AddUnit(zerg6);

            DropShip ship0 = new DropShip("무궁화호");
            ship0.Init(new Position(1, 1));

            foreach (Unit unit in army.armies)
            {
                if (unit != null)
                {
                    unit.Init(new Position(5, 5));
                    ship0.Load(unit);
                }
            }
            
            ship0.Move(new Position(5, 5));
            
            foreach (Unit unit in army.armies)
            {
                if (unit != null)
                    ship0.Load(unit);
            }

            ship0.Move(new Position(9, 9));

            foreach (Unit unit in army.armies)
            {
                if (unit != null)
                    unit.CheckPos();
            }

            ship0.UnloadAll();
            ship0.Move(new Position(0, 0));
            
            foreach (Unit unit in army.armies)
            {
                if (unit != null)
                    unit.CheckPos();
            }

            foreach (Unit unit in army.armies)
            {
                if (unit != null)
                {
                    unit.Move(new Position(2, 5));
                    ship0.Load(unit);
                }
            }

            /*army.CallAllSoldiers();

            Console.WriteLine("\n마린과 저글링을 포함한 모든 유닛 호출 됨.\n\n");

            Army marines = new Army(army.GetMarinesCount());
            marines.armies = army.GetMarines();
            marines.CallAllSoldiers();

            Console.WriteLine("\n마린들만 호출 됨.\n\n");

            Army zerglings = new Army(army.GetZerglingCount());
            zerglings.armies = army.GetZergling();
            zerglings.CallAllSoldiers();

            Console.WriteLine("\n저글링들만 호출 됨.\n\n");

            Console.WriteLine(marines.GetCount());
            Console.WriteLine(marines.GetMarinesCount());
            Console.WriteLine(marines.GetZerglingCount());
            Console.WriteLine(zerglings.GetCount());
            Console.WriteLine(zerglings.GetZerglingCount());
            Console.WriteLine(zerglings.GetMarinesCount());


            /*Inventory inven = new Inventory(5);
            Item item0 = new Item("그레이트 소드");
            Item item1 = new Item("정밀한 단도");
            inven.AddItem(item0);
            inven.AddItem(item1);
            foreach (Item item in inven.inventory)
            {
                if (item == null)
                {
                    Console.WriteLine("=>");
                    continue;
                }
                Console.WriteLine("=> {0}", item.itemName);
            }

            Console.WriteLine(inven.GetCount());

            Item findItem = inven.FindItemByName("정밀한 도");
            if (findItem != null)
            {
                Console.WriteLine(findItem.itemName);
            }


            /*Item[] inventory = new Item[5];
            Item item0 = new Item("그레이트 소드");
            Console.WriteLine("{0}", item0.itemName);
            inventory[0] = item0;
            for(int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    Console.WriteLine("=> {0}", inventory[i].itemName);
                }
                else
                {
                    Console.WriteLine("=>");
                }

            }
            Console.WriteLine("");
            foreach(Item item in inventory)
            {
                if(item == null)
                {
                    Console.WriteLine("=>");
                    continue;
                }
                Console.WriteLine("=> {0}", item.itemName);
            }

            /*arine mar1 = new Marine("갑");
            mar1.Init(new Position(6, 4));
            Zergling mar2 = new Zergling("을");
            mar2.Init(new Position(7, 7));
            Vulture vulture = new Vulture("병");
            vulture.Init(new Position(2, 1));
            Zealot zealot = new Zealot("정");
            zealot.Init(new Position(4, 4));
            mar1.Attack(mar1, mar2, "d");
            vulture.Move(new Position(5, 5));
            Mine mine = vulture.InstallMine(); 
            vulture.CheckPos();
            vulture.Move(new Position(10, 15));
            zealot.Move(new Position(5, 5));
            if (zealot.pos.x == mine.pos.x && zealot.pos.y == mine.pos.y)
            {
                zealot.hp -= mine.Explode();
                Console.WriteLine("{0}의 남은 체력 : {1}\n", zealot.Name, zealot.hp);
            }*/
        }
    }
}
