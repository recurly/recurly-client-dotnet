using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurly
{
    public class FilterCriteria
    {
        public enum Sort
        {
            CreatedAt,
            UpdatedAt
        }

        public enum Order
        {
            Asc,
            Desc
        }

        public Sort? SortField;
        public Order? OrderField;
        public DateTime? BeginTime;
        public DateTime? EndTime;

        private FilterCriteria() { }

        public static FilterCriteria Instance { get { return new FilterCriteria(); } }

        public NameValueCollection ToNamedValueCollection()
        {
            var nvc = System.Web.HttpUtility.ParseQueryString(string.Empty);
            if (SortField.HasValue) nvc["sort"] = SortField.Value.ToString().EnumNameToTransportCase();
            if (OrderField.HasValue) nvc["order"] = OrderField.Value.ToString().EnumNameToTransportCase();
            if (BeginTime.HasValue) nvc["begin_time"] = BeginTime.Value.ToString("s");
            if (EndTime.HasValue) nvc["end_time"] = EndTime.Value.ToString("s");
            return nvc;
        }

        public FilterCriteria WithSort(Sort sort)
        {
            SortField = sort;
            return this;
        }

        public FilterCriteria WithOrder(Order order)
        {
            OrderField = order;
            return this;
        }

        public FilterCriteria WithBeginTime(DateTime begin)
        {
            BeginTime = begin;
            return this;
        }

        public FilterCriteria WithEndTime(DateTime end)
        {
            EndTime = end;
            return this;
        }
    }
}
