using Microsoft.EntityFrameworkCore;
using Tarefas.Entidades;
using Tarefas.Enums;
using Tarefas.Interfaces;

namespace Tarefas.Data.Repositorios
{
    public class TarefaRep : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRep(TarefaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tarefa>> GetByStatus(int status)
        {
            try
            {
                return await _dbSet.Where(t => t.Status == (StatusEnum)status).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar dados. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tarefa>> GetByCategoria(int categoria)
        {
            try
            {
                return await _dbSet.Where(t => t.CategoriaId == categoria).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar dados. {ex.Message}");
            }
        }
    }
}
