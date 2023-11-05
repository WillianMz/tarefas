using Microsoft.EntityFrameworkCore;
using Tarefas.Entidades;

namespace Tarefas.Data
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarefaContext).Assembly, a => a.Namespace == "Tarefas.Data.Mapeamentos");
            base.OnModelCreating(modelBuilder);
        }
    }
}
