namespace Tarefas.Entidades
{
    public class Categoria
    {
        private readonly List<Tarefa> _tarefas = new();

        protected Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome.Trim().ToUpper();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public IReadOnlyCollection<Tarefa> Tarefas => _tarefas;

        public void Editar(string nome)
        {
            Nome = nome.Trim().ToUpper();
        }
    }
}
