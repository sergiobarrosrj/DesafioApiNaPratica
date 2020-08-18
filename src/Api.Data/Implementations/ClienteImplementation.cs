using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ClienteImplementation : BaseRepository<ClienteEntity>, IClienteRepository
    {
        private DbSet<ClienteEntity> _dataset;
        public ClienteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ClienteEntity>();
        }
        public async Task<ClienteEntity> FindByCpf(string cpf)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Cpf.Equals(cpf));
        }
    }
}
