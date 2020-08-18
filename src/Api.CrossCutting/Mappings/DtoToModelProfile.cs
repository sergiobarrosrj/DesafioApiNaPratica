using Api.Domain.Dtos.Endereco;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Cliente
            CreateMap<ClienteModel, ClienteDto>()
                .ReverseMap();
            CreateMap<ClienteModel, ClienteDtoCreate>()
                .ReverseMap();
            CreateMap<ClienteModel, ClienteDtoUpdate>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfDto>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>()
                .ReverseMap();
            #endregion

            #region Endereco
            CreateMap<EnderecoModel, EnderecoDto>()
                .ReverseMap();
            CreateMap<EnderecoModel, EnderecoDtoCreate>()
                .ReverseMap();
            CreateMap<EnderecoModel, EnderecoDtoUpdate>()
                .ReverseMap();
            #endregion

        }
    }
}
