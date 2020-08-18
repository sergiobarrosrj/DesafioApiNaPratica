using Api.Domain.Dtos.Endereco;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ClienteDto, ClienteEntity>()
                .ReverseMap();

            CreateMap<ClienteDtoCreateResult, ClienteEntity>()
               .ReverseMap();

            CreateMap<ClienteDtoUpdateResult, ClienteEntity>()
               .ReverseMap();

            CreateMap<UfDto, UfEntity>()
               .ReverseMap();

            CreateMap<MunicipioDto, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
               .ReverseMap();

            CreateMap<EnderecoDto, EnderecoEntity>()
               .ReverseMap();

            CreateMap<EnderecoDtoCreateResult, EnderecoEntity>()
               .ReverseMap();

            CreateMap<EnderecoDtoUpdateResult, EnderecoEntity>()
               .ReverseMap();
        }
    }
}
