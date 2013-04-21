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
    public class AlbumService : Service
    {
        public List<Album> Get(Albums request)
        {
            return Db.Select<Album>();
        }

        public Album Get(Album request)
        {
            return Db.Id<Album>(request.AlbumId);
        }

        public HttpResult Post(Album request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Album>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString())}}
                };
        }

        public HttpResult Put(Album request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.AlbumId.ToString())}}
                };
        }

        public HttpResult Delete(Album request)
        {
            Db.DeleteById<Album>(request.AlbumId);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.AlbumId.ToString())}}
                };
        }
    }
}