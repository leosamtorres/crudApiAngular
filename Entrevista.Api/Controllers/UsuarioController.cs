using Entrevista.Infra.Transacoes;
using Entrvista.Dominio.Commands.Handlers;
using Entrvista.Dominio.Commands.Inputs;
using Entrvista.Dominio.Repositorio;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Entrevista.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : BaseController
    {
        private IUsuarioRepositorio _repositorio;
        private readonly UsuarioCommandHandler _usuarioCommandHandler;

        public UsuarioController(IUsuarioRepositorio repositorio, UsuarioCommandHandler usuarioCommandHandler, IUow uow)
            :base(uow)
        {
            _repositorio = repositorio;
            _usuarioCommandHandler = usuarioCommandHandler;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repositorio.Buscar());
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<HttpResponseMessage> Post([FromBody] RegistrarUsuarioCommand command)
        {
            var result = _usuarioCommandHandler.Handler(command);

            return await Response(result, _usuarioCommandHandler.Notificacoes);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("")]
        public async Task<HttpResponseMessage> Put([FromBody] AtualizarUsuarioCommand command)
        {
            var result = _usuarioCommandHandler.Handler(command);

            return await Response(result, _usuarioCommandHandler.Notificacoes);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete([FromBody] DeleteUsuarioCommand command)
        {
            var result = _usuarioCommandHandler.Handler(command);

            return await Response(result, _usuarioCommandHandler.Notificacoes);
        }

    }

}
