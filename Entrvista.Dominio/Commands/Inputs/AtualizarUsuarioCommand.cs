using Entrevista.Compartilhado.Commands;

namespace Entrvista.Dominio.Commands.Inputs
{
    public class AtualizarUsuarioCommand : ICommand
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Sexo { get; set; }
        public string DataNascimento { get; set; }
    }
}
