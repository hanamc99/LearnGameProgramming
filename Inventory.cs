using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Inventory
    {
        public Item[] inventory;

        public Inventory(int index)
        {
            inventory = new Item[index];
            Console.WriteLine("인벤토리에 {0}칸이 있습니다.", index);
        }

        public void AddItem(Item item)
        {
            int index;
            for(index = 0; index < inventory.Length; index++)
            {
                if(inventory[index] == null)
                {
                    break;
                }
            }
            if(index == inventory.Length)
            {   
                Console.WriteLine("인벤토리 칸 부족!");
                return;
            }
            inventory[index] = item;
        }

        public int GetCount()
        {
            int i = 0;
            foreach(Item item in inventory)
            {
                if(item != null)
                {
                    i++;
                }
            }
            return i;
        }

        public Item FindItemByName(string name)
        {
            Item foundItem = null;
            foreach(Item item in inventory)
            {
                if (item != null)
                {
                    if (item.GetWeaponName() == name)
                    {
                        foundItem = item;
                        return foundItem;
                    }
                }
            }
            Console.WriteLine("{0} 미보유", name);
            return null;
        }
    }
}
