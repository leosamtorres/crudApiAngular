using Entrevista.Infra.Transacoes;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Entrevista.Api.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<HttpResponseMessage> Response(object result, IEnumerable<string> notificacoes)
        {
            var retorno = new HttpResponseMessage();

            if(!notificacoes.Any())
            {
                try
                {
                    _uow.Commit();

                    retorno = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch
                {

                    retorno = Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreu uma falha interna no servidor");
                }
            }
            else
            {
                retorno = Request.CreateResponse(HttpStatusCode.BadRequest, string.Join(",", notificacoes));
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(retorno);
            return await tsc.Task;
        }




    }
}
