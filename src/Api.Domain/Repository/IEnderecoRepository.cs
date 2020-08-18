using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IEnderecoRepository : IRepository<EnderecoEntity>
    {
        Task<EnderecoEntity> SelectAsync(string cep);
    }
}

