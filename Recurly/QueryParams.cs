/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;

public class QueryParams
{
    private Dictionary<string, object> Params = new Dictionary<string, object>();

    internal Dictionary<string, object> ToDictionary()
    {
        return Params;
    }


    /// <value>
    /// Filter results by their IDs. Up to 200 IDs can be passed at once using
    /// commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.
    /// 
    /// **Important notes:**
    /// 
    /// * The `ids` parameter cannot be used with any other ordering or filtering
    ///   parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)
    /// * Invalid or unknown IDs will be ignored, so you should check that the
    ///   results correspond to your request.
    /// * Records are returned in an arbitrary order. Since results are all
    ///   returned at once you can sort the records yourself.
    /// </value>
    public string Ids
    {
        set
        {
            Params.Add("ids", value);
        }
    }

    /// <value>Limit number of records 1-200.</value>
    public int Limit
    {
        set
        {
            Params.Add("limit", value);
        }
    }

    /// <value>Sort order.</value>
    public string Order
    {
        set
        {
            Params.Add("order", value);
        }
    }

    /// <value>
    /// Sort field. You *really* only want to sort by `updated_at` in ascending
    /// order. In descending order updated records will move behind the cursor and could
    /// prevent some records from being returned.
    /// </value>
    public string Sort
    {
        set
        {
            Params.Add("sort", value);
        }
    }

    /// <value>
    /// Filter by begin_time when `sort=created_at` or `sort=updated_at`.
    /// **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.
    /// </value>
    public DateTime BeginTime
    {
        set
        {
            Params.Add("begin_time", value);
        }
    }

    /// <value>
    /// Filter by end_time when `sort=created_at` or `sort=updated_at`.
    /// **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.
    /// </value>
    public DateTime EndTime
    {
        set
        {
            Params.Add("end_time", value);
        }
    }

    /// <value>
    /// Filter accounts with or without a subscription in the `active`,
    /// `canceled`, or `future` state.
    /// </value>
    public string Subscriber
    {
        set
        {
            Params.Add("subscriber", value);
        }
    }

    /// <value>Filter for accounts with an invoice in the `past_due` state.</value>
    public string PastDue
    {
        set
        {
            Params.Add("past_due", value);
        }
    }

    /// <value>
    /// Filter by type when:
    /// - `type=charge`, only charge invoices will be returned.
    /// - `type=credit`, only credit invoices will be returned.
    /// - `type=non-legacy`, only charge and credit invoices will be returned.
    /// - `type=legacy`, only legacy invoices will be returned.
    /// </value>
    public string Type
    {
        set
        {
            Params.Add("type", value);
        }
    }

    /// <value>Filter by original field.</value>
    public string Original
    {
        set
        {
            Params.Add("original", value);
        }
    }

    /// <value>Filter by state field.</value>
    public string State
    {
        set
        {
            Params.Add("state", value);
        }
    }

    /// <value>Filter by success field.</value>
    public string Success
    {
        set
        {
            Params.Add("success", value);
        }
    }

    /// <value>
    /// The type of refund to perform:
    /// 
    /// * `full` - Performs a full refund of the last invoice for the current subscription term.
    /// * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.
    /// * `none` - Terminates the subscription without a refund.
    /// 
    /// In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.
    /// 
    /// You may also terminate a subscription with no refund and then manually refund specific invoices.
    /// </value>
    public string Refund
    {
        set
        {
            Params.Add("refund", value);
        }
    }
}
