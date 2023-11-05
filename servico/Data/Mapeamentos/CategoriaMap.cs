using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Entidades;

namespace Tarefas.Data.Mapeamentos
{
    public class CategoriaMap : BaseMap<Categoria>
    {
        public CategoriaMap() : base("categorias")
        {
        }

        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(150).IsRequired();
            
            base.Configure(builder);
        }
    }
}
