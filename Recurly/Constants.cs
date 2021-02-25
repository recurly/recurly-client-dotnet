/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Recurly
{
    namespace Constants
    {

        public enum RelatedType
        {
            Undefined = 0,

            [EnumMember(Value = "account")]
            Account,

            [EnumMember(Value = "item")]
            Item,

            [EnumMember(Value = "subscription")]
            Subscription,

        };

        public enum RefundType
        {
            Undefined = 0,

            [EnumMember(Value = "full")]
            Full,

            [EnumMember(Value = "none")]
            None,

            [EnumMember(Value = "partial")]
            Partial,

        };

        public enum AlphanumericSort
        {
            Undefined = 0,

            [EnumMember(Value = "asc")]
            Asc,

            [EnumMember(Value = "desc")]
            Desc,

        };

        public enum UsageSort
        {
            Undefined = 0,

            [EnumMember(Value = "recorded_timestamp")]
            RecordedTimestamp,

            [EnumMember(Value = "usage_timestamp")]
            UsageTimestamp,

        };

        public enum UsageType
        {
            Undefined = 0,

            [EnumMember(Value = "price")]
            Price,

            [EnumMember(Value = "percentage")]
            Percentage,

        };

        public enum BillingStatus
        {
            Undefined = 0,

            [EnumMember(Value = "unbilled")]
            Unbilled,

            [EnumMember(Value = "billed")]
            Billed,

            [EnumMember(Value = "all")]
            All,

        };

        public enum TimestampSort
        {
            Undefined = 0,

            [EnumMember(Value = "created_at")]
            CreatedAt,

            [EnumMember(Value = "updated_at")]
            UpdatedAt,

        };

        public enum ActiveState
        {
            Undefined = 0,

            [EnumMember(Value = "active")]
            Active,

            [EnumMember(Value = "inactive")]
            Inactive,

        };

        public enum FilterSubscriptionState
        {
            Undefined = 0,

            [EnumMember(Value = "active")]
            Active,

            [EnumMember(Value = "canceled")]
            Canceled,

            [EnumMember(Value = "expired")]
            Expired,

            [EnumMember(Value = "future")]
            Future,

            [EnumMember(Value = "in_trial")]
            InTrial,

            [EnumMember(Value = "live")]
            Live,

        };

        public enum True
        {
            Undefined = 0,

            [EnumMember(Value = "true")]
            True,

        };

        public enum LineItemState
        {
            Undefined = 0,

            [EnumMember(Value = "invoiced")]
            Invoiced,

            [EnumMember(Value = "pending")]
            Pending,

        };

        public enum LineItemType
        {
            Undefined = 0,

            [EnumMember(Value = "charge")]
            Charge,

            [EnumMember(Value = "credit")]
            Credit,

        };

        public enum FilterTransactionType
        {
            Undefined = 0,

            [EnumMember(Value = "authorization")]
            Authorization,

            [EnumMember(Value = "capture")]
            Capture,

            [EnumMember(Value = "payment")]
            Payment,

            [EnumMember(Value = "purchase")]
            Purchase,

            [EnumMember(Value = "refund")]
            Refund,

            [EnumMember(Value = "verify")]
            Verify,

        };

        public enum FilterInvoiceType
        {
            Undefined = 0,

            [EnumMember(Value = "charge")]
            Charge,

            [EnumMember(Value = "credit")]
            Credit,

            [EnumMember(Value = "legacy")]
            Legacy,

            [EnumMember(Value = "non-legacy")]
            NonLegacy,

        };

        public enum Channel
        {
            Undefined = 0,

            [EnumMember(Value = "advertising")]
            Advertising,

            [EnumMember(Value = "blog")]
            Blog,

            [EnumMember(Value = "direct_traffic")]
            DirectTraffic,

            [EnumMember(Value = "email")]
            Email,

            [EnumMember(Value = "events")]
            Events,

            [EnumMember(Value = "marketing_content")]
            MarketingContent,

            [EnumMember(Value = "organic_search")]
            OrganicSearch,

            [EnumMember(Value = "other")]
            Other,

            [EnumMember(Value = "outbound_sales")]
            OutboundSales,

            [EnumMember(Value = "paid_search")]
            PaidSearch,

            [EnumMember(Value = "public_relations")]
            PublicRelations,

            [EnumMember(Value = "referral")]
            Referral,

            [EnumMember(Value = "social_media")]
            SocialMedia,

        };

        public enum PreferredLocale
        {
            Undefined = 0,

            [EnumMember(Value = "da-DK")]
            DaDk,

            [EnumMember(Value = "de-CH")]
            DeCh,

            [EnumMember(Value = "de-DE")]
            DeDe,

            [EnumMember(Value = "en-AU")]
            EnAu,

            [EnumMember(Value = "en-CA")]
            EnCa,

            [EnumMember(Value = "en-GB")]
            EnGb,

            [EnumMember(Value = "en-NZ")]
            EnNz,

            [EnumMember(Value = "en-US")]
            EnUs,

            [EnumMember(Value = "es-ES")]
            EsEs,

            [EnumMember(Value = "es-MX")]
            EsMx,

            [EnumMember(Value = "es-US")]
            EsUs,

            [EnumMember(Value = "fr-CA")]
            FrCa,

            [EnumMember(Value = "fr-FR")]
            FrFr,

            [EnumMember(Value = "hi-IN")]
            HiIn,

            [EnumMember(Value = "ja-JP")]
            JaJp,

            [EnumMember(Value = "nl-BE")]
            NlBe,

            [EnumMember(Value = "nl-NL")]
            NlNl,

            [EnumMember(Value = "pt-BR")]
            PtBr,

            [EnumMember(Value = "pt-PT")]
            PtPt,

            [EnumMember(Value = "ru-RU")]
            RuRu,

            [EnumMember(Value = "tr-TR")]
            TrTr,

            [EnumMember(Value = "zh-CN")]
            ZhCn,

        };

        public enum BillTo
        {
            Undefined = 0,

            [EnumMember(Value = "parent")]
            Parent,

            [EnumMember(Value = "self")]
            Self,

        };

        public enum GatewayTransactionType
        {
            Undefined = 0,

            [EnumMember(Value = "moto")]
            Moto,

        };

        public enum KountDecision
        {
            Undefined = 0,

            [EnumMember(Value = "approve")]
            Approve,

            [EnumMember(Value = "decline")]
            Decline,

            [EnumMember(Value = "escalate")]
            Escalate,

            [EnumMember(Value = "review")]
            Review,

        };

        public enum CouponState
        {
            Undefined = 0,

            [EnumMember(Value = "expired")]
            Expired,

            [EnumMember(Value = "maxed_out")]
            MaxedOut,

            [EnumMember(Value = "redeemable")]
            Redeemable,

        };

        public enum CouponDuration
        {
            Undefined = 0,

            [EnumMember(Value = "forever")]
            Forever,

            [EnumMember(Value = "single_use")]
            SingleUse,

            [EnumMember(Value = "temporal")]
            Temporal,

        };

        public enum TemporalUnit
        {
            Undefined = 0,

            [EnumMember(Value = "day")]
            Day,

            [EnumMember(Value = "month")]
            Month,

            [EnumMember(Value = "week")]
            Week,

            [EnumMember(Value = "year")]
            Year,

        };

        public enum FreeTrialUnit
        {
            Undefined = 0,

            [EnumMember(Value = "day")]
            Day,

            [EnumMember(Value = "month")]
            Month,

            [EnumMember(Value = "week")]
            Week,

        };

        public enum RedemptionResource
        {
            Undefined = 0,

            [EnumMember(Value = "account")]
            Account,

            [EnumMember(Value = "subscription")]
            Subscription,

        };

        public enum CouponType
        {
            Undefined = 0,

            [EnumMember(Value = "bulk")]
            Bulk,

            [EnumMember(Value = "single_code")]
            SingleCode,

        };

        public enum DiscountType
        {
            Undefined = 0,

            [EnumMember(Value = "fixed")]
            Fixed,

            [EnumMember(Value = "free_trial")]
            FreeTrial,

            [EnumMember(Value = "percent")]
            Percent,

        };

        public enum AddOnSource
        {
            Undefined = 0,

            [EnumMember(Value = "plan_add_on")]
            PlanAddOn,

            [EnumMember(Value = "item")]
            Item,

        };

        public enum AddOnType
        {
            Undefined = 0,

            [EnumMember(Value = "fixed")]
            Fixed,

            [EnumMember(Value = "usage")]
            Usage,

        };

        public enum AddOnTypeCreate
        {
            Undefined = 0,

            [EnumMember(Value = "fixed")]
            Fixed,

            [EnumMember(Value = "usage")]
            Usage,

        };

        public enum UsageTypeCreate
        {
            Undefined = 0,

            [EnumMember(Value = "price")]
            Price,

            [EnumMember(Value = "percentage")]
            Percentage,

        };

        public enum TierType
        {
            Undefined = 0,

            [EnumMember(Value = "flat")]
            Flat,

            [EnumMember(Value = "tiered")]
            Tiered,

            [EnumMember(Value = "stairstep")]
            Stairstep,

            [EnumMember(Value = "volume")]
            Volume,

        };

        public enum CreditPaymentAction
        {
            Undefined = 0,

            [EnumMember(Value = "payment")]
            Payment,

            [EnumMember(Value = "reduction")]
            Reduction,

            [EnumMember(Value = "refund")]
            Refund,

            [EnumMember(Value = "write_off")]
            WriteOff,

        };

        public enum UserAccess
        {
            Undefined = 0,

            [EnumMember(Value = "api_only")]
            ApiOnly,

            [EnumMember(Value = "read_only")]
            ReadOnly,

            [EnumMember(Value = "write")]
            Write,

        };

        public enum RevenueScheduleType
        {
            Undefined = 0,

            [EnumMember(Value = "at_range_end")]
            AtRangeEnd,

            [EnumMember(Value = "at_range_start")]
            AtRangeStart,

            [EnumMember(Value = "evenly")]
            Evenly,

            [EnumMember(Value = "never")]
            Never,

        };

        public enum InvoiceType
        {
            Undefined = 0,

            [EnumMember(Value = "charge")]
            Charge,

            [EnumMember(Value = "credit")]
            Credit,

            [EnumMember(Value = "legacy")]
            Legacy,

        };

        public enum Origin
        {
            Undefined = 0,

            [EnumMember(Value = "credit")]
            Credit,

            [EnumMember(Value = "gift_card")]
            GiftCard,

            [EnumMember(Value = "immediate_change")]
            ImmediateChange,

            [EnumMember(Value = "line_item_refund")]
            LineItemRefund,

            [EnumMember(Value = "open_amount_refund")]
            OpenAmountRefund,

            [EnumMember(Value = "purchase")]
            Purchase,

            [EnumMember(Value = "renewal")]
            Renewal,

            [EnumMember(Value = "termination")]
            Termination,

            [EnumMember(Value = "write_off")]
            WriteOff,

            [EnumMember(Value = "prepayment")]
            Prepayment,

        };

        public enum InvoiceState
        {
            Undefined = 0,

            [EnumMember(Value = "open")]
            Open,

            [EnumMember(Value = "pending")]
            Pending,

            [EnumMember(Value = "processing")]
            Processing,

            [EnumMember(Value = "past_due")]
            PastDue,

            [EnumMember(Value = "paid")]
            Paid,

            [EnumMember(Value = "closed")]
            Closed,

            [EnumMember(Value = "failed")]
            Failed,

            [EnumMember(Value = "voided")]
            Voided,

        };

        public enum CollectionMethod
        {
            Undefined = 0,

            [EnumMember(Value = "automatic")]
            Automatic,

            [EnumMember(Value = "manual")]
            Manual,

        };

        public enum InvoiceRefundType
        {
            Undefined = 0,

            [EnumMember(Value = "amount")]
            Amount,

            [EnumMember(Value = "line_items")]
            LineItems,

        };

        public enum RefuneMethod
        {
            Undefined = 0,

            [EnumMember(Value = "all_credit")]
            AllCredit,

            [EnumMember(Value = "all_transaction")]
            AllTransaction,

            [EnumMember(Value = "credit_first")]
            CreditFirst,

            [EnumMember(Value = "transaction_first")]
            TransactionFirst,

        };

        public enum ExternalPaymentMethod
        {
            Undefined = 0,

            [EnumMember(Value = "ach")]
            Ach,

            [EnumMember(Value = "amazon")]
            Amazon,

            [EnumMember(Value = "apple_pay")]
            ApplePay,

            [EnumMember(Value = "check")]
            Check,

            [EnumMember(Value = "credit_card")]
            CreditCard,

            [EnumMember(Value = "eft")]
            Eft,

            [EnumMember(Value = "money_order")]
            MoneyOrder,

            [EnumMember(Value = "other")]
            Other,

            [EnumMember(Value = "paypal")]
            Paypal,

            [EnumMember(Value = "roku")]
            Roku,

            [EnumMember(Value = "sepadirectdebit")]
            Sepadirectdebit,

            [EnumMember(Value = "wire_transfer")]
            WireTransfer,

        };

        public enum LineItemRevenueScheduleType
        {
            Undefined = 0,

            [EnumMember(Value = "at_invoice")]
            AtInvoice,

            [EnumMember(Value = "at_range_end")]
            AtRangeEnd,

            [EnumMember(Value = "at_range_start")]
            AtRangeStart,

            [EnumMember(Value = "evenly")]
            Evenly,

            [EnumMember(Value = "never")]
            Never,

        };

        public enum LegacyCategory
        {
            Undefined = 0,

            [EnumMember(Value = "applied_credit")]
            AppliedCredit,

            [EnumMember(Value = "carryforward")]
            Carryforward,

            [EnumMember(Value = "charge")]
            Charge,

            [EnumMember(Value = "credit")]
            Credit,

        };

        public enum LineItemOrigin
        {
            Undefined = 0,

            [EnumMember(Value = "add_on")]
            AddOn,

            [EnumMember(Value = "add_on_trial")]
            AddOnTrial,

            [EnumMember(Value = "carryforward")]
            Carryforward,

            [EnumMember(Value = "coupon")]
            Coupon,

            [EnumMember(Value = "credit")]
            Credit,

            [EnumMember(Value = "debit")]
            Debit,

            [EnumMember(Value = "one_time")]
            OneTime,

            [EnumMember(Value = "plan")]
            Plan,

            [EnumMember(Value = "plan_trial")]
            PlanTrial,

            [EnumMember(Value = "setup_fee")]
            SetupFee,

            [EnumMember(Value = "prepayment")]
            Prepayment,

        };

        public enum FullCreditReasonCode
        {
            Undefined = 0,

            [EnumMember(Value = "general")]
            General,

            [EnumMember(Value = "gift_card")]
            GiftCard,

            [EnumMember(Value = "promotional")]
            Promotional,

            [EnumMember(Value = "refund")]
            Refund,

            [EnumMember(Value = "service")]
            Service,

            [EnumMember(Value = "write_off")]
            WriteOff,

        };

        public enum PartialCreditReasonCode
        {
            Undefined = 0,

            [EnumMember(Value = "general")]
            General,

            [EnumMember(Value = "promotional")]
            Promotional,

            [EnumMember(Value = "service")]
            Service,

        };

        public enum LineItemCreateOrigin
        {
            Undefined = 0,

            [EnumMember(Value = "external_gift_card")]
            ExternalGiftCard,

            [EnumMember(Value = "prepayment")]
            Prepayment,

        };

        public enum IntervalUnit
        {
            Undefined = 0,

            [EnumMember(Value = "days")]
            Days,

            [EnumMember(Value = "months")]
            Months,

        };

        public enum AddressRequirement
        {
            Undefined = 0,

            [EnumMember(Value = "full")]
            Full,

            [EnumMember(Value = "none")]
            None,

            [EnumMember(Value = "streetzip")]
            Streetzip,

            [EnumMember(Value = "zip")]
            Zip,

        };

        public enum SiteMode
        {
            Undefined = 0,

            [EnumMember(Value = "development")]
            Development,

            [EnumMember(Value = "production")]
            Production,

            [EnumMember(Value = "sandbox")]
            Sandbox,

        };

        public enum Features
        {
            Undefined = 0,

            [EnumMember(Value = "credit_memos")]
            CreditMemos,

            [EnumMember(Value = "manual_invoicing")]
            ManualInvoicing,

            [EnumMember(Value = "only_bill_what_changed")]
            OnlyBillWhatChanged,

            [EnumMember(Value = "subscription_terms")]
            SubscriptionTerms,

        };

        public enum SubscriptionState
        {
            Undefined = 0,

            [EnumMember(Value = "active")]
            Active,

            [EnumMember(Value = "canceled")]
            Canceled,

            [EnumMember(Value = "expired")]
            Expired,

            [EnumMember(Value = "failed")]
            Failed,

            [EnumMember(Value = "future")]
            Future,

            [EnumMember(Value = "paused")]
            Paused,

        };

        public enum Timeframe
        {
            Undefined = 0,

            [EnumMember(Value = "bill_date")]
            BillDate,

            [EnumMember(Value = "term_end")]
            TermEnd,

        };

        public enum ChangeTimeframe
        {
            Undefined = 0,

            [EnumMember(Value = "bill_date")]
            BillDate,

            [EnumMember(Value = "now")]
            Now,

            [EnumMember(Value = "renewal")]
            Renewal,

            [EnumMember(Value = "term_end")]
            TermEnd,

        };

        public enum TransactionType
        {
            Undefined = 0,

            [EnumMember(Value = "authorization")]
            Authorization,

            [EnumMember(Value = "capture")]
            Capture,

            [EnumMember(Value = "purchase")]
            Purchase,

            [EnumMember(Value = "refund")]
            Refund,

            [EnumMember(Value = "verify")]
            Verify,

        };

        public enum TransactionOrigin
        {
            Undefined = 0,

            [EnumMember(Value = "api")]
            Api,

            [EnumMember(Value = "chargeback")]
            Chargeback,

            [EnumMember(Value = "force_collect")]
            ForceCollect,

            [EnumMember(Value = "hpp")]
            Hpp,

            [EnumMember(Value = "merchant")]
            Merchant,

            [EnumMember(Value = "recurly_admin")]
            RecurlyAdmin,

            [EnumMember(Value = "recurlyjs")]
            Recurlyjs,

            [EnumMember(Value = "recurring")]
            Recurring,

            [EnumMember(Value = "refunded_externally")]
            RefundedExternally,

            [EnumMember(Value = "transparent")]
            Transparent,

        };

        public enum TransactionStatus
        {
            Undefined = 0,

            [EnumMember(Value = "chargeback")]
            Chargeback,

            [EnumMember(Value = "declined")]
            Declined,

            [EnumMember(Value = "error")]
            Error,

            [EnumMember(Value = "pending")]
            Pending,

            [EnumMember(Value = "processing")]
            Processing,

            [EnumMember(Value = "scheduled")]
            Scheduled,

            [EnumMember(Value = "success")]
            Success,

            [EnumMember(Value = "void")]
            Void,

        };

        public enum CvvCheck
        {
            Undefined = 0,

            [EnumMember(Value = "D")]
            D,

            [EnumMember(Value = "I")]
            I,

            [EnumMember(Value = "M")]
            M,

            [EnumMember(Value = "N")]
            N,

            [EnumMember(Value = "P")]
            P,

            [EnumMember(Value = "S")]
            S,

            [EnumMember(Value = "U")]
            U,

            [EnumMember(Value = "X")]
            X,

        };

        public enum AvsCheck
        {
            Undefined = 0,

            [EnumMember(Value = "A")]
            A,

            [EnumMember(Value = "B")]
            B,

            [EnumMember(Value = "C")]
            C,

            [EnumMember(Value = "D")]
            D,

            [EnumMember(Value = "E")]
            E,

            [EnumMember(Value = "F")]
            F,

            [EnumMember(Value = "G")]
            G,

            [EnumMember(Value = "H")]
            H,

            [EnumMember(Value = "I")]
            I,

            [EnumMember(Value = "J")]
            J,

            [EnumMember(Value = "K")]
            K,

            [EnumMember(Value = "L")]
            L,

            [EnumMember(Value = "M")]
            M,

            [EnumMember(Value = "N")]
            N,

            [EnumMember(Value = "O")]
            O,

            [EnumMember(Value = "P")]
            P,

            [EnumMember(Value = "Q")]
            Q,

            [EnumMember(Value = "R")]
            R,

            [EnumMember(Value = "S")]
            S,

            [EnumMember(Value = "T")]
            T,

            [EnumMember(Value = "U")]
            U,

            [EnumMember(Value = "V")]
            V,

            [EnumMember(Value = "W")]
            W,

            [EnumMember(Value = "X")]
            X,

            [EnumMember(Value = "Y")]
            Y,

            [EnumMember(Value = "Z")]
            Z,

        };

        public enum CouponCodeState
        {
            Undefined = 0,

            [EnumMember(Value = "expired")]
            Expired,

            [EnumMember(Value = "inactive")]
            Inactive,

            [EnumMember(Value = "maxed_out")]
            MaxedOut,

            [EnumMember(Value = "redeemable")]
            Redeemable,

        };

        public enum PaymentMethod
        {
            Undefined = 0,

            [EnumMember(Value = "amazon")]
            Amazon,

            [EnumMember(Value = "amazon_billing_agreement")]
            AmazonBillingAgreement,

            [EnumMember(Value = "apple_pay")]
            ApplePay,

            [EnumMember(Value = "bank_account_info")]
            BankAccountInfo,

            [EnumMember(Value = "check")]
            Check,

            [EnumMember(Value = "credit_card")]
            CreditCard,

            [EnumMember(Value = "eft")]
            Eft,

            [EnumMember(Value = "gateway_token")]
            GatewayToken,

            [EnumMember(Value = "iban_bank_account")]
            IbanBankAccount,

            [EnumMember(Value = "money_order")]
            MoneyOrder,

            [EnumMember(Value = "other")]
            Other,

            [EnumMember(Value = "paypal")]
            Paypal,

            [EnumMember(Value = "paypal_billing_agreement")]
            PaypalBillingAgreement,

            [EnumMember(Value = "roku")]
            Roku,

            [EnumMember(Value = "sepadirectdebit")]
            Sepadirectdebit,

            [EnumMember(Value = "wire_transfer")]
            WireTransfer,

        };

        public enum CardType
        {
            Undefined = 0,

            [EnumMember(Value = "American Express")]
            AmericanExpress,

            [EnumMember(Value = "Dankort")]
            Dankort,

            [EnumMember(Value = "Diners Club")]
            DinersClub,

            [EnumMember(Value = "Discover")]
            Discover,

            [EnumMember(Value = "Forbrugsforeningen")]
            Forbrugsforeningen,

            [EnumMember(Value = "JCB")]
            Jcb,

            [EnumMember(Value = "Laser")]
            Laser,

            [EnumMember(Value = "Maestro")]
            Maestro,

            [EnumMember(Value = "MasterCard")]
            Mastercard,

            [EnumMember(Value = "Test Card")]
            TestCard,

            [EnumMember(Value = "Union Pay")]
            UnionPay,

            [EnumMember(Value = "Unknown")]
            Unknown,

            [EnumMember(Value = "Visa")]
            Visa,

        };

        public enum AccountType
        {
            Undefined = 0,

            [EnumMember(Value = "checking")]
            Checking,

            [EnumMember(Value = "savings")]
            Savings,

        };

        public enum ErrorType
        {
            Undefined = 0,

            [EnumMember(Value = "bad_request")]
            BadRequest,

            [EnumMember(Value = "immutable_subscription")]
            ImmutableSubscription,

            [EnumMember(Value = "internal_server_error")]
            InternalServerError,

            [EnumMember(Value = "invalid_api_key")]
            InvalidApiKey,

            [EnumMember(Value = "invalid_api_version")]
            InvalidApiVersion,

            [EnumMember(Value = "invalid_content_type")]
            InvalidContentType,

            [EnumMember(Value = "invalid_permissions")]
            InvalidPermissions,

            [EnumMember(Value = "invalid_token")]
            InvalidToken,

            [EnumMember(Value = "missing_feature")]
            MissingFeature,

            [EnumMember(Value = "not_found")]
            NotFound,

            [EnumMember(Value = "rate_limited")]
            RateLimited,

            [EnumMember(Value = "service_not_available")]
            ServiceNotAvailable,

            [EnumMember(Value = "simultaneous_request")]
            SimultaneousRequest,

            [EnumMember(Value = "transaction")]
            Transaction,

            [EnumMember(Value = "unauthorized")]
            Unauthorized,

            [EnumMember(Value = "unavailable_in_api_version")]
            UnavailableInApiVersion,

            [EnumMember(Value = "unknown_api_version")]
            UnknownApiVersion,

            [EnumMember(Value = "validation")]
            Validation,

        };

        public enum ErrorCategory
        {
            Undefined = 0,

            [EnumMember(Value = "three_d_secure_required")]
            ThreeDSecureRequired,

            [EnumMember(Value = "three_d_secure_action_required")]
            ThreeDSecureActionRequired,

            [EnumMember(Value = "amazon")]
            Amazon,

            [EnumMember(Value = "api_error")]
            ApiError,

            [EnumMember(Value = "approved")]
            Approved,

            [EnumMember(Value = "communication")]
            Communication,

            [EnumMember(Value = "configuration")]
            Configuration,

            [EnumMember(Value = "duplicate")]
            Duplicate,

            [EnumMember(Value = "fraud")]
            Fraud,

            [EnumMember(Value = "hard")]
            Hard,

            [EnumMember(Value = "invalid")]
            Invalid,

            [EnumMember(Value = "not_enabled")]
            NotEnabled,

            [EnumMember(Value = "not_supported")]
            NotSupported,

            [EnumMember(Value = "recurly")]
            Recurly,

            [EnumMember(Value = "referral")]
            Referral,

            [EnumMember(Value = "skles")]
            Skles,

            [EnumMember(Value = "soft")]
            Soft,

            [EnumMember(Value = "unknown")]
            Unknown,

        };

        public enum ErrorCode
        {
            Undefined = 0,

            [EnumMember(Value = "ach_cancel")]
            AchCancel,

            [EnumMember(Value = "ach_chargeback")]
            AchChargeback,

            [EnumMember(Value = "ach_credit_return")]
            AchCreditReturn,

            [EnumMember(Value = "ach_exception")]
            AchException,

            [EnumMember(Value = "ach_return")]
            AchReturn,

            [EnumMember(Value = "ach_transactions_not_supported")]
            AchTransactionsNotSupported,

            [EnumMember(Value = "ach_validation_exception")]
            AchValidationException,

            [EnumMember(Value = "amazon_amount_exceeded")]
            AmazonAmountExceeded,

            [EnumMember(Value = "amazon_invalid_authorization_status")]
            AmazonInvalidAuthorizationStatus,

            [EnumMember(Value = "amazon_invalid_close_attempt")]
            AmazonInvalidCloseAttempt,

            [EnumMember(Value = "amazon_invalid_create_order_reference")]
            AmazonInvalidCreateOrderReference,

            [EnumMember(Value = "amazon_invalid_order_status")]
            AmazonInvalidOrderStatus,

            [EnumMember(Value = "amazon_not_authorized")]
            AmazonNotAuthorized,

            [EnumMember(Value = "amazon_order_not_modifiable")]
            AmazonOrderNotModifiable,

            [EnumMember(Value = "amazon_transaction_count_exceeded")]
            AmazonTransactionCountExceeded,

            [EnumMember(Value = "api_error")]
            ApiError,

            [EnumMember(Value = "approved")]
            Approved,

            [EnumMember(Value = "approved_fraud_review")]
            ApprovedFraudReview,

            [EnumMember(Value = "authorization_already_captured")]
            AuthorizationAlreadyCaptured,

            [EnumMember(Value = "authorization_amount_depleted")]
            AuthorizationAmountDepleted,

            [EnumMember(Value = "authorization_expired")]
            AuthorizationExpired,

            [EnumMember(Value = "batch_processing_error")]
            BatchProcessingError,

            [EnumMember(Value = "billing_agreement_already_accepted")]
            BillingAgreementAlreadyAccepted,

            [EnumMember(Value = "billing_agreement_not_accepted")]
            BillingAgreementNotAccepted,

            [EnumMember(Value = "call_issuer")]
            CallIssuer,

            [EnumMember(Value = "call_issuer_update_cardholder_data")]
            CallIssuerUpdateCardholderData,

            [EnumMember(Value = "cannot_refund_unsettled_transactions")]
            CannotRefundUnsettledTransactions,

            [EnumMember(Value = "card_not_activated")]
            CardNotActivated,

            [EnumMember(Value = "card_type_not_accepted")]
            CardTypeNotAccepted,

            [EnumMember(Value = "cardholder_requested_stop")]
            CardholderRequestedStop,

            [EnumMember(Value = "contact_gateway")]
            ContactGateway,

            [EnumMember(Value = "currency_not_supported")]
            CurrencyNotSupported,

            [EnumMember(Value = "customer_canceled_transaction")]
            CustomerCanceledTransaction,

            [EnumMember(Value = "cvv_required")]
            CvvRequired,

            [EnumMember(Value = "declined")]
            Declined,

            [EnumMember(Value = "declined_card_number")]
            DeclinedCardNumber,

            [EnumMember(Value = "declined_exception")]
            DeclinedException,

            [EnumMember(Value = "declined_expiration_date")]
            DeclinedExpirationDate,

            [EnumMember(Value = "declined_missing_data")]
            DeclinedMissingData,

            [EnumMember(Value = "declined_saveable")]
            DeclinedSaveable,

            [EnumMember(Value = "declined_security_code")]
            DeclinedSecurityCode,

            [EnumMember(Value = "deposit_referenced_chargeback")]
            DepositReferencedChargeback,

            [EnumMember(Value = "duplicate_transaction")]
            DuplicateTransaction,

            [EnumMember(Value = "exceeds_daily_limit")]
            ExceedsDailyLimit,

            [EnumMember(Value = "expired_card")]
            ExpiredCard,

            [EnumMember(Value = "finbot_unavailable")]
            FinbotUnavailable,

            [EnumMember(Value = "fraud_address")]
            FraudAddress,

            [EnumMember(Value = "fraud_address_recurly")]
            FraudAddressRecurly,

            [EnumMember(Value = "fraud_advanced_verification")]
            FraudAdvancedVerification,

            [EnumMember(Value = "fraud_gateway")]
            FraudGateway,

            [EnumMember(Value = "fraud_generic")]
            FraudGeneric,

            [EnumMember(Value = "fraud_ip_address")]
            FraudIpAddress,

            [EnumMember(Value = "fraud_risk_check")]
            FraudRiskCheck,

            [EnumMember(Value = "fraud_security_code")]
            FraudSecurityCode,

            [EnumMember(Value = "fraud_stolen_card")]
            FraudStolenCard,

            [EnumMember(Value = "fraud_too_many_attempts")]
            FraudTooManyAttempts,

            [EnumMember(Value = "fraud_velocity")]
            FraudVelocity,

            [EnumMember(Value = "gateway_error")]
            GatewayError,

            [EnumMember(Value = "gateway_rate_limited")]
            GatewayRateLimited,

            [EnumMember(Value = "gateway_timeout")]
            GatewayTimeout,

            [EnumMember(Value = "gateway_token_not_found")]
            GatewayTokenNotFound,

            [EnumMember(Value = "gateway_unavailable")]
            GatewayUnavailable,

            [EnumMember(Value = "insufficient_funds")]
            InsufficientFunds,

            [EnumMember(Value = "invalid_account_number")]
            InvalidAccountNumber,

            [EnumMember(Value = "invalid_amount")]
            InvalidAmount,

            [EnumMember(Value = "invalid_card_number")]
            InvalidCardNumber,

            [EnumMember(Value = "invalid_data")]
            InvalidData,

            [EnumMember(Value = "invalid_email")]
            InvalidEmail,

            [EnumMember(Value = "invalid_gateway_configuration")]
            InvalidGatewayConfiguration,

            [EnumMember(Value = "invalid_issuer")]
            InvalidIssuer,

            [EnumMember(Value = "invalid_login")]
            InvalidLogin,

            [EnumMember(Value = "invalid_merchant_type")]
            InvalidMerchantType,

            [EnumMember(Value = "invalid_transaction")]
            InvalidTransaction,

            [EnumMember(Value = "issuer_unavailable")]
            IssuerUnavailable,

            [EnumMember(Value = "merch_max_transaction_limit_exceeded")]
            MerchMaxTransactionLimitExceeded,

            [EnumMember(Value = "moneybot_unavailable")]
            MoneybotUnavailable,

            [EnumMember(Value = "no_billing_information")]
            NoBillingInformation,

            [EnumMember(Value = "no_gateway")]
            NoGateway,

            [EnumMember(Value = "no_gateway_found_for_transaction_amount")]
            NoGatewayFoundForTransactionAmount,

            [EnumMember(Value = "partial_approval")]
            PartialApproval,

            [EnumMember(Value = "partial_credits_not_supported")]
            PartialCreditsNotSupported,

            [EnumMember(Value = "payment_cannot_void_authorization")]
            PaymentCannotVoidAuthorization,

            [EnumMember(Value = "payment_not_accepted")]
            PaymentNotAccepted,

            [EnumMember(Value = "paypal_account_issue")]
            PaypalAccountIssue,

            [EnumMember(Value = "paypal_cannot_pay_self")]
            PaypalCannotPaySelf,

            [EnumMember(Value = "paypal_declined_use_alternate")]
            PaypalDeclinedUseAlternate,

            [EnumMember(Value = "paypal_expired_reference_id")]
            PaypalExpiredReferenceId,

            [EnumMember(Value = "paypal_hard_decline")]
            PaypalHardDecline,

            [EnumMember(Value = "paypal_invalid_billing_agreement")]
            PaypalInvalidBillingAgreement,

            [EnumMember(Value = "paypal_primary_declined")]
            PaypalPrimaryDeclined,

            [EnumMember(Value = "processor_unavailable")]
            ProcessorUnavailable,

            [EnumMember(Value = "recurly_error")]
            RecurlyError,

            [EnumMember(Value = "recurly_failed_to_get_token")]
            RecurlyFailedToGetToken,

            [EnumMember(Value = "recurly_token_mismatch")]
            RecurlyTokenMismatch,

            [EnumMember(Value = "recurly_token_not_found")]
            RecurlyTokenNotFound,

            [EnumMember(Value = "reference_transactions_not_enabled")]
            ReferenceTransactionsNotEnabled,

            [EnumMember(Value = "restricted_card")]
            RestrictedCard,

            [EnumMember(Value = "restricted_card_chargeback")]
            RestrictedCardChargeback,

            [EnumMember(Value = "simultaneous")]
            Simultaneous,

            [EnumMember(Value = "ssl_error")]
            SslError,

            [EnumMember(Value = "temporary_hold")]
            TemporaryHold,

            [EnumMember(Value = "three_d_secure_authentication")]
            ThreeDSecureAuthentication,

            [EnumMember(Value = "three_d_secure_not_supported")]
            ThreeDSecureNotSupported,

            [EnumMember(Value = "too_many_attempts")]
            TooManyAttempts,

            [EnumMember(Value = "total_credit_exceeds_capture")]
            TotalCreditExceedsCapture,

            [EnumMember(Value = "transaction_already_refunded")]
            TransactionAlreadyRefunded,

            [EnumMember(Value = "transaction_already_voided")]
            TransactionAlreadyVoided,

            [EnumMember(Value = "transaction_cannot_be_authorized")]
            TransactionCannotBeAuthorized,

            [EnumMember(Value = "transaction_cannot_be_refunded")]
            TransactionCannotBeRefunded,

            [EnumMember(Value = "transaction_cannot_be_refunded_currently")]
            TransactionCannotBeRefundedCurrently,

            [EnumMember(Value = "transaction_cannot_be_voided")]
            TransactionCannotBeVoided,

            [EnumMember(Value = "transaction_failed_to_settle")]
            TransactionFailedToSettle,

            [EnumMember(Value = "transaction_not_found")]
            TransactionNotFound,

            [EnumMember(Value = "transaction_settled")]
            TransactionSettled,

            [EnumMember(Value = "transaction_stale_at_gateway")]
            TransactionStaleAtGateway,

            [EnumMember(Value = "try_again")]
            TryAgain,

            [EnumMember(Value = "unknown")]
            Unknown,

            [EnumMember(Value = "vaultly_service_unavailable")]
            VaultlyServiceUnavailable,

            [EnumMember(Value = "zero_dollar_auth_not_supported")]
            ZeroDollarAuthNotSupported,

        };

        public enum TaxIdentifierType
        {
            Undefined = 0,

            [EnumMember(Value = "cpf")]
            Cpf,

        };

    }
}
