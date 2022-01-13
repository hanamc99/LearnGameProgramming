using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Adventurer
    {
        public int id;
        public string name;
        public float max_hp;
        public float hp;
        public int max_stamina;
        public int stamina;
        public int max_mana;
        public int mana;
        public int level;
        public int str;
        public int agi;
        public int inte;
        public int gold;

        public Adventurer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void Init()
        {
            this.max_hp = DataMgr.GetInstance().GetCharacterData(this.id).max_hp;
            this.hp = this.max_hp;
            this.max_stamina = DataMgr.GetInstance().GetCharacterData(this.id).max_stamina;
            this.stamina = this.max_stamina;
            this.max_mana = DataMgr.GetInstance().GetCharacterData(this.id).max_mana;
            this.mana = this.max_mana;
            this.level = 1;
            this.str = 0;
            this.agi = 0;
            this.inte = 0;
            this.gold = 0;
        }
    }
}
