using System.Runtime.Serialization;

namespace Recurly
{
    /// <summary>
    /// Recurly supports the balance sheet (Liability) account and income (Revenue) account to
    /// be specified for any given general ledger account entity.
    /// </summary>
    public enum GeneralLedgerAccountType
    {
        [EnumMember(Value = "liability")]
        Liability,

        [EnumMember(Value = "revenue")]
        Revenue,
    }
}
