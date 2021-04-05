using Entrevista.Compartilhado.Commands;

namespace Entrvista.Dominio.Commands.Inputs
{
    public class DeleteUsuarioCommand : ICommand
    {
        public string cpf { get; set; }
    }
}
