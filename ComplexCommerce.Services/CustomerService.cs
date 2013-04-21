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
    public class CustomerService : Service
    {
        public List<Customer> Get(Customers request)
        {
            return Db.Select<Customer>();
        }

        public Customer Get(Customer request)
        {
            return Db.Id<Customer>(request.CustomerId);
        }

        public HttpResult Post(Customer request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Customer>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString())}}
                };
        }

        public HttpResult Put(Customer request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.CustomerId.ToString())}}
                };
        }

        public HttpResult Delete(Customer request)
        {
            Db.DeleteById<Customer>(request.CustomerId);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.CustomerId.ToString())}}
                };
        }
    }
}