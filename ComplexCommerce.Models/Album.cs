using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ComplexCommerce.Models
{
    public class Album : IReturn<AlbumResponse>
    {
        [AutoIncrement]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        [Required]
        [References(typeof(Artist))]
        public int ArtistId { get; set; }
    }

    public class AlbumResponse : GenericResponseBase<Album>
    {}
}
