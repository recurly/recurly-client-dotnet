using System;
using System.Collections.Generic;

namespace Recurly
{
    public class ProrationSettings
    {
        public enum Options
        {
            ProratedAmount,
            FullAmount,
            None
        }

        /// <summary>
        /// Proration behavior to be applied to charges for the subscription change.
        /// When not set, default proration settings will be applied.
        /// </summary>
        public Options? Charge { get; set; }

        /// <summary>
        /// Proration behavior to be applied to credits for the subscription change.
        /// When not set, default proration settings will be applied.
        /// </summary>
        public Options? Credit { get; set; }
    }
}
