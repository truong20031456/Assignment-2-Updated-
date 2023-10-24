namespace Assignment_2_Update
{
  
    
       public class Price
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }

    public abstract class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Price ProductPrice { get; set; }

        public abstract string GetProductType();
    }

    public class ConcreteProduct : Product
    {
        public override string GetProductType()
        {
            return "Concrete Product";
        }
    }

    public abstract class ProductFactory
    {
        public abstract Product CreateProduct(int productID, string productName, Price productPrice);
    }

    public class ConcreteProductFactory : ProductFactory
    {
        public override Product CreateProduct(int productID, string productName, Price productPrice)
        {
            return new ConcreteProduct { ProductID = productID, ProductName = productName, ProductPrice = productPrice };
        }
    }

    public class Cart
    {
        public List<Product> CartItems { get; } = new List<Product>();

        public void AddProduct(Product product)
        {
            CartItems.Add(product);
            Console.WriteLine($"Product '{product.ProductName}' added to the cart.");
        }

        public void RemoveProduct(Product product)
        {
            CartItems.Remove(product);
        }

        public void ShowCart()
        {
            Console.WriteLine("Items in your cart:");
            foreach (Product product in CartItems)
            {
                Console.WriteLine($"{product.ProductName} - {product.ProductPrice}");
            }
        }
    }

    public class User
    {
        public Cart Cart { get; } = new Cart();

        // Số lượng sản phẩm trong giỏ hàng
        private int CartItemCount => Cart.CartItems.Count;

        public void ViewProducts(List<Product> products)
        {
            Console.WriteLine("Viewing available products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.ProductPrice}");
            }
        }

        public void ViewCart()
        {
            Cart.ShowCart();
            // Kiểm tra số lượng sản phẩm trong giỏ hàng và áp dụng giảm giá nếu cần
            if (CartItemCount >= 2)
            {
                ApplyDiscount();
            }
        }

        public void AddProductToCart(Product product)
        {
            Cart.AddProduct(product);
            Console.WriteLine($"Product '{product.ProductName}' added to the cart.");
            // Kiểm tra số lượng sản phẩm trong giỏ hàng và áp dụng giảm giá nếu cần
            if (CartItemCount >= 2)
            {
                ApplyDiscount();
            }
        }

        // Phương thức áp dụng giảm giá 10%
        private void ApplyDiscount()
        {
            double totalAmount = 0;
            foreach (var product in Cart.CartItems)
            {
                totalAmount += product.ProductPrice.Amount;
            }
            // Giảm giá 10%
            double discountAmount = totalAmount * 0.1;
            double discountedTotal = totalAmount - discountAmount;
            Console.WriteLine($"Discount Applied: 10% off. New Total: {discountedTotal} {Cart.CartItems[0].ProductPrice.Currency}");
        }
    }

    public class Admin
    {
        public Product CreateProduct(ProductFactory productFactory, List<Product> products, int productID, string productName, Price productPrice)
        {
            var product = productFactory.CreateProduct(productID, productName, productPrice);
            products.Add(product);
            Console.WriteLine($"Product '{product.ProductName}' created and added to inventory. Product Type: {product.GetProductType()}");
            return product;
        }

        public void UpdateProduct(Product product, string newName, Price newPrice)
        {
            product.ProductName = newName;
            product.ProductPrice = newPrice;
            Console.WriteLine($"Product '{product.ProductName}' updated.");
        }

        public void DeleteProduct(List<Product> products, Product product)
        {
            products.Remove(product);
            Console.WriteLine($"Product '{product.ProductName}' deleted from inventory.");
        }

        public void ViewInventory(List<Product> products)
        {
            Console.WriteLine("Viewing inventory:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.ProductPrice}");
            }
        }
    }

    public class Supplier
    {
        public void UpdateProduct(Product product, string newName, Price newPrice)
        {
            product.ProductName = newName;
            product.ProductPrice = newPrice;
            Console.WriteLine($"Product '{product.ProductName}' updated in supplier's inventory.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ConcreteProductFactory();
            List<Product> products = new List<Product>();

            Console.WriteLine("Welcome to the Product Management System!");
            User user = new User();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. User - View Products");
                Console.WriteLine("2. User - Add Product to Cart");
                Console.WriteLine("3. User - View Cart");
                Console.WriteLine("4. Admin - Create Product");
                Console.WriteLine("5. Admin - Update Product");
                Console.WriteLine("6. Admin - Delete Product");
                Console.WriteLine("7. Admin - View Inventory");
                Console.WriteLine("8. Supplier - Update Product");
                Console.WriteLine("9. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        user.ViewProducts(products);
                        break;

                    case 2:
                        if (products.Count > 0)
                        {
                            Console.Write("Enter the product index to add to the cart: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index >= 0 && index < products.Count)
                            {
                                user.AddProductToCart(products[index]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid product index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products available to add to the cart.");
                        }
                        break;

                    case 3:

                        user.ViewCart();
                        break;

                    case 4:
                        Admin admin = new Admin();
                        Console.Write("Enter product ID: ");
                        int productID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter product name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter product price amount: ");
                        double priceAmount = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter product price currency: ");
                        string priceCurrency = Console.ReadLine();
                        Price productPrice = new Price(priceAmount, priceCurrency);
                        admin.CreateProduct(productFactory, products, productID, productName, productPrice);
                        break;

                    case 5:
                        if (products.Count > 0)
                        {
                            Console.Write("Enter the product index to update: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index >= 0 && index < products.Count)
                            {
                                Console.Write("Enter the new product name: ");
                                string newName = Console.ReadLine();
                                Console.Write("Enter the new product price amount: ");
                                double newPriceAmount = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter the new product price currency: ");
                                string newPriceCurrency = Console.ReadLine();
                                Price newPrice = new Price(newPriceAmount, newPriceCurrency);

                                Admin admin2 = new Admin();
                                admin2.UpdateProduct(products[index], newName, newPrice);
                            }
                            else
                            {
                                Console.WriteLine("Invalid product index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products available to update.");
                        }
                        break;

                    case 6:
                        if (products.Count > 0)
                        {
                            Console.Write("Enter the product index to delete: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index >= 0 && index < products.Count)
                            {
                                Admin admin3 = new Admin();
                                admin3.DeleteProduct(products, products[index]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid product index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products available to delete.");
                        }
                        break;

                    case 7:
                        Admin admin4 = new Admin();
                        admin4.ViewInventory(products);
                        break;

                    case 8:
                        if (products.Count > 0)
                        {
                            Console.Write("Enter the product index to update: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index >= 0 && index < products.Count)
                            {
                                Console.Write("Enter the new product name: ");
                                string newName = Console.ReadLine();
                                Console.Write("Enter the new product price amount: ");
                                double newPriceAmount = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter the new product price currency: ");
                                string newPriceCurrency = Console.ReadLine();
                                Price newPrice = new Price(newPriceAmount, newPriceCurrency);

                                Supplier supplier = new Supplier();
                                supplier.UpdateProduct(products[index], newName, newPrice);
                            }
                            else
                            {
                                Console.WriteLine("Invalid product index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products available to update.");
                        }
                        break;

                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    }
