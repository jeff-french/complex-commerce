﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace ComplexCommerce.Web
{
    public class HomeModule : NancyModule 
    {
        public HomeModule()
        {
            Get["/"] = paramaters => View["index.html"];
        }
    }
}