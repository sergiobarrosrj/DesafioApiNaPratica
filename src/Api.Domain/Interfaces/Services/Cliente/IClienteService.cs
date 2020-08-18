using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cliente;

namespace Api.Domain.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        Task<ClienteDto> Get(Guid id);
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDtoCreateResult> Post(ClienteDtoCreate cliente);
        Task<ClienteDtoUpdateResult> Put(ClienteDtoUpdate cliente);
        Task<bool> Delete(Guid id);
    }
}
