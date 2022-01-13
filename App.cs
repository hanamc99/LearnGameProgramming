using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace helloworldConsoleApp1
{
    class App
    {
        /*public App()
        {
            Console.WriteLine("********************");
            Console.WriteLine("*****Diablo ll******");
            Console.WriteLine("********************");
            Console.WriteLine("********************");
        }*/

        public App()
        {
            DataMgr mgr = DataMgr.GetInstance();
            mgr.LoadData();
            mgr.DiscernUserType();

            while (!mgr.dead)
            {
                GoWhere(mgr.gi.mapInfo.mapIndex);
                if (mgr.dead)
                {
                    mgr.dead = false;
                    mgr.DiscernUserType();
                }
            }
            mgr.gi.CheckMyStatus();
            mgr.gi.CheckWeaponStatus();
            if (!mgr.dead)
            {
                mgr.SaveData();
            }
        }

        public void GoWhere(int i)
        {
            switch (i)
            {
                case 1:
                    Smithy sm = new Smithy();
                    break;
                case 2:
                    OpenField1 op = new OpenField1();
                    break;
            }
        }

        /*public Dictionary<int, weapon_data> dict = new Dictionary<int, weapon_data>();

        public App()
        {
            string json = File.ReadAllText("./weapon_data.json");
            Console.WriteLine(json);

            weapon_data[] weapons = JsonConvert.DeserializeObject<weapon_data[]>(json);
            Console.WriteLine(weapons.Length);

            foreach(weapon_data weapon in weapons)
            {
                dict.Add(weapon.id, weapon);
            }

            Console.WriteLine(dict[2].name);
        }

        /*
        private Dictionary<int, string> dict_Favorite_people = new Dictionary<int, string>();

        public App()
        {
            string json = File.ReadAllText("./favorite_list.json");
            Console.WriteLine(json);

            Favorite_people_data[] favorites = JsonConvert.DeserializeObject<Favorite_people_data[]>(json);
            Console.WriteLine(favorites.Length);

            foreach(Favorite_people_data favorite in favorites)
            {
                dict_Favorite_people.Add(favorite.id, favorite.name);
            }

            Console.WriteLine(dict_Favorite_people[4]);
        }

        /*private Dictionary<int, Item_data> dict;

        public App()
        {
            string json = File.ReadAllText("./item_data.json");
            Console.WriteLine(json);

            Item_data[] itemDatas = JsonConvert.DeserializeObject<Item_data[]>(json);

            Console.WriteLine(itemDatas.Length);

            dict = new Dictionary<int, Item_data>();
        }


        /*public Dictionary<int, string> inventory = new Dictionary<int, string>();

        public App()
        {
            inventory.Add(100, "그레이트 소드");
            inventory.Add(101, "정밀한 단도");
            inventory.Add(102, "나무활");

            foreach(KeyValuePair<int, string> i in inventory)
            {
                Console.WriteLine(i.Key);
            }

            for(int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(inventory[100 + i]);
            }
        }

        /*public App()
        {
            HighTempler ht1 = new HighTempler();
            HighTempler ht2 = new HighTempler();
            MergeToArchon(ref ht1, ref ht2, (x) => { Console.WriteLine(x); Console.WriteLine(x.name); });
        }

        public void MergeToArchon(ref HighTempler ht1, ref HighTempler ht2, Action<Archon> archon)
        {
            ht1 = null;
            ht2 = null;
            archon(new Archon("첫번째 아칸"));
        }

        /*public App()
        {
            App2 btn = new App2();
            btn.action1 = () => Console.WriteLine("버튼이 눌렸습니다.");    
            btn.Clicked();
            btn.Clicked();
            btn.Clicked();
            btn.Clicked();
        }

        /*public void Method1(string message, ref int i) { Console.WriteLine(message); i++; }
        public void Method2(string message, ref int i) { Console.WriteLine(message); i++; }
        /*public App()
        {
            Nuclear nc = new Nuclear();
            nc.AlertMessages += nc.StartCountDown;
            nc.AlertMessages += new Nuclear.DelAlertMessage(nc.CountingSeconds);
            nc.AlertMessages += nc.NuclearLaunchDetected;
            nc.LaunchNuclearMissile();
        }

        /*public App()
        {
            Barrack br = new Barrack();
            Marine mar = br.CreateSoldierUnit(br.CreateMarine, "첫번째 마린");
            mar.Init(new Position(2,2));
        }



        /*public App()
        {
            Console.WriteLine("앱 클래스 생성");

            Unit marine = new Marine("을");//hp 4
            marine.Init(new Position(2, 3));
            
            Unit zerg = new Zergling("갑");//damage 1
            zerg.Init(new Position(5, 5));
            
            Marine downCastedMarine = (Marine)marine;
            downCastedMarine.odm = new Marine.OnDieMarine(OnDie);
            downCastedMarine.odm += new Marine.OnDieMarine(OnDie);

            Marine.OnDieMarine oodm = OnDie;

            zerg.Attack(zerg, ref marine, "claw");
            zerg.Attack(zerg, ref marine, "claw");
            zerg.Attack(zerg, ref marine, "claw");
            zerg.Attack(zerg, ref marine, "claw");
            
            if(downCastedMarine.hp <= 0)
            {
                downCastedMarine.odm();
                oodm();
            }
        }

        public void OnDie()
        {
            Console.WriteLine("마린이 죽었습니다.");
        }*/
    }
}
