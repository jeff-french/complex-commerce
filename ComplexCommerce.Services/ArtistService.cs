using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplexCommerce.Models;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace ComplexCommerce.Services
{
    public class ArtistService : Service
    {
        public object Get(Artist request)
        {
            var artist = Db.Single<Artist>("ArtistId={0}".Params(request.ArtistId));
            return new ArtistResponse {Result = artist};
        }
    }
}