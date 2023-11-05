using Tarefas.Enums;

namespace Tarefas.Entidades
{
    public class Tarefa
    {
        protected Tarefa() { }
        public Tarefa(string titulo, string descricao, Categoria categoria, DateOnly dataInicio)
        {
            Status = StatusEnum.Aberta;
            Titulo = titulo.Trim().ToUpper();
            Descricao = descricao.Trim().ToUpper();
            Categoria = categoria;
            DataInicio = dataInicio;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public DateOnly DataInicio { get; private set; }
        public DateOnly DataFim { get; private set; }
        public bool Concluida { get; private set; }
        public StatusEnum Status { get; private set; }

        public void Editar(string titulo, string descricao, Categoria categoria, DateOnly dataInicio, StatusEnum status)
        {
            Titulo = titulo.Trim().ToUpper();
            Descricao = descricao.Trim().ToUpper();
            Categoria = categoria;
            DataInicio = dataInicio;
            Status = status;
        }

        public void Concluir()
        {
            Concluida = true;
            Status = StatusEnum.Concluida;
            DataFim = new DateOnly();
        }
    }
}
