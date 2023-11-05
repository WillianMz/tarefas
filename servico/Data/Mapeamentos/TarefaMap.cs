using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Entidades;

namespace Tarefas.Data.Mapeamentos
{
    public class TarefaMap : BaseMap<Tarefa>
    {
        public TarefaMap() : base("tarefas") { }

        public override void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.Titulo).HasColumnName("nome").HasMaxLength(40).IsRequired();
            builder.Property(t => t.Descricao).HasColumnName("descricao").HasMaxLength(250).IsRequired();
            builder.Property(t => t.CategoriaId).HasColumnName("id_categoria").IsRequired();
            builder.Property(t => t.DataInicio).HasColumnName("dt_inicio");
            builder.Property(t => t.DataFim).HasColumnName("dt_fim");
            builder.Property(t => t.Concluida).HasColumnName("concluida");
            builder.Property(t => t.Status).HasColumnName("status");

            //relacionamento
            builder.HasOne(t => t.Categoria)
                .WithMany(c => c.Tarefas)
                .HasForeignKey(t => t.CategoriaId)
                .HasConstraintName("fk_categoria_id");
            
            base.Configure(builder);
        }
    }
}
