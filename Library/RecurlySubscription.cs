using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    public class RecurlySubscription : RecurlyClient
    {
        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/subscription";
    }
}
