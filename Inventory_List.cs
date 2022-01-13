using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Inventory_List
    {
        private List<Item> inventolist = new List<Item>();

        public Inventory_List()
        {
        }

        public void AddItem(Item item)
        {
            bool hasItem = false;
            foreach(Item search in inventolist)
            {
                if(search.GetWeaponName() == item.GetWeaponName())
                {
                    search.IncreaseItemCount();
                    hasItem = true;
                }
            }
            if (!hasItem)
            {
                inventolist.Add(new Item(item.GetWeaponName(), item.GetWeaponDamage()));
            }
        }

        public void PrintAllItems()
        {
            if(this.inventolist.Count > 0)
            {
                foreach (Item item in inventolist)
                {
                    Console.WriteLine("{0} x{1}", item.GetWeaponName(), item.GetWeaponCount());
                }
            } else
            {
                Console.WriteLine("   <<System>>");
                Console.WriteLine("보유한 아이템이 없습니다.");
            }
        }

        public int GetItemsCount()
        {
            return this.inventolist.Count;
        }

        public Item FindItemByName(string name)
        {
            foreach(Item item in inventolist)
            {
                if (item.GetWeaponName() == name)
                {
                    Item foundItem = item;
                    item.DecreaseItemCount();
                    if(item.GetWeaponCount() <= 0)
                    {
                        inventolist.Remove(item);
                    }
                    return foundItem;
                }
            }
            Console.WriteLine("   <<System>>");
            Console.WriteLine("{0} 미보유.", name);
            return null;
        }
    }
}
