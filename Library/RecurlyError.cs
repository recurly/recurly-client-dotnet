using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An individual error message.
    /// For more information, please visit http://docs.recurly.com/api/errors
    /// </summary>
    public class RecurlyError
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; internal set; }
        /// <summary>
        /// Field causing the error, if appropriate.
        /// </summary>
        public string Field { get; internal set; }
        /// <summary>
        /// Error code set for certain transaction failures.
        /// </summary>
        public string Code { get; internal set; }

        internal RecurlyError(XmlTextReader reader)
        {
            if (reader.HasAttributes)
            {
                try
                {
                    this.Field = reader.GetAttribute("field");
                }
                catch (ArgumentOutOfRangeException)
                { }
                try
                {
                    this.Code = reader.GetAttribute("code");
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            this.Message = reader.ReadElementContentAsString();
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.Field))
                return String.Format("{0} (Field: {1})", this.Message, this.Field);
            else if (!String.IsNullOrEmpty(this.Code))
                return String.Format("{0} (Code: {1})", this.Message, this.Code);
            else
                return this.Message;
        }

        internal static RecurlyError[] ReadResponseAndParseErrors(HttpWebResponse response)
        {
            if (response == null)
                return new RecurlyError[0];

            using (Stream responseStream = response.GetResponseStream())
            {
                List<RecurlyError> errors = new List<RecurlyError>();

                try
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(responseStream))
                    {
                        // Parse errors collection
                        while (xmlReader.Read())
                        {
                            if (xmlReader.Name == "errors" && xmlReader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (xmlReader.Name == "error" && xmlReader.NodeType == XmlNodeType.Element)
                                errors.Add(new RecurlyError(xmlReader));
                        }
                    }
                }
                catch (XmlException)
                {
                    // Do nothing
                }

                return errors.ToArray();
            }
        }
    }
}
