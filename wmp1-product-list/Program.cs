/*
 * 
 * TODO
 * TEST SO EVERYTHING WORKS
 * SEPERATE INTO CLASSES/CLASS
 * 
 * 


    LEVEL 3

    FORMAT
    LETTERS-NUMBERS

    Rules:
    • Left side:
        o Letters only (A-Z)
    • Right side:
        o Numbers only
        o Must be between 200 and 500

    eg. CE-400

    ------------------------------------------
    LEVEL 4

    Additional Requirements
    1. Prevent Duplicate Products
    If a product already exists:
    WARNING: Product already exists.
    2. Add Menu System
    Example:
    1. Add Product
    2. View Products
    3. Search Product
    4. Delete Product
    5. Exit
    3. Search Feature
    Users can search products by:
    • Name
    • Product number
    Example:
    Search: AB
    Results:
    - AB-300
    - AB-400
    4. Delete Feature
    Example:
    Enter product to delete: AB-300
    Product removed successfully.
    5. Statistics Section
    Display:
    • Total products
    • Highest product number
    • Lowest product number
    • Average product number
    6. Save to File (Bonus)
    Save all products to:
    products.txt
    Or:
    products.json
*/

using System.Text.RegularExpressions;

List<string> products = new List<string>();

Console.WriteLine("-----------------------------");
Console.WriteLine("PRODUCT LIST MANAGER");
Console.WriteLine("-----------------------------");
Console.WriteLine("");
Console.WriteLine("Enter product names.");
Console.WriteLine("Type 'exit' to finish");

while (true)
{
    MainMenu();
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            AddProduct(products);
            break;
        case "2":
            ViewProducts(products);
            break;
        case "3":
            SearchProducts(products);
            break;
        case "4":
            DeleteProducts(products);
            break;
        case "5":
            Statistics(products);
            break;
        case "6":
            Console.WriteLine("");
            SaveToFile(products);
            Console.WriteLine("Application closed.");
            Console.ReadLine();
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

bool IsValidFormat(string input)
{
    // FORMAT
    // LETTERS - NUMBERS

    var match = Regex.Match(input, @"^([A-Za-z]+)-(\d+)$");
    if (!match.Success)
    {
        return false;
    }

    int number = int.Parse(match.Groups[2].Value);
    return number >= 200 && number <= 500;
}

void MainMenu()
{
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Search Products");
    Console.WriteLine("4. Delete Products");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Exit");
    Console.WriteLine("");
    Console.Write("Select Option: ");
}

void AddProduct(List<string> products)
{
    Console.Write("Enter Product: ");
    string data = Console.ReadLine();
    data = data.ToUpper().Trim(); // Normalize input

    if(!IsValidFormat(data))
    {
        Console.WriteLine("ERROR: Invalid format. Please use LETTERS-NUMBERS (e.g., AB-300).");
        Console.ReadLine();
        return;
    }
    if (products.Contains(data))
    {
        Console.WriteLine("ERROR: Product already exists.");
        Console.ReadLine();
        return;
    }

    products.Add(data);
    Console.WriteLine("Product Added!");
    Console.WriteLine("");
    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();
}

void ViewProducts(List<string> products)
{
    if (products.Count > 0)
    {
        products.Sort();
        Console.WriteLine("Products:");
        Console.WriteLine("");
        foreach (var product in products)
        {
            Console.WriteLine("- " + product);
        }
        Console.WriteLine("");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("No products available.");
        Console.WriteLine("");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}

void SearchProducts(List<string> products)
{
    Console.Write("Search (by name or number): ");
    string query = Console.ReadLine();
    query = query.Trim().ToUpper();

    var results = products.Where(p => p.Contains(query)).ToList();

    if (results.Count == 0)
    {
        Console.WriteLine("No results.");
        Console.ReadLine();
    } 
    else
    {
        Console.WriteLine("Results:");
        foreach (var result in results) 
        {
            Console.WriteLine("- " + result);
        }
        Console.WriteLine("");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}

void DeleteProducts(List<string> products)
{
    // Return if no products
    if (products.Count == 0)
    {
        Console.WriteLine("No products to delete.");
        return;
    }

    // Display products with numbers for easy deletion
    Console.WriteLine("Current products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"  {i + 1}. {products[i]}");
    }

    Console.Write("Enter product NUMBER to delete: ");
    string input = Console.ReadLine().Trim();

    // Validate input with tryparse
    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return;
    }

    // Validate choice is within range of products
    if (choice < 1 || choice > products.Count)
    {
        Console.WriteLine($"Invalid number. Please enter between 1 and {products.Count}.");
        return;
    }

    // Remove product and confirm deletion
    string removed = products[choice - 1];
    products.RemoveAt(choice - 1);
    Console.WriteLine($"'{removed}' removed successfully.");
}

void Statistics(List<string> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products available.");
        return;
    }

    // Create new list for numbers only
    List<int> productNumbers = new List<int>();

    foreach (string productNumber in products)
    {
        productNumbers.Add(int.Parse(productNumber.Split('-')[1]));
    }

    // Display statistics
    Console.WriteLine($"Total products: {products.Count}");
    Console.WriteLine($"Highest product number: {productNumbers.Max()}");
    Console.WriteLine($"Lowest product number: {productNumbers.Min()}");
    Console.WriteLine($"Average product number: {productNumbers.Average()}");
}


void SaveToFile(List<string> products)
{
    File.WriteAllLines("products.txt", products);
    Console.WriteLine($"Saving products...");
}


