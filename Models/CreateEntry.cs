using System.ComponentModel.DataAnnotations;

namespace backend_test.Models
{
    public class CreateEntry
    {
        [Required]
        public string Name;
        public string Content;
    }
}