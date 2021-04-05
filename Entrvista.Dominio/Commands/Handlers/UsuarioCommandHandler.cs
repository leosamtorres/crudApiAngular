using Entrevista.Compartilhado.Commands;
using Entrvista.Dominio.Commands.Inputs;
using Entrvista.Dominio.Commands.Results;
using Entrvista.Dominio.Notificacoes;
using Entrvista.Dominio.Repositorio;

namespace Entrvista.Dominio.Commands.Handlers
{
    public class UsuarioCommandHandler :
        Notificacao,
        ICommandHandler<RegistrarUsuarioCommand>,
        ICommandHandler<AtualizarUsuarioCommand>,
        ICommandHandler<DeleteUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(RegistrarUsuarioCommand command)
        {
            if (_usuarioRepositorio.CpfExiste(command.CPF))
            {
                AddNotificacoes("CPF já esta em uso");
                return null;
            }

            var usuario = new Usuario(command.CPF, command.Nome, command.Email, command.Telefone, command.Sexo, command.DataNascimento);

            foreach (var item in usuario.Notificacoes)
            {
                AddNotificacoes(item);
            }

            if (!IsValid())
                return null;

            _usuarioRepositorio.Salvar(usuario);

            return new UsuarioCommandResult(usuario.Nome);
        }

        public ICommandResult Handler(AtualizarUsuarioCommand command)
        {
            var usuario = _usuarioRepositorio.Buscar(command.Cpf);

            if (usuario == null)
            {
                AddNotificacoes("Usuário não esta cadastrado");
                return null;
            }

            usuario.Atualizar(command.Nome, command.Email, command.Telefone, command.Sexo, command.DataNascimento);

            foreach (var item in usuario.Notificacoes)
            {
                AddNotificacoes(item);
            }

            if (!IsValid())
                return null;

            _usuarioRepositorio.Atualizar(usuario);

            return new UsuarioCommandResult(usuario.Nome);
        }

        public ICommandResult Handler(DeleteUsuarioCommand command)
        {
            var usuario = _usuarioRepositorio.Buscar(command.cpf);

            if (usuario == null)
                AddNotificacoes("Usuário não esta cadastrado");

            _usuarioRepositorio.Deletar(usuario.Id);

            return new UsuarioCommandResult(usuario.Nome);
        }
    }
}
