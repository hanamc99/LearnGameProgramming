using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Hero
    {
        private Inventory_List inventory = new Inventory_List();
        private int hp;
        private int damage;
        private Item weapon;
        private string name;

        public Hero(string name)
        {
            this.name = name;
            weapon = new Item("맨손", 0);
            hp = 50;
            damage = 2;
            this.PrintStatus();
        }

        public void PrintStatus()
        {
            Console.WriteLine(" [스테이터스 창]");
            Console.WriteLine("기사의 이름은 {0}, {1}의 체력과 {2}의 공격력을 가지고 있다.", this.name, this.hp, this.GetDamage());
        }

        public void AddItemToInventory(Item item)
        {
            inventory.AddItem(item);
            Console.WriteLine("   <<System>>");
            Console.WriteLine("인벤토리에 {0} 아이템이 추가되었습니다.", item.GetWeaponName());
        }

        public void EquipWeapon(string name)
        {
            Item item = inventory.FindItemByName(name);
            if(item != null)
            {
                this.weapon = item;
                Console.WriteLine("   <<System>>");
                Console.WriteLine("{0}이 {1}을 장착했습니다. 현재 공격력 : {2}", this.name, this.weapon.GetWeaponName(), this.GetDamage());
            }
        }

        public void UnEquipWeapon()
        {
            if(this.weapon.GetWeaponName() != "맨손")
            {
                inventory.AddItem(this.weapon);
                Console.WriteLine("   <<System>>");
                Console.WriteLine("{0}이 {1}을 장착해제했습니다.", this.name, this.weapon.GetWeaponName());
                this.weapon = new Item("맨손", 0);
            } else
            {
                Console.WriteLine("   <<System>>");
                Console.WriteLine("장착 중인 무기가 없습니다.");
            }
        }

        private int GetDamage()
        {
            return this.weapon.GetWeaponDamage() + this.damage;
        }

        public void PrintInventory()
        {
            Console.WriteLine(" [인벤토리]");
            inventory.PrintAllItems();
        }
    }
}
