﻿using System.Configuration;
using System.Data;
using ComplexCommerce.Models;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;

namespace ComplexCommerce.Services
{
    public class CommerceAppHost : AppHostBase
    {
        public CommerceAppHost() : base("CommerceService", typeof(CommerceAppHost).Assembly) { }
        
        public override void Configure(Container container)
        {
            //Register dependencies here
            container.Register<IDbConnectionFactory>(
                c =>
                new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["CommerceDB"].ConnectionString));
            container.Register(c => c.Resolve<IDbConnectionFactory>().CreateDbConnection());

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routes
                .Add<Artist>("/artist")
                .Add<Artist>("/artist/{id}");
        }
    }
}