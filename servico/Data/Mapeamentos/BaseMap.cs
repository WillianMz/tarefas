using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tarefas.Data.Mapeamentos
{
    public class BaseMap<TEntidade> : IEntityTypeConfiguration<TEntidade> where TEntidade : class
    {
        private readonly string _nomeTabela;

        public BaseMap(string nomeTabela)
        {
            _nomeTabela = nomeTabela;
        }

        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            if(!string.IsNullOrEmpty(_nomeTabela))
            {
                builder.ToTable(_nomeTabela);
            }
        }
    }
}
