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
    [Route("/artists")]
    [Route("/artists/{ArtistId}")]
    public class Artist : IReturn<ArtistResponse>
    {
        [AutoIncrement]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }

    public class ArtistResponse : GenericResponseBase<Artist>
    {}
}
