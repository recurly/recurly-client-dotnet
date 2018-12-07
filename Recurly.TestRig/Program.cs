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

            // var acc = client.GetAccount("code-benjamin-du-monde");
            // var emails = acc.CcEmails.Split(",");
            // foreach (var email in emails)
            // {
            //     Console.WriteLine(email);
            // }

            // var accReq = new AccountUpdate() {
            //     CcEmails = "ben@recurly.com,scott.choi@recurly.com",
            // };
            // acc = client.UpdateAccount(acc.Id, accReq);
            // emails = acc.CcEmails.Split(",");
            // foreach (var email in emails)
            // {
            //     Console.WriteLine(email);
            // }

            /** Create a Plan */
            var planRequest = new PlanCreate() {
                Code = Guid.NewGuid().ToString(),
                IntervalLength = 1,
                IntervalUnit = "months",
                Name = "MyDotnetPlan",
                Currencies = new List<PlanPricing>() {
                    new PlanPricing() {
                        Currency = "USD",
                        UnitAmount =  100000
                    }
                }
            };
            var plan = client.CreatePlan(planRequest);
            
            /** Create IP Address AddOn */
            var ipAddOnRequst = new AddOnCreate() {
                Code = "ip_addresses",
                Name = "Ip Addresses",
                Currencies = new List<AddOnPricing>() {
                    new AddOnPricing() {
                        Currency = "USD",
                        UnitAmount = 100
                    }
                }
            };
            var ipAddOn = client.CreatePlanAddOn(plan.Id, ipAddOnRequst);
            
            /** Create User AddOn */
            var userAddOnRequst = new AddOnCreate() {
                Code = "extra_users",
                Name = "Extra Users",
                Currencies = new List<AddOnPricing>() {
                    new AddOnPricing() {
                        Currency = "USD",
                        UnitAmount = 200
                    }
                }
            };
            var userAddOn = client.CreatePlanAddOn(plan.Id, userAddOnRequst);
            
            
            /** Create Subscription */
            
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
                PlanCode = plan.Code,
                Currency = "USD",
                AddOns = new List<SubscriptionAddOnCreate>() {
                    new SubscriptionAddOnCreate() {
                        Code = ipAddOn.Code,
                        Quantity = 4,
                        UnitAmount = 100,
                    }
                }
            };
            
            var subscription = client.CreateSubscription(subscriptionRequest);
            
            /** Add on the user add on after the fact with a subscription change */
            
            var addOnsRequest = new List<SubscriptionAddOnCreate>() {
                // existing add on, we can reference by Id for existing add on
                new SubscriptionAddOnCreate() {
                    Id = subscription.AddOns[0].Id
                },
                // new extra users add on
                new SubscriptionAddOnCreate() {
                    Code = "extra_users",
                    Quantity = 10,
                    UnitAmount = 100,
                },    
            };
            var subChangeRequest = new SubscriptionChangeCreate() {
                AddOns = addOnsRequest
            };
            var subChange = client.CreateSubscriptionChange(subscription.Id, subChangeRequest);
            
            Console.WriteLine(subscription.Uuid);

            // var accountReq = new AccountCreate() {
            //     Code = "myaccountcode123",
            //     Address = new Address() {
            //         Street1 = "123 Canal St.",
            //         PostalCode = "70115",
            //         Region = "LA",
            //         City = "New Orleans",
            //         Country = "US"
            //     },
            // };
            
            // Account acct = client.CreateAccount(accountReq);
            
            // try {
            //     client.GetAccount("code-unknown");
            // } catch (Recurly.ApiError e) {
            //     Console.WriteLine(e.Error);
            //     Console.WriteLine(e.Error.Type);
            //     Console.WriteLine(e.Error.Message);
            //     Console.WriteLine(e.Error.Params);
            // }

            var filter = new DateTime(2018, 1, 1);
            var accounts = client.ListAccounts(limit: 200, order: "desc", begin_time: filter);
            foreach(Account acc in accounts)
            {
                Console.WriteLine(acc.CreatedAt.ToString());
            }
        }
    }
}
