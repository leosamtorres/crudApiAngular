using Entrvista.Dominio.Notificacoes;

namespace Entrvista.Dominio
{
    public class Usuario : Notificacao
    {
        protected Usuario() { }
        
        public Usuario(string pCPF, string pNome, string pEmail, string pTelefone, int pSexo, string pDataNascimento)
        {
            CPF = pCPF;
            Nome = pNome;
            Email = pEmail;
            Telefone = pTelefone;
            idSexo = pSexo;
            DataNascimento = pDataNascimento;

            if (pCPF.Length < 11)
                AddNotificacoes("CPF Invalido");

            if (pNome.Length < 3)
                AddNotificacoes("Nome invlaido");
        }

        public int Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public int idSexo { get; private set; }
        public string DataNascimento { get; private set; }

        public void Atualizar(string pNome, string pEmail, string pTelefone, int pSexo, string pDataNascimento)
        {
            Nome = pNome;
            Email = pEmail;
            Telefone = pTelefone;
            idSexo = pSexo;
            DataNascimento = pDataNascimento;

            if (pNome.Length < 3)
                AddNotificacoes("Nome invlaido");
        }
        
    }


}
