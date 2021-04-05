using Entrevista.Infra.Contexto;
using System.Web;

namespace Entrevista.Api.Ajudante
{
    public static class AjudanteDataContext
    {
        public static EntrevistaContextoDeDados ContextoDeDadosAtual
        {
            get { return HttpContext.Current.Items["_EntityContext"] as EntrevistaContextoDeDados; }
        }
    }
}