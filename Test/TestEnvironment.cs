using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recurly.Test
{
    public class TestEnvironment
    {
        public static TestEnvironment Instance;
        public static TestEnvironment GetInstance()
        {
            if (Instance == null) Instance = new TestEnvironment();
            return Instance;
        }

        public Type[] Supports;
        public enum Type
        {
            Integration,
            Unit
        };

        private bool IsTravis;

        internal TestEnvironment()
        {
            IsTravis = Environment.GetEnvironmentVariable("TRAVIS") == "true";
        }

        public bool HasSupportFor(Type[] scenarios)
        {
            if (IsTravis && scenarios.Contains(Type.Integration))
            {
                return false;
            }
            return true;
        }
    }
}
