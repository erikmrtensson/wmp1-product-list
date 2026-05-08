using System;
using System.Collections.Generic;
using System.Text;

namespace wmp1_product_list
{
    internal class Functions
    {
        private static string IsValidFormat(string input)
        {
            // FORMAT: LETTERS-NUMBERS

            if (string.IsNullOrEmpty(input))
            {
                return "Input cannot be empty.";
            }
            if (!input.Contains('-'))
            {
                return "Product must contain a dash (-).";
            }

            // Devide input into parts and validate each part
            string[] parts = input.Split('-');
            string letters = parts[0];
            string numbers = parts[1];

            // Stops users from entering more than 1 dash
            if (parts.Length > 2)
            {
                return "Product must have exactly one dash (-). e.g. AB-300";
            }

            if (string.IsNullOrEmpty(letters) || !letters.All(char.IsLetter))
            {
                return "The left side must contain letters only.";
            }

            if (!int.TryParse(numbers, out int number)) 
            {
                return "The right side must contain numbers only.";
            }

            if (number < 200 || number > 500)
            {
                return $"The numeric part must be between 200 and 500.";
            }

            return null;
        }

        public static void MainMenu()
        {
            Console.ResetColor();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Search Products");
            Console.WriteLine("4. Delete Products");
            Console.WriteLine("5. Statistics");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            Console.Write("Select Option: ");
        }

        public static void AddProduct(List<string> products)
        {
            Console.Clear();
            Console.Write("Enter Product: ");
            string data = Console.ReadLine();
            data = data.ToUpper().Trim(); // Normalize input

            Console.ForegroundColor = ConsoleColor.Red;

            string error = IsValidFormat(data);
            if (error != null)
            {
                Console.WriteLine($"ERROR: {error}");
                Console.ReadLine();
                return;
            }

            if (products.Contains(data))
            {

                Console.WriteLine("WARNING: Product already exists.");
                Console.ReadLine();
                return;
            }

            products.Add(data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProduct Added!\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void ViewProducts(List<string> products)
        {
            Console.Clear();
            if (products.Count > 0)
            {
                products.Sort();
                Console.WriteLine("Products:\n");
                foreach (var product in products)
                {
                    Console.WriteLine("- " + product);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No products available.\n");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }

        public static void SearchProducts(List<string> products)
        {
            Console.Clear();
            Console.Write("Search (by name or number): ");
            string query = Console.ReadLine();
            query = query.Trim().ToUpper();

            List<string> results = new List<string>();
            foreach (string product in products)
            {
                if (product.Contains(query))
                {
                    results.Add(product);
                }
            }

            if (results.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo results.\n");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("\nResults:\n");
                foreach (var result in results)
                {
                    Console.WriteLine("- " + result);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
            }
        }

        public static void DeleteProducts(List<string> products)
        {
            Console.Clear();
            // Return if no products
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No products to delete.\n");
                return;
            }

            // Display products with numbers for easy deletion
            Console.WriteLine("Current products:\n");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {products[i]}");
            }
            Console.Write("\nEnter product NUMBER to delete: ");
            string input = Console.ReadLine().Trim();

            Console.ForegroundColor = ConsoleColor.Red;
            // Validate input with tryparse
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("\nInvalid input. Please enter a number.\n");
                return;
            }

            // Validate choice is within range of products
            if (choice < 1 || choice > products.Count)
            {
                Console.WriteLine($"\nInvalid number.\n");
                return;
            }

            // Remove product and confirm deletion, - adjust for 0-based index
            string removed = products[choice - 1];
            products.RemoveAt(choice - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n'{removed}' removed successfully.\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void Statistics(List<string> products)
        {
            Console.Clear();
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No products available.\n");
                return;
            }

            // Create new list for numbers only
            List<int> productNumbers = new List<int>();

            foreach (string productNumber in products)
            {
                productNumbers.Add(int.Parse(productNumber.Split('-')[1]));
            }

            // Display statistics
            Console.WriteLine($"- Total products: {products.Count} \n");
            Console.WriteLine($"- Highest product number: {productNumbers.Max()}");
            Console.WriteLine($"- Lowest product number: {productNumbers.Min()}");
            Console.WriteLine($"- Average product number: {productNumbers.Average()} \n");
        }


        public static void SaveToFile(List<string> products)
        {
            File.WriteAllLines("products.txt", products);
            Console.WriteLine($"Saving products...");
        }

    }
}
