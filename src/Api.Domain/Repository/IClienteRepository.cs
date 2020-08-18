using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        Task<ClienteEntity> FindByCpf(string cpf);
    }
}
