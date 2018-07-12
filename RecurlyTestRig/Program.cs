using System;
using Recurly;
using Recurly.Resources;

namespace RecurlyTestRig
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Recurly.Client("subdomain-client-lib-test", "382c053318a04154905c4d27a48f74a6");
            var site = client.GetSite("subdomain-client-lib-test");
            Console.WriteLine(site.Id);

            var account = client.GetAccount("subdomain-client-lib-test", "code-benjamin-du-monde");
            Console.WriteLine(account.CreatedAt);

            var createAccount = new AccountCreate() {
                Code = "abcsdaskdljsda",
                Username = "myuser",
                Address = new Address() {
                    City = "New Orleans",
                    Street1 = "1 Canal St.",
                    Region = "LA",
                    Country = "US",
                    PostalCode = "70115"
                }
            };

            var createdAccount = client.CreateAccount("subdomain-client-lib-test", createAccount);
            Console.WriteLine(createdAccount.CreatedAt);

            try {
                var nonexistentAccount = client.GetAccount("subdomain-client-lib-test", "idontexist");
            } catch (Recurly.ApiError err) {
                Console.WriteLine(err);
            }
            
        }
    }
}
