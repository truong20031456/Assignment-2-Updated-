using System.ComponentModel;

namespace NewItem
{
    internal class Program
    {
        class Book : ItemBase
        {
           public string Title { get; set; }
            public Book (string name ,double price,string title):base (name,price)
            {
                Title = name;
            }

            public void DisplayItemInfor()
            {
                Console.WriteLine("Name" + Name + " Title" + Title+ "Price" + Price);

            }

        }
        class ElectronicDevice : ItemBase
        {
            public string Status { get; set; }
            public ElectronicDevice(string name, double price, string status) : base(name, price)
            {
                Status = status;
            }

            public void DisplayItemInfor()
            {
                Console.WriteLine("Name" + Name + " Title" + Status + "Price" + Price);

            }

        }
        class Clothing  : ItemBase
        {
            public string gender { get; set; }
            public Clothing(string name, double price, string gender) : base(name, price)
            {
                this.gender = gender;
            }

            public void DisplayItemInfor()
            {
                Console.WriteLine("Name" + Name + " Title" + gender + "Price" + Price);

            }

        }
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            // Creating instances of different items
            Iitems book = new Book("Book 1", 19.99,"C#");
            Iitems device = new ElectronicDevice("Laptop", 999.99,"Good");
           Iitems clothing = new Clothing("T-Shirt", 12.99, "Male");
            // Adding items to the inventory
           
            inventory.AddItem((ItemBase)book);
            inventory.AddItem((ItemBase)device);
            inventory.AddItem((ItemBase)clothing);
            // Displaying inventory contents
            inventory.DisplayAllItems();
            // Removing an item from the inventory
            inventory.RemoveItem((ItemBase)book);
            // Displaying updated inventory
            inventory.DisplayAllItems();
        }
    }
}