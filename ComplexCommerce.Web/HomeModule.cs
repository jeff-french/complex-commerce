using System;
using System.Collections.Generic;
using System.Web;
using Nancy;

namespace ComplexCommerce.Web
{
    public class HomeModule : NancyModule 
    {
        public HomeModule()
        {
            Get["/"] = paramaters =>
                {
                    ViewBag.Version = typeof(ComplexCommerce.Web.HomeModule).Assembly.GetName().Version.ToString();
                    ViewBag.Environment = System.Configuration.ConfigurationManager.AppSettings["Environment"];
                   return View["index"];
                };
            Get["/hello"] = parameters => "Hello Mono!";
        }

        
    }
}