using Tarefas.Entidades;
using Tarefas.Interfaces;

namespace Tarefas.Data.Repositorios
{
    public class CategoriaRep : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRep(TarefaContext context) : base(context)
        {
        }
    }
}
