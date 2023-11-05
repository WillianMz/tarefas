namespace Tarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public bool Concluida { get; set; }
        public int Status { get; set; }
    }
}
