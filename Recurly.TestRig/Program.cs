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
            var client = new Recurly.Client(subdomain, apiKey);;

            var address = new Address() {
                Street1 = "123 Main St",
                City = "New Orleans",
                Region = "LA",
                PostalCode = "70114",
                Country = "US",
            };

            var account = new AccountCreate() {
                Code = Guid.NewGuid().ToString(),
                Username = "myuser",
                Address = address,
                BillingInfo = new BillingInfoCreate() {
                    FirstName = "Benjamin",
                    LastName = "Eckel",
                    Number = "4111-1111-1111-1111",
                    Month = "12",
                    Year = "2022",
                    Address = address,
                }
            };

            var subscriptionRequest = new SubscriptionCreate() {
                Account = account,
                PlanCode = "gold1",
                Currency = "USD",
            };

            var subscription = client.CreateSubscription(subscriptionRequest);
            Console.WriteLine(subscription); 

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
