using SLHDotNetTrainingBatch1.ConsoleApp;

string text = "Hello World,";
string result = text.Substring(0, text.Length - 1);
Console.WriteLine(result);

//BeforeSystem:

//Console.WriteLine("Inventory Management System");

//Console.WriteLine("1. Create Product");
//Console.WriteLine("2. View Products");
//Console.WriteLine("3. Update Product");
//Console.WriteLine("4. Delete Product");
//Console.WriteLine("5. Exit");

//Console.Write("Select an option: ");
//int option = int.Parse(Console.ReadLine()!);

//InventoryService inventoryService = new InventoryService();

//switch (option)
//{
//    case 1:
//        Console.WriteLine("Create Product");
//        inventoryService.CreateProduct();
//        break;
//    case 2:
//        Console.WriteLine("View Products");
//        inventoryService.ViewProducts();
//        break;
//    case 3:
//        Console.WriteLine("Update Product");
//        inventoryService.UpdateProduct();
//        break;
//    case 4:
//        Console.WriteLine("Delete Product");
//        inventoryService.DeleteProduct();
//        break;
//    case 5:
//        Console.WriteLine("Exiting...");
//        goto Exit;
//    default:
//        Console.WriteLine("Invalid option. Please try again.");
//        break;
//}

//goto BeforeSystem;

//Exit:
//Console.ReadKey();
