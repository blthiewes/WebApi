using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using RestfulApi.Domain.Eventing;
using RestfulApi.Infrastructure;

[assembly: OwinStartup(typeof(RestfulApi.Startup))]

namespace RestfulApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(new CorsOptions { PolicyProvider = new APICorsPolicyProvider() });

            //AreaRegistration.RegisterAllAreas();

            //GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new WindsorContainer(new XmlInterpreter());
            container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestyleScoped());
            GlobalConfiguration.Configuration.DependencyResolver = new CastleWindsorDependencyResolver(container);
            DomainEventDispatcher.SetResolver((t) => container.ResolveAll(t));

            Application.Mappers.Config.AutoMapperConfiguration.Configure();
            Infrastructure.Mappers.Config.AutoMapperConfiguration.Configure();

            ConfigureAuth(app);
        }
    }
}
