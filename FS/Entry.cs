using System.Collections.Generic;
using backend_test.Models;

namespace backend_test.FS
{
    public abstract class Entry
    {
        public string Name { get; set; }

        protected Entry(string name)
        {
            Name = name;
        }

        public abstract List<Entry> ListFsEntry(string path);
        public abstract Entry CreateEntry(string path, CreateEntry entry);
        public abstract string GetEntryContent(string path);
        public abstract Entry ModifyEntry(string path, CreateEntry entry);
        public abstract Entry DeleteEntry(string path);
    }
}