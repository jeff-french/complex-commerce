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
    public class GenreService : Service
    {
        public List<Genre> Get(Genres request)
        {
            return Db.Select<Genre>();
        }

        public Genre Get(Genre request)
        {
            return Db.Id<Genre>(request.GenreId);
        }

        public HttpResult Post(Genre request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Genre>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString()) } }
                };
        }

        public HttpResult Put(Genre request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
            {
                Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.GenreId.ToString()) } }
            };
        }

        public HttpResult Delete(Genre request)
        {
            Db.DeleteById<Genre>(request.GenreId);
            return new HttpResult(HttpStatusCode.NoContent)
            {
                Headers = { { HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.GenreId.ToString()) } }
            };
        }
    }
}