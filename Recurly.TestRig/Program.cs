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
            var client = new Recurly.Client(subdomain, apiKey);;

            try {
                var account = client.GetAccount("unknown");
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
