using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    public static class XmlWriterExtensions
    {
        /// <summary>
        /// Convenience implementation of <see cref="T:System.Xml.XmlWriter.WriteElementString(string, string)"/> that guards it with
        /// a check if <paramref name="value"/> is null or empty, writing the value if it is not null or empty.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> that will be written to.</param>
        /// <param name="localName"></param>
        /// <param name="value"></param>
        public static void WriteStringIfValid(this XmlWriter writer, string localName, string value)
        {
            if (!value.IsNullOrEmpty())
                writer.WriteElementString(localName, value);
        }

        /// <summary>
        /// If the given collection <paramref name="items"/> has any elements, writes the contents to the <see cref="T:System.Xml.XmlTextWriter"/> <paramref name="writer"/>
        /// using the provided <paramref name="localName"/> and <paramref name="stringValue"/> <see cref="T:System.Func{T,TResult}"/>s.
        /// </summary>
        /// <typeparam name="T">The type of elements in <paramref name="items"/>.</typeparam>
        /// <param name="writer">The <see cref="T:System.Xml.XmlTextWriter"/> to write to.</param>
        /// <param name="collectionName">The value to use for the encompassing XML tag if the collection is written.</param>
        /// <param name="items">The collection to test and then write if it has any elements</param>
        /// <param name="localName">A <see cref="T:System.Func{T,TResult}"/> that provides the localName for the XML element written for each item.</param>
        /// <param name="stringValue">A <see cref="T:System.Func{T,TResult}"/> that provides the value for the XML element written for each item.</param>
        public static void WriteIfCollectionHasAny<T>(this XmlTextWriter writer, string collectionName, IEnumerable<T> items,
            Func<T, string> localName, Func<T, string> stringValue)
        {
            if (!items.HasAny()) return;
            writer.WriteStartElement(collectionName);
            foreach (var item in items)
            {
                writer.WriteElementString(localName(item), stringValue(item));
            }
            writer.WriteEndElement();
        }

        /// <summary>
        /// If the given collection has any elements, writes the contents of the <paramref name="items"/> to the <see cref="T:System.Xml.XmlTextWriter"/> 
        /// using each element's <see cref="Recurly.RecurlyEntity.WriteXml"/> implementation.
        /// </summary>
        /// <typeparam name="T">The type of each element of <paramref name="items"/>, derived from <see cref="Recurly.RecurlyEntity"/>.</typeparam>
        /// <param name="writer">The <see cref="T:System.Xml.XmlTextWriter"/> to write to.</param>
        /// <param name="collectionName">The value to use for the encompassing XML tag if the collection is written.</param>
        /// <param name="items">The collection to test and then write if it has any elements.</param>
        public static void WriteIfCollectionHasAny<T>(this XmlTextWriter writer, string collectionName, IEnumerable<T> items)
            where T : RecurlyEntity
        {
            if (!items.HasAny()) return;
            WriteCollection(writer, collectionName, items);
        }

        /// <summary>
        /// If the given collection has any elements, writes the contents of the <paramref name="items"/> to the <see cref="T:System.Xml.XmlTextWriter"/> 
        /// using each element's <see cref="Recurly.RecurlyEntity.WriteXml"/> implementation. If the collection needs to write an empty element for an empty collection, it will do so.
        /// </summary>
        /// <typeparam name="T">The type of each element of <paramref name="items"/>, derived from <see cref="Recurly.RecurlyEntity"/>.</typeparam>
        /// <param name="writer">The <see cref="T:System.Xml.XmlTextWriter"/> to write to.</param>
        /// <param name="collectionName">The value to use for the encompassing XML tag if the collection is written.</param>
        /// <param name="items">The collection to test and then write if it has any elements.</param>
        public static void WriteIfCollectionHasAny<T>(this XmlTextWriter writer, string collectionName, RecurlyList<T> items)
            where T : RecurlyEntity
        {
            if (!items.includeEmptyTag() && !items.HasAny()) return;
            WriteCollection(writer, collectionName, items);
        }

        private static void WriteCollection<T>(this XmlTextWriter writer, string collectionName, IEnumerable<T> items)
            where T : RecurlyEntity
        {
            writer.WriteStartElement(collectionName);
            foreach (var item in items)
            {
                item.WriteXml(writer);
            }
            writer.WriteEndElement();
        }
    }
}