using System;
using Recurly;
using Recurly.Resources;
using System.Collections;
using System.Collections.Generic;

namespace RecurlyTestRig
{
    class Program
    {
        static void Main(string[] args)
        {
            var subdomain = Environment.GetEnvironmentVariable("RECURLY_SUBDOMAIN");
            var apiKey = Environment.GetEnvironmentVariable("RECURLY_API_KEY");
            var client = new Recurly.Client(subdomain, apiKey);

            var accountReq = new AccountCreate() {
                Code = "myaccountcode",
                Address = new Address() {
                    FirstName = "Benjamin",
                    LastName = "DuMonde",
                    Street1 = "123 Canal St.",
                    PostalCode = "70115",
                    Region = "LA",
                    City = "New Orleans",
                    Country = "US"
                },
            };

            Account account = client.CreateAccount(accountReq);

            try {
                client.GetAccount("code-unknown");
            } catch (Recurly.ApiError e) {
                Console.WriteLine(e.Error);
                Console.WriteLine(e.Error.Type);
                Console.WriteLine(e.Error.Message);
                Console.WriteLine(e.Error.Params);
            }

            // var accounts = client.ListAccounts();
            // foreach(Account account in accounts)
            // {
            //     Console.WriteLine(account.Code);
            // }
        }
    }
}
