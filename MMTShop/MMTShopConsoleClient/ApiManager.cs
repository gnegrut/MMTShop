using System;
using System.Net;

namespace MMTShopConsoleClient
{
    public class ApiManager
    {
        public void GetAllCategories()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44332/api/category"); //URI  all categories
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public void GetProductsByCategoryId(string categoryId)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString($"https://localhost:44332/api/product/{categoryId}"); //URI products for categoryId = 1
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
