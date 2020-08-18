using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Endereco;

namespace Api.Domain.Interfaces.Services.Endereco
{
    public interface IEnderecoService
    {
        Task<EnderecoDto> Get(Guid id);
        Task<EnderecoDto> Get(string cep);
        Task<EnderecoDtoCreateResult> Post(EnderecoDtoCreate cep);
        Task<EnderecoDtoUpdateResult> Put(EnderecoDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}
