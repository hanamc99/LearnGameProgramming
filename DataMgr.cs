using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace helloworldConsoleApp1
{
    class DataMgr
    {
        private static DataMgr instance;

        public bool dead = false;
        public bool TurnOn = true;

        private const string Datas_Path = "./Datas";
        private const string GAME_INFO_PATH = "game_info.json";
        private const string WEAPON_DATA_PATH = "weapon_data2.json";
        private const string CHARACTER_DATA_PATH = "character_data.json";
        private const string MONSTER_DATA_PATH = "monster_data.json";

        public GameInfo gi;

        private Dictionary<int, weapon_data> dictWeaponData = new Dictionary<int, weapon_data>();
        private Dictionary<int, Character_data> dictCharacterData = new Dictionary<int, Character_data>();
        private Dictionary<int, Monster_data> dictMonsterData = new Dictionary<int, Monster_data>();

        public void LoadData()
        {
            string path = string.Format("{0}/{1}", Datas_Path, WEAPON_DATA_PATH);
            string json = File.ReadAllText(path);
            this.dictWeaponData = JsonConvert.DeserializeObject<weapon_data[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", Datas_Path, CHARACTER_DATA_PATH);
            json = File.ReadAllText(path);
            this.dictCharacterData = JsonConvert.DeserializeObject<Character_data[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", Datas_Path, MONSTER_DATA_PATH);
            json = File.ReadAllText(path);
            this.dictMonsterData = JsonConvert.DeserializeObject<Monster_data[]>(json).ToDictionary(x => x.id);

            /*string getWeaponsJson = File.ReadAllText(WEAPON_DATA_PATH);

            weapon_data[] weapons = JsonConvert.DeserializeObject<weapon_data[]>(getWeaponsJson);

            foreach (weapon_data weapon in weapons)
            {
                dict.Add(weapon.id, weapon);
            }*/
        }

        public void DiscernUserType()
        {
            if (File.Exists(GAME_INFO_PATH))
            {
                Console.WriteLine("기존 유저입니다.");
                string getJson = File.ReadAllText(GAME_INFO_PATH);
                this.gi = JsonConvert.DeserializeObject<GameInfo>(getJson);
                this.gi.CheckWeaponStatus();
                this.gi.CheckMyStatus();
            } else
            {
                Console.WriteLine("신규 유저입니다.");
                this.gi = new GameInfo();
                this.gi.mapInfo = new MapControl();
                this.gi.mapInfo.Init();
                Console.WriteLine("");
                Console.WriteLine("당신은 누구인가요?");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("\n{0} => {1}", i, GetCharacterData(i).name);
                }
                Console.WriteLine("");
                string choice = Console.ReadLine();
                int choice2 = Convert.ToInt32(choice);
                Console.WriteLine("");
                Character_data charData = GetCharacterData(choice2);
                this.gi.me = new Adventurer(charData.id, charData.name);
                this.gi.me.Init();
                Console.WriteLine("{0}를 결정하셨습니다.", this.gi.me.name);
                Console.WriteLine("신규 유저를 위해 5단계 무기를 지급했습니다.");
                weapon_data data = GetWeaponData(charData.default_weapon_id);
                Weapon startWeapon = new Weapon(data.id, data.name, data.damage, data.sellPrice, data.grade, 5);;
                this.gi.EquipWeapon(startWeapon);
                this.gi.CheckWeaponStatus();
                this.gi.CheckMyStatus();
                gi.mapInfo.mapIndex = 1;

                string saveJson = JsonConvert.SerializeObject(this.gi);
                File.WriteAllText(GAME_INFO_PATH, saveJson);
            }
        }

        public void SaveData()
        {
            Console.WriteLine("데이터를 저장했습니다.");
            string saveJson = JsonConvert.SerializeObject(this.gi);
            File.WriteAllText(GAME_INFO_PATH, saveJson);
        }

        public Character_data GetCharacterData(int id)
        {
            return dictCharacterData[id];
        }

        public Monster_data GetMonsterData(int id)
        {
            return dictMonsterData[id];
        }

        public weapon_data GetWeaponData(int id)
        {
            return dictWeaponData[id];
        }

        public static DataMgr GetInstance()
        {
            if(DataMgr.instance == null)
            {
                DataMgr.instance = new DataMgr();
            }
            else
            {
            }
            return DataMgr.instance;
        }
    }
}
