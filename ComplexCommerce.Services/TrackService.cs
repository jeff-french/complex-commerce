using System.Collections.Generic;
using System.Net;
using ComplexCommerce.Models;
using ComplexCommerce.Models.Requests;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace ComplexCommerce.Services
{
    public class TrackService : Service
    {
        public List<Track> Get(Tracks request)
        {
            return Db.Select<Track>();
        }

        public Track Get(Track request)
        {
            return Db.Id<Track>(request.TrackId);
        }

        public HttpResult Post(Track request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Track>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString())}}
                };
        }

        public HttpResult Put(Track request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.TrackId.ToString())}}
                };
        }

        public HttpResult Delete(Track request)
        {
            Db.DeleteById<Track>(request.TrackId);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.TrackId.ToString())}}
                };
        }
    }
}