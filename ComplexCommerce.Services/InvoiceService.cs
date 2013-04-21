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
    public class InvoiceService : Service
    {
        public List<Invoice> Get(Invoices request)
        {
            return Db.Select<Invoice>();
        }

        public Invoice Get(Invoice request)
        {
            return Db.Id<Invoice>(request.InvoiceId);
        }

        public HttpResult Post(Invoice request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Invoice>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString())}}
                };
        }

        public HttpResult Put(Invoice request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.InvoiceId.ToString())}}
                };
        }

        public HttpResult Delete(Invoice request)
        {
            Db.DeleteById<Invoice>(request.InvoiceId);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.InvoiceId.ToString())}}
                };
        }
    }
}