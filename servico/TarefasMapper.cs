using AutoMapper;
using Tarefas.Entidades;
using Tarefas.Models;

namespace Tarefas
{
    public class TarefasMapper : Profile
    {
        public TarefasMapper()
        {
            CreateMap<Tarefa, TarefaModel>().ReverseMap();
        }
    }
}
