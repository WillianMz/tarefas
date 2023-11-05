using Microsoft.EntityFrameworkCore;
using Tarefas.Interfaces;

namespace Tarefas.Data.Repositorios
{
    public class BaseRepository<TEntidade> : IRepository<TEntidade> where TEntidade : class
    {
        protected readonly TarefaContext _context;
        protected readonly DbSet<TEntidade> _dbSet;

        public BaseRepository(TarefaContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntidade>();
        }

        public void Create(TEntidade entidade)
        {
            try
            {
                _dbSet.Add(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public void Update(TEntidade entidade)
        {
            try
            {
                _dbSet.Update(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public void Delete(TEntidade entidade)
        {
            try
            {
                _dbSet.Remove(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<TEntidade> GetById(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntidade>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
