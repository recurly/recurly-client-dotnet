using System;
using Recurly;
using Recurly.Resources;

namespace RecurlyTestRig
{
    class Program
    {
        static void Main(string[] args)
        {
          try {
            var subdomain = Environment.GetEnvironmentVariable("RECURLY_SUBDOMAIN");
            var apiKey = Environment.GetEnvironmentVariable("RECURLY_API_KEY");
            var client = new Recurly.Client(subdomain, apiKey);

            var account = client.GetAccount("code-benjamin-du-monde");
            Console.WriteLine(account.CreatedAt);

            var createAccount = new AccountCreate() {
                Code = Guid.NewGuid().ToString(),
                Username = "myuser",
                Address = new Address() {
                  Street1 = "123 Main St",
                  City = "New Orleans",
                  Region = "LA",
                  PostalCode = "70114",
                  Country = "US",
                }
            };

            var createdAccount = client.CreateAccount(createAccount);
            Console.WriteLine(createdAccount.CreatedAt);
            Console.WriteLine(createdAccount); 

            try {
                var nonexistentAccount = client.GetAccount("idontexist");
            } catch (Recurly.ApiError err) {
                Console.WriteLine(err);
            }
          } catch (Recurly.ApiError err) {
                Console.WriteLine(err);
          }
        }
    }
}
