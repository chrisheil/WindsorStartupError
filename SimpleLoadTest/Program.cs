using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleLoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Startup Test");
            var testRunner = new TestRunner();
            var isSuccess = testRunner.RunTests().Result;
            Console.WriteLine($"Test run success status: {isSuccess}");
        }

        protected class TestRunner
        {
            public async Task<bool> RunTests()
            {
                try
                {
                    var responses = new List<Task<HttpResponseMessage>>();

                    using HttpClient client = new HttpClient();
                    for (int i = 0; i < 100; i++)
                    {
                        responses.Add(client.GetAsync("https://localhost:5001/TestService"));
                    }

                    var results = await Task.WhenAll(responses);

                    foreach (var result in results)
                    {
                        Console.WriteLine(result.Content.ReadAsStringAsync().Result);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
