using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Cliente;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ClienteService : IClienteService
    {
        private IRepository<ClienteEntity> _repository;
        private readonly IMapper _mapper;

        public ClienteService(IRepository<ClienteEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ClienteDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ClienteDto>(entity);
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(listEntity);
        }

        public async Task<ClienteDtoCreateResult> Post(ClienteDtoCreate cliente)
        {
            var model = _mapper.Map<ClienteModel>(cliente);
            var entity = _mapper.Map<ClienteEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ClienteDtoCreateResult>(result);
        }

        public async Task<ClienteDtoUpdateResult> Put(ClienteDtoUpdate cliente)
        {
            var model = _mapper.Map<ClienteModel>(cliente);
            var entity = _mapper.Map<ClienteEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ClienteDtoUpdateResult>(result);
        }
    }
}
