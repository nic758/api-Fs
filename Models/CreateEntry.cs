using System.ComponentModel.DataAnnotations;

namespace backend_test.Models
{
    public class CreateEntry
    {
        [Required]
        public string Name { get; set; }

        public string Content { get; set; }
    }
}