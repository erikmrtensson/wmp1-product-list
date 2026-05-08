using wmp1_product_list;

List<string> products = new List<string>();

Console.WriteLine("-----------------------------");
Console.WriteLine("    PRODUCT LIST MANAGER");
Console.WriteLine("-----------------------------");
Console.WriteLine("");

while (true)
{
    Functions.MainMenu();
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Functions.AddProduct(products);
            break;
        case "2":
            Functions.ViewProducts(products);
            break;
        case "3":
            Functions.SearchProducts(products);
            break;
        case "4":
            Functions.DeleteProducts(products);
            break;
        case "5":
            Functions.Statistics(products);
            break;
        case "6":
            Console.WriteLine("");
            Functions.SaveToFile(products);
            Console.WriteLine("Application closed.");
            Console.ReadLine();
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid option. Please try again.\n");
            break;
    }
}
