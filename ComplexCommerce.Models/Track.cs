using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Track
    {
        [AutoIncrement]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [References(typeof(Album))]
        public int AlbumId { get; set; }

        [Required]
        [References(typeof(MediaType))]
        public int MediaTypeId { get; set; }

        [References(typeof(Genre))]
        public int GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        [Required]
        [Alias("Milliseconds")]
        public int Length { get; set; }

        [Alias("Bytes")]
        public int Size { get; set; }

        [Required]
        [DecimalLength(10,2)]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

    }
}
