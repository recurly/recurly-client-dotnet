namespace Recurly
{
    /// <summary>
    /// Transaction Decline Codes Enum
    /// </summary>
    public enum TransactionDeclineCodeEnum
    {
        account_closed,
        call_issuer,
        card_not_activated,
        card_not_supported,
        cardholder_requested_stop,
        do_not_honor,
        do_not_try_again,
        exceeds_daily_limit,
        generic_decline,
        expired_card,
        fraudulent,
        insufficient_funds,
        incorrect_address,
        incorrect_security_code,
        invalid_amount,
        invalid_number,
        invalid_transaction,
        issuer_unavailable,
        lifecycle_decline,
        lost_card,
        pickup_card,
        policy_decline,
        restricted_card,
        restricted_card_chargeback,
        security_decline,
        stolen_card,
        try_again,
        update_cardholder_data,
        requires_3d_secure,

        // NOTE: not_recognized is used as a default and does not reflect a
        // valid value from the Recurly API. To preserve backwards compatibility,
        // order of this enum should be preserved and new values must be appended.
        not_recognized
    }
}
