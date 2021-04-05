using Entrevista.Infra.Mapeamento;
using Entrvista.Dominio;
using System.Data.Entity;

namespace Entrevista.Infra.Contexto
{
    public class EntrevistaContextoDeDados : DbContext
    {
        public EntrevistaContextoDeDados()
            : base("EntrevistaConnection")
        {

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapaDoUsuario());
        }

        
    }
}
