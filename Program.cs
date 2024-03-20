using System.Text.Json;

namespace LINQtests
{
    internal class Program
    {
        private const string V = "\t\"+ p.Name + ";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome!");
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Product Details \n");
            List<Product> Inventory = CreateProducts();
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Id\tName\t\tCategory\tColor\tPrice\tQuantity in stock ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            int count = Inventory.Count;

            Console.WriteLine($"There are {count} products in our Inventory.");

            //var items = from p in Inventory // items is Ienumerable of Product
            //            where p.Color == "Red" // this is case sensitive LINQ to objects
            //            select p;

            var price = from pcheck in Inventory
                        where !(pcheck.Price > 200.00m && pcheck.Color != "Red")
                        select pcheck;

            var things = Inventory.Where(t => t.Color == "Red");

            //foreach (var t in things)
            //{
            //    Console.WriteLine($" Product {t.Name} is {t.Color}");
            //}
            Console.WriteLine("---------------------------------");
            //var items = from p in Inventory
            //            where (p.Price > 200.00m && p.Color != "Red")
            //            select new { p.Name, p.Price, p.QtyInStock, TotalValue = p.Price * p.QtyInStock };

            var items1 = Inventory.Where(p => p.Color == "Red")
                        .Select(p=> new { p.Name, p.Price, p.QtyInStock, p = p.Price*p.QtyInStock});

            var totalValue = Inventory.Where(p => p.Color == "Red");

            Console.WriteLine($"Total value of red items is {totalValue}");


            Console.WriteLine("---------------------------------");
            //foreach (var pcheck in items1)
            //{
            //    Console.WriteLine($"{pcheck.Name} has price {pcheck.Name} and color is {pcheck.Color}\n");
            //}
            //Console.WriteLine("-------------------------------------------");
            foreach (var pcheck in price)
            {
                Console.WriteLine($"{pcheck.Name} has price {pcheck.Price} and color is {pcheck.Color}\n");
            }
            Console.WriteLine("--------------------------------------------------------");
            var totalValue1 = Inventory.Where(p => p.Color == "Red").Average(p => p.Price);
            Console.WriteLine($"Total {totalValue1}");
            //foreach (var p in items)
            //{
            //    Console.WriteLine($" Product {p.Name} is {p.Color}");
            //}


            //foreach (Product p in Inventory)
            //{
            //    Console.Write(p.Id + "\t" + p.Name + "\t\t" + p.Category);
            //    Console.Write("\t"+p.Color + "\t"+ p.Price + "\t"+p.QtyInStock);
            //    Console.WriteLine("\n");             
            //}
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------");

            var totalOfAllItems = Inventory.Where(p=> p.Color == "Red").Sum(p => p.Price * p.QtyInStock);

            Console.WriteLine($"Sum Total of all Prices of all Red colored items {totalOfAllItems:C2}");


            Console.WriteLine("--------------------------------------");

            Console.WriteLine("JSON follows");

            ShowAsJson(items1);
            Console.WriteLine("Bye!");

            
        } // end of main

        public static List<Product> CreateProducts()
        {

            List<Product> products = new List<Product>();

            Product p1 = new Product(1, "Plane", "Toy", "White", 15.55m, 5);
            Product p2 = new Product(2, "Ball", "Toy", "Green", 25.55m, 25);
            Product p3 = new Product(3, "Bat", "Toy", "White:", 75.55m, 10);
            Product p4 = new Product(4, "Computer", "Machine", "Black", 700.75m, 3);
            Product p5 = new Product(5, "Table", "Furniture", "Red", 205.55m, 4);
            Product p6 = new Product(6, "Chair", "Furniture", "Red", 15.55m, 6);
            Product p7 = new Product(7, "Printer", "Machine", "White", 75.55m, 2);
            Product p8 = new Product(8, "Bus", "Toy", "Red", 45.55m, 3);
            Product p9 = new Product(9, "Car", "Toy", "Orange", 15.55m, 4);
            Product p10 = new Product(10, "Truck", "Toy", "Red", 25.55m, 3);

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);
            products.Add(p6);
            products.Add(p7);
            products.Add(p8);
            products.Add(p9);
            products.Add(p10);

            return products;
        }
        static void ShowAsJson(object obj)
        {
            Console.WriteLine($"JSON for {obj.GetType()}");

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(obj, options);
            Console.WriteLine(json);
        }

    }// end of class

} // end of namespace