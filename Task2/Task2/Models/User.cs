using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}