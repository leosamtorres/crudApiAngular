namespace Entrevista.Infra.Transacoes
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
