using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using MyFirstSOAPInterface;

namespace soap_client
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("My First SOAP Client!");
            var client = new MyFirstSOAPInterfaceClient();
            
            var text = await client.getHelloWorldAsStringAsync("Karol");
            var daysBetweenDates = await client.getDaysBetweenDatesAsync(
                new DateTime(2019, 1, 1).ToString("dd MM yyyy"),
                new DateTime(2019, 5, 20).ToString("dd MM yyyy")
            );
            
            Console.WriteLine(text);
            Console.WriteLine($"Days between dates: {daysBetweenDates}");
        }
    }
}