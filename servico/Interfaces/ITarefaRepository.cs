using Tarefas.Entidades;

namespace Tarefas.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<IEnumerable<Tarefa>> GetByStatus(int status);
        Task<IEnumerable<Tarefa>> GetByCategoria(int categoria);
    }
}
