using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class GameInfo// 게임 플레이의 모든 정보가 담긴 클래스, 이곳으로 접근해서 인벤토리, 스테이터스 창으로 분화된다.
    {
        public MapControl mapInfo;

        public Adventurer me;

        public Weapon[] startWeapon = new Weapon[2];

        public void CheckMyStatus()
        {
            Console.WriteLine("[Status]\n{0} Lv.{2}\n[Equipped Weapon] : {12}\n[Storing Weapon] : {13}\nHealth : {1} / {2}\nMana : {3} / {4}\nStamina : {5} / {6}\n\n[Ability Point]\nstr : {8}\nagi : {9}\nint : {10}\n\nGold : {11}",
                me.name, me.hp, me.max_hp, me.mana, me.max_mana, me.stamina, me.max_stamina, me.level, me.str, me.agi, me.inte, me.gold, startWeapon[0].name, startWeapon[1].name);
        }

        public void CheckWeaponStatus()
        {
            Console.WriteLine("[Equipped Weapon]\n{0} {1}단계 / 무기 공격력 : {2}(+{4}) / 아이템 가격 : {3}\n[Storing Weapon]\n" +
                "{5} {6}단계 / 무기 공격력 : {7}(+{9}) / 아이템 가격 : {8}", 
                startWeapon[0].name, startWeapon[0].reinforcement, DataMgr.GetInstance().GetWeaponData(startWeapon[0].id).damage, startWeapon[0].sellPrice,
                (startWeapon[0].reinforcement - 1) * 1.5f, startWeapon[1].name, startWeapon[1].reinforcement, DataMgr.GetInstance().GetWeaponData(startWeapon[1].id).damage, startWeapon[1].sellPrice,
                (startWeapon[1].reinforcement - 1) * 1.5f);
        }

        public int HowManyWeapon()
        {
            int count = 0;
            for(int i = 0; i < 2; i++)
            {
                if (this.startWeapon[i].name != "맨손" && this.startWeapon[i].name != "없음")
                {
                    count++;
                }
            }
            return count;
        }

        public void WeaponInit()
        {
            weapon_data data = DataMgr.GetInstance().GetWeaponData(8);
            this.startWeapon[0] = new Weapon(data.id, data.name, data.damage, data.sellPrice, data.grade, 1, 9999);
            weapon_data data2 = DataMgr.GetInstance().GetWeaponData(9);
            this.startWeapon[1] = new Weapon(data2.id, data2.name, data2.damage, data2.sellPrice, data2.grade, 1, 9999);
        }

        public void GetWeapon(Weapon weapon)
        {
            int n = HowManyWeapon();
            switch (n)
            {
                case 0:
                    this.startWeapon[1] = this.startWeapon[0];
                    this.startWeapon[0] = weapon;
                    break;
                case 1:
                    Console.WriteLine("교체할 무기를 선택해주세요.");
                    CheckWeaponStatus();
                    Console.WriteLine("0 -> {0}\n1 -> {1}", this.startWeapon[0].name, this.startWeapon[1].name);
                    string choice5 = Console.ReadLine();
                    int choice55;
                    int.TryParse(choice5, out choice55);
                    Console.WriteLine("{0}을 버리고 {1}을 획득했습니다.", this.startWeapon[choice55].name, weapon.name);
                    this.startWeapon[choice55] = weapon;
                    CheckWeaponStatus();
                    break;
                case 2:
                    Console.WriteLine("교체할 무기를 선택해주세요.");
                    CheckWeaponStatus();
                    Console.WriteLine("0 -> {0}\n1 -> {1}", this.startWeapon[0].name, this.startWeapon[1].name);
                    string choice4 = Console.ReadLine();
                    int choice44;
                    int.TryParse(choice4, out choice44);
                    Console.WriteLine("{0}을 버리고 {1}을 획득했습니다.", this.startWeapon[choice44].name, weapon.name);
                    this.startWeapon[choice44] = weapon;
                    CheckWeaponStatus();
                    break;
            }
        }

        public void WeaponBreak()
        {
            int n = HowManyWeapon();
            switch (n)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("{0}이(가) 파괴되어 {1}를 사용합니다.", this.startWeapon[0].name, this.startWeapon[1].name);
                    this.startWeapon[0] = this.startWeapon[1];
                    weapon_data data2 = DataMgr.GetInstance().GetWeaponData(9);
                    this.startWeapon[1] = new Weapon(data2.id, data2.name, data2.damage, data2.sellPrice, data2.grade, 1, 9999);
                    CheckWeaponStatus();
                    break;
                case 2:
                    Console.WriteLine("{0}이(가) 파괴되어 {1}를 사용합니다.", this.startWeapon[0].name, this.startWeapon[1].name);
                    this.startWeapon[0] = this.startWeapon[1];
                    weapon_data data = DataMgr.GetInstance().GetWeaponData(8);
                    this.startWeapon[1] = new Weapon(data.id, data.name, data.damage, data.sellPrice, data.grade, 1, 9999);
                    CheckWeaponStatus();
                    break;
            }
        }


        public void SwitchWeapon()
        {
            if(HowManyWeapon() > 0)
            {
                Console.WriteLine("{0} 수납, {1} 장착", this.startWeapon[0].name, this.startWeapon[1].name);
                Weapon weapon = this.startWeapon[0];
                this.startWeapon[0] = this.startWeapon[1];
                this.startWeapon[1] = weapon;
                CheckWeaponStatus();
            } else
            {
                Console.WriteLine("교체할 무기가 없습니다.");
            }
        }
    }
}
