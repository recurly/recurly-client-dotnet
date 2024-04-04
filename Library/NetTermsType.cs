using System.Runtime.Serialization;
namespace Recurly
{
    /// <summary>
    /// Optionally supplied string that may be either net or eom(end-of-month).
    /// When 'net', an invoice becomes past due the specified number of net_terms
    /// days from the current date.  When 'eom' an invoice becomes past due the
    /// specified number of net_terms days from the last day of the current month.
    /// If NetTermsType is 'eom' then NetTerms must be one of 0, 15, 30, 45, 60, or 90
    /// </summary>
    public enum NetTermsType
    {
        [EnumMember(Value = "net")]
        NET,

        [EnumMember(Value = "eom")]
        EOM,
    }
}
