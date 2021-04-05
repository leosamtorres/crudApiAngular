using System.Collections.Generic;

namespace Entrvista.Dominio.Notificacoes
{
    public class Notificacao
    {
        public Notificacao()
        {
            Notificacoes = new List<string>();
        }
        public IList<string> Notificacoes { get; set; }

        public void AddNotificacoes(string mensagem)
        {
            Notificacoes.Add(mensagem);
        }

        public bool IsValid()
        {
            if (Notificacoes.Count > 0)
                return false;
            else
                return true;
        }
    }
}
