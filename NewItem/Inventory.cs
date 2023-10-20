using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewItem
{
    internal class Inventory 
    {
       
        private List<ItemBase> items;

        public Inventory()
        {
            items = new List<ItemBase>();
        }

        public void AddItem(ItemBase item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} has been added to the inventory.");
        }

        public void RemoveItem(ItemBase item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item.Name} has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"{item.Name} is not in the inventory.");
            }
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("Items in the inventory:");
            foreach (var item in items)
            {
                item.DisplayItempInfor();
            }
        }
    }
}
