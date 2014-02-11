using System.Xml;

namespace Recurly
{
    public class NoteList : RecurlyList<Note>
    {
        public NoteList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
            
        }

        public override RecurlyList<Note> Start
        {
            get { return HasStartPage() ? new NoteList(StartUrl) : RecurlyList.Empty<Note>(); }
        }

        public override RecurlyList<Note> Next
        {
            get { return HasNextPage() ? new NoteList(NextUrl) : RecurlyList.Empty<Note>(); }
        }

        public override RecurlyList<Note> Prev
        {
            get { return HasPrevPage() ? new NoteList(PrevUrl) : RecurlyList.Empty<Note>(); }
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
