using Entrvista.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Entrevista.Infra.Mapeamento
{
    public class MapaDoUsuario : EntityTypeConfiguration<Usuario>
    {
        public MapaDoUsuario()
        {
            ToTable("Usuario");

            HasKey(x => x.Id);

            Property(x => x.CPF).IsRequired().HasMaxLength(11).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USUARIO_CPF") { IsUnique = true }));
            Property(x => x.Nome).IsRequired().HasMaxLength(120);

            //ToTable("Cliente");

            //HasKey(x => x.Id);

            //Property(x => x.CPF).IsRequired().HasMaxLength(14).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CLIENTE_CNPJ") { IsUnique = true }));
            //Property(x => x.Nome).IsRequired().HasMaxLength(120);
        }
    }
}
