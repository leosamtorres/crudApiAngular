using Entrevista.Compartilhado.Commands;

namespace Entrvista.Dominio.Commands.Inputs
{
    public class RegistrarUsuarioCommand : ICommand
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Sexo { get; set; }
        public string DataNascimento { get; set; }
    }
}
