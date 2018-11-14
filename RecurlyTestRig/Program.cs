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
                Code = "abcsdaskdljsda",
                Username = "myuser"
            };

            var createdAccount = client.CreateAccount(createAccount);
            Console.WriteLine(createdAccount.CreatedAt);

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
