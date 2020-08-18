using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class EnderecoImplementation : BaseRepository<EnderecoEntity>, IEnderecoRepository
    {
        private DbSet<EnderecoEntity> _dataset;

        public EnderecoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<EnderecoEntity>();
        }

        public async Task<EnderecoEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio)
                                 .ThenInclude(m => m.Uf)
                                 .SingleOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
