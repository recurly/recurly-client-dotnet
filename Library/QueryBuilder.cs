using System.Text;

namespace Recurly
{
    /// <summary>
    /// Provides a fluent syntax for creating a query string for a request, automatically adding ? and & characters. Skips null or empty strings.
    /// </summary>
    internal class QueryStringBuilder
    {
        internal QueryStringBuilderContext QueryStringWith(string element)
        {
            return new QueryStringBuilderContext().AndWith(element);
        }
    }

    internal class QueryStringBuilderContext
    {
        private readonly StringBuilder _queryString;
        private char _start;
        public QueryStringBuilderContext()
        {
            _queryString = new StringBuilder();
            _start = '?';
        }

        public QueryStringBuilderContext AndWith(string element)
        {
            if (element.IsNullOrEmpty()) return this;
            _queryString.Append(_start).Append(element);
            if (_start == '?')
                _start = '&';
            return this;
        }

        public string Build()
        {
            return _queryString.ToString();
        }

        public override string ToString()
        {
            return Build();
        }
    }
}
