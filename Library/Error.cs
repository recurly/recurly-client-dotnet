using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An individual error message.
    /// For more information, please visit https://dev.recurly.com/docs/api-validation-errors
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Field causing the error, if appropriate.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Error code set for certain transaction failures.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Error details
        /// </summary>
        public string Details { get; set; }

        public Error() { }

        internal Error(XmlTextReader reader, bool fromList)
        {
            if (fromList)
            {
                // list of errors returned
                // <errors>
                //    <error field="model_name.field_name" symbol="not_a_number" lang="en-US">is not a number</error>
                // </errors>
                if (reader.HasAttributes)
                {
                    Field = ReadAttr("field", reader);
                    Code = ReadAttr("code", reader);
                    Symbol = ReadAttr("symbol", reader);
                }

                Message = reader.ReadElementContentAsString();
                return;
            }

            // single error returned
            // <error>
            //    <symbol>asdf</symbol>
            //    <description>asdfasdf</description>
            //    <details>asdfasdfasdfasdf</details>
            // </error>
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "symbol":
                        Symbol = reader.ReadElementContentAsString();
                        break;
                    case "description":
                        Message = reader.ReadElementContentAsString();
                        break;
                    case "details":
                        Details = reader.ReadElementContentAsString();
                        break;
                }

                if (reader.Name == "error" && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} | Field: \"{1}\" Code: \"{2}\" Symbol: \"{3}\" Details: \"{4}\""
                , Message, Field, Code, Symbol, Details);
        }

        internal static Error[] ParseErrors(XmlTextReader xmlReader)
        {
 
            var errors = new List<Error>();                  
            bool list = false;

            while (xmlReader.Read())
            {
                if (xmlReader.Name == "errors" && xmlReader.NodeType == XmlNodeType.EndElement)
                    break;

                if (xmlReader.Name == "errors" && xmlReader.NodeType == XmlNodeType.Element)
                    list = true;

                if (xmlReader.Name == "error" && xmlReader.NodeType == XmlNodeType.Element)
                    errors.Add(new Error(xmlReader, list));
            }

            return errors.ToArray();          
        }

        /// <summary>
        /// Reads the attribute with the given `name` from the `reader` without throwing
        /// </summary>
        /// <param name="name"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        private string ReadAttr(string name, XmlTextReader reader)
        {
            try
            {
                return reader.GetAttribute(name);
            }
            catch (ArgumentOutOfRangeException)
            {
                return "";
            }
        }

    }
}
