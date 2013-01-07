using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class MediaType
    {
        [AutoIncrement]
        public int MediaTypeId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}