using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Item
    {
        private string itemName;
        private int count;
        private int damage;

        public Item(string name, int damage)
        {
            this.itemName = name;
            this.count = 1;
            this.damage = damage;
        }

        public void IncreaseItemCount()
        {
            this.count++;
        }

        public void DecreaseItemCount()
        {
            this.count--;
        }

        public int GetWeaponCount()
        {
            return this.count;
        }

        public int GetWeaponDamage()
        {
            return this.damage;
        }

        public string GetWeaponName()
        {
            return this.itemName;
        }
    }
}
