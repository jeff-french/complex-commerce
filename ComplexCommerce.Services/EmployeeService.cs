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
    public class EmployeeService : Service
    {
        public List<Employee> Get(Employees request)
        {
            return Db.Select<Employee>();
        }

        public Employee Get(Employee request)
        {
            return Db.Id<Employee>(request.EmployeeId);
        }

        public HttpResult Post(Employee request)
        {
            Db.Insert(request);
            var id = Db.GetLastInsertId();
            var item = Db.Id<Employee>(id);
            return new HttpResult(item, HttpStatusCode.Created)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(id.ToString())}}
                };
        }

        public HttpResult Put(Employee request)
        {
            Db.Update(request);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.EmployeeId.ToString())}}
                };
        }

        public HttpResult Delete(Employee request)
        {
            Db.DeleteById<Employee>(request.EmployeeId);
            return new HttpResult(HttpStatusCode.NoContent)
                {
                    Headers = {{HttpHeaders.Location, Request.AbsoluteUri.CombineWith(request.EmployeeId.ToString())}}
                };
        }
    }
}