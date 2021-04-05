using Entrevista.Compartilhado.Commands;

namespace Entrvista.Dominio.Commands.Results
{
    public class UsuarioCommandResult : ICommandResult
    {
        public UsuarioCommandResult(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
