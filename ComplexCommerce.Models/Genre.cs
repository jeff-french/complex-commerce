using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Genre
    {
        [AutoIncrement]
        public int GenreId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}