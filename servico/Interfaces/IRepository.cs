namespace Tarefas.Interfaces
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : class
    {
        void Create(TEntidade entidade);
        void Update(TEntidade entidade);
        void Delete(TEntidade entidade);
        Task<TEntidade> GetById(int id);
        Task<IEnumerable<TEntidade>> GetAll();
    }
}
