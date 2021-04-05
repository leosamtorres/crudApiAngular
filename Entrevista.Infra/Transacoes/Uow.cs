using Entrevista.Infra.Contexto;

namespace Entrevista.Infra.Transacoes
{
    public class Uow : IUow
    {
        private readonly EntrevistaContextoDeDados _contexto;

        public Uow(EntrevistaContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Rollback()
        {

        }
    }
}
