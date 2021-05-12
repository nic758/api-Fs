using System;
using System.Collections.Generic;
using System.Linq;
using backend_test.Helpers;
using backend_test.Models;
using Microsoft.VisualBasic;

namespace backend_test.FS
{
    public class Directory : Entry
    {
        public Dictionary<string, Entry> Files { get; set; }
        private EntryFactory _factory = new EntryFactory();

        public Directory(string name) : base(name)
        {
            Files = new Dictionary<string, Entry>();
        }


        public override List<Entry> ListFsEntry(string path)
        {
            if (path != null && path.Length != 0)
            {
                string[] words = path.Split("/");

                if (Files.TryGetValue(words[0], out Entry e))
                {
                    var newpath = Helper.SubArray(words, 1, words.Length - 1);
                    return e.ListFsEntry(Strings.Join(newpath, "/"));
                }

                throw new Exception("not found");
            }

            return Files.Values.ToList();
        }

        public override Entry CreateEntry(string path, CreateEntry entry)
        {
            if (path != null)
            {
                string[] words = path.Split("/");

                if (Files.TryGetValue(words[0], out Entry ent))
                {
                    var newpath = Helper.SubArray(words, 1, words.Length - 1);
                    return ent.CreateEntry(Strings.Join(newpath, "/"), entry);
                }

                throw new Exception("could not find the path");
            }

            var e = _factory.Create(entry);
            if (Files.TryAdd(e.Name, e))
            {
                return e;
            }

            throw new Exception("an entry with the same name already exist");
        }

        public override string GetEntryContent(string path)
        {
            if (path != null)
            {
                string[] words = path.Split("/");

                if (Files.TryGetValue(words[0], out Entry ent))
                {
                    var newpath = Helper.SubArray(words, 1, words.Length - 1);
                    return ent.GetEntryContent(Strings.Join(newpath, "/"));
                }

                throw new Exception("could not find the path");
            }

            throw new Exception("Entry not found");
        }

        public override Entry ModifyEntry(string path, CreateEntry entry)
        {
            if (path != null)
            {
                string[] words = path.Split("/");

                if (Files.TryGetValue(words[0], out Entry ent))
                {
                    var newpath = Helper.SubArray(words, 1, words.Length - 1);
                    var joinedPath = Strings.Join(newpath, "/");
                    if (joinedPath != null)
                    {
                        return ent.ModifyEntry(joinedPath, entry);
                    }

                    Files.Remove(words[0]);
                    return CreateEntry(null, entry);
                }

                throw new Exception("could not find the path");
            }

            throw new Exception("entry should not be null");
        }

        public override Entry DeleteEntry(string path)
        {
            if (path != null)
            {
                string[] words = path.Split("/");

                if (Files.TryGetValue(words[0], out Entry ent))
                {
                    var newpath = Helper.SubArray(words, 1, words.Length - 1);
                    var joinedPath = Strings.Join(newpath, "/");
                    if (joinedPath != null)
                    {
                        return ent.DeleteEntry(joinedPath);
                    }

                    if (ent.GetType() == typeof(Directory))
                    {
                        throw new Exception("flag -r is needed for a directory");
                    }

                    Files.Remove(words[0]);
                    return ent;
                }

                throw new Exception("could not find the path");
            }

            throw new Exception("entry should not be null");
        }
    }
}