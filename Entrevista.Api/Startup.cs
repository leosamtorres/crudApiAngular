using Entrevista.Api.Ajudante;
using Entrevista.Infra.Contexto;
using Entrevista.Infra.Repositorio;
using Entrevista.Infra.Transacoes;
using Entrvista.Dominio.Commands.Handlers;
using Entrvista.Dominio.Repositorio;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Entrevista.Api.Startup))]
namespace Entrevista.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            RegisterRoutes(config);

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(config);

            ConfigureDI(config);

            ConfigurationJsonSerialization(config);
        }

        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void ConfigureDI(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<EntrevistaContextoDeDados, EntrevistaContextoDeDados>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<UsuarioCommandHandler, UsuarioCommandHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<IUow, Uow>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }

        private void ConfigurationJsonSerialization(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }
    }
}