using backend_test.FS;
using backend_test.Models;

namespace backend_test.Helpers
{
    public class EntryFactory
    {
        public EntryFactory()
        {
        }

        public Entry Create(CreateEntry e)
        {
            if (e.Content != null)
            {
                return new File(e.Name, e.Content);
            }

            return new Directory(e.Name);
        }
    }
}