using Tarefas.Interfaces;

namespace Tarefas.Data.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TarefaContext _context;

        public UnitOfWork(TarefaContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
