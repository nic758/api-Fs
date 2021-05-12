using System.Collections.Generic;
using backend_test.Models;

namespace backend_test.FS
{
    public class File : Entry
    {
        public string Content { get; set; }


        public File(string name, string content) : base(name)
        {
            Content = content;
        }

        public override List<Entry> ListFsEntry(string path)
        {
            return new List<Entry>(){this};
        }

        public override Entry CreateEntry(string path, CreateEntry entry)
        {
            throw new System.NotImplementedException();
        }

        public override string GetEntryContent(string path)
        {
            return Content;
        }

        public override Entry ModifyEntry(string path, CreateEntry entry)
        {
            throw new System.NotImplementedException();
        }

        public override Entry DeleteEntry(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}