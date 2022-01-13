using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class GameInfo// 게임 플레이의 모든 정보가 담긴 클래스, 이곳으로 접근해서 인벤토리, 스테이터스 창으로 분화된다.
    {
        public MapControl mapInfo;

        public Adventurer me;

        public Weapon startWeapon;

        public void CheckMyStatus()
        {
            Console.WriteLine("[Status]\n{0} Lv.{7}\nHealth : {1} / {2}\nMana : {3} / {4}\nStamina : {5} / {6}\n\n[Ability Point]\nstr : {8}\nagi : {9}\nint : {10}\n\nGold : {11}",
                me.name, me.hp, me.max_hp, me.mana, me.max_mana, me.stamina, me.max_stamina, me.level, me.str, me.agi, me.inte, me.gold);
        }

        public void CheckWeaponStatus()
        {
            Console.WriteLine("{0} {1}단계 / 무기 공격력 : {2}(+{4}) / 아이템 가격 : {3}", 
                startWeapon.name, startWeapon.reinforcement, DataMgr.GetInstance().GetWeaponData(startWeapon.id).damage, startWeapon.sellPrice, (startWeapon.reinforcement - 1) * 1.5f);
        }

        public void EquipWeapon(Weapon weapon)
        {
            this.startWeapon = weapon;
        }
    }
}
