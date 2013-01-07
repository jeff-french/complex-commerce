using System;

namespace ComplexCommerce.Services
{
    public class Global : System.Web.HttpApplication
    {
        

        protected void Application_Start(object sender, EventArgs e)
        {
            new CommerceAppHost().Init();
        }

    }
}