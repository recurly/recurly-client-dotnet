using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Recurly
{
    public abstract class RecurlyList<T> : List<T>
    {

        /// <summary>
        ///  When paging
        /// </summary>
        private string _baseUrl;

        public RecurlyList()
            : base()
        {

        }

        public RecurlyList(string url)
            : base()
        {
            this._baseUrl = url;
        }

        private int _requestLimit = 50;

        /// <summary>
        /// TODO: implement 
        /// </summary>
        public int RequestLimit
        {
            get
            {
                return _requestLimit;
            }
            set
            {
                if (value <= 1 || value > 200)
                    throw new ArgumentOutOfRangeException("Request limit must be between 1 and 200.");
                else
                    _requestLimit = value;
            }
        }

    }
}
