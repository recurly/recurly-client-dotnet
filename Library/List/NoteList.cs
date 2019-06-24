using System.Xml;

namespace Recurly
{
    public class NoteList : RecurlyList<INote>
    {
        public NoteList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {

        }

        public override IRecurlyList<INote> Start
        {
            get { return HasStartPage() ? new NoteList(StartUrl) : RecurlyList.Empty<INote>(); }
        }

        public override IRecurlyList<INote> Next
        {
            get { return HasNextPage() ? new NoteList(NextUrl) : RecurlyList.Empty<INote>(); }
        }

        public override IRecurlyList<INote> Prev
        {
            get { return HasPrevPage() ? new NoteList(PrevUrl) : RecurlyList.Empty<INote>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "notes" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "note")
                {
                    Add(new Note(reader));
                }
            }
        }
    }
}
