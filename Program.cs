using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace HttpConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                HttpResponseMessage response = client.GetAsync("todos/1").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JsonConvert.DeserializeObject(json);
                    Console.WriteLine("Title: " + data.title);
                    Console.WriteLine("Completed: " + data.completed);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }

            Console.ReadLine();
        }
    }
}
