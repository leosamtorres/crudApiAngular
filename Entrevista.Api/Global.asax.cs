using Entrevista.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Entrevista.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new EntrevistaContextoDeDados();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as EntrevistaContextoDeDados;
            if (entityContext != null)
                entityContext.Dispose();
        }
    }
}
