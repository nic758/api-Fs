using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using backend_test.Models;

namespace backend_test.FS
{
    public class FileSystem
    {
        public List<string> files;
        public FileSystem()
        {
            files = new List<string>();
        }
        //TODO:
        public List<string> ListFsEntry(string path)
        {

            return files;
        }

        public string CreateFsEntry(string path, CreateEntry entry)
        {
            files.Add(path);
            return path;
        }

        public string GetEntryContent(string path)
        {
            return path;
        }

        public string ModifyEntry(string path)
        {
            return path;
        }
    }
}