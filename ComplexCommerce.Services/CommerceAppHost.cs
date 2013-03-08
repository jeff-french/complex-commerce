using System.Configuration;
using ComplexCommerce.Models;
using ComplexCommerce.Models.Requests;
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
                new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["CommerceDB"].ConnectionString, SqlServerDialect.Provider));
            container.Register(c => c.Resolve<IDbConnectionFactory>().CreateDbConnection());

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routes
                .Add<Artist>("/artists", "POST")
                .Add<Artist>("/artists/{ArtistId}")
                .Add<Artists>("/artists", "GET,OPTIONS");
        }
    }
}