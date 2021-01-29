using System;

namespace MMTShopConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MMTShop Console Client!");

            ApiManager apiManager = new ApiManager();

            Console.WriteLine("1a.Featured products");
            apiManager.GetAllCategories();
            Console.WriteLine("1a. Finished successfully");

            Console.WriteLine("1b. Available categories");
            apiManager.GetAllCategories();
            Console.WriteLine("1b. Finished successfully");

            Console.WriteLine("1c. Products by category");
            var categoryId = "1";
            apiManager.GetProductsByCategoryId(categoryId);
            Console.WriteLine("1c. Finished successfully");

            Console.ReadLine();
        }
    }
}
