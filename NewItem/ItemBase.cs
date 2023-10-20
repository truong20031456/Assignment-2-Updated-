using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewItem
{
    abstract class ItemBase : Iitems
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ItemBase(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public void DisplayItempInfor()
        {
            Console.WriteLine($"Your information :{Name} ${Price}");
        }

    }

}
