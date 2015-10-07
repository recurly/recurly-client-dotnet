using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Recurly.Test
{
    public class RecurlyFact : FactAttribute
    {
        public RecurlyFact(params TestEnvironment.Type[] scenarios)
        {
            var environment = TestEnvironment.GetInstance();

            if (!environment.HasSupportFor(scenarios))
            {
                Skip = "TestEnvironment does not support scenario";
            }
        }
    }
}

