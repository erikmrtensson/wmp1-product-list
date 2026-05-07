/*
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

List<string> products = new List<string>();

Console.WriteLine("-----------------------------");
Console.WriteLine("PRODUCT LIST MANAGER");
Console.WriteLine("-----------------------------");
Console.WriteLine("");
Console.WriteLine("Enter product names.");
Console.WriteLine("Type 'exit' to finish");

while (true)
{
    Console.Write("Product: ");
    string data = Console.ReadLine();
    if(data.ToLower().Trim() == "exit")
    {
        break;
    }

    products.Add(data);
}

// Sort Products
products.Sort();

// List products
Console.WriteLine("Products:");
foreach(var product in products)
{
    Console.WriteLine(product);
}

Console.ReadLine();


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

