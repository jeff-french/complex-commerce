using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Artist
    {
        [AutoIncrement]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}
