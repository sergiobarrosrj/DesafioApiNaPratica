using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Endereco;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;


namespace Api.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepository _repository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<EnderecoDto>(entity);
        }

        public async Task<EnderecoDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<EnderecoDto>(entity);
        }

        public async Task<EnderecoDtoCreateResult> Post(EnderecoDtoCreate endereco)
        {
            var model = _mapper.Map<EnderecoModel>(endereco);
            var entity = _mapper.Map<EnderecoEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<EnderecoDtoCreateResult>(result);
        }

        public async Task<EnderecoDtoUpdateResult> Put(EnderecoDtoUpdate endereco)
        {
            var model = _mapper.Map<EnderecoModel>(endereco);
            var entity = _mapper.Map<EnderecoEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<EnderecoDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
