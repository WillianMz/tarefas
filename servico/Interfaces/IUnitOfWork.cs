namespace Tarefas.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        Task Rollback();
    }
}
