using System.Collections.Generic;
using System.Linq;
using System.Net;
using ComplexCommerce.Models;
using ComplexCommerce.Models.Requests;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace ComplexCommerce.Services
{
    public class ArtistService : Service
    {
        
        public List<Artist> Get(Artists request)
        {
            return Db.Select<Artist>().ToList();
        }

        public Artist Get(Artist request)
        {
            return Db.Id<Artist>(request.ArtistId);
        }

        public HttpResult Post(Artist request)
        {
            Db.Insert(request);
            var artistId = Db.GetLastInsertId();
            var artist = Db.Id<Artist>(artistId);
            return new HttpResult(artist, HttpStatusCode.Created)
                {
                    Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(artistId.ToString()) } }
                };
        }

        public HttpResult Put(Artist request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
            {
                Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.ArtistId.ToString()) } }
            };
        }

        public HttpResult Delete(Artist request)
        {
            Db.DeleteById<Artist>(request.ArtistId);
            return new HttpResult(HttpStatusCode.NoContent)
            {
                Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.ArtistId.ToString()) } }
            };
        }
    }
}