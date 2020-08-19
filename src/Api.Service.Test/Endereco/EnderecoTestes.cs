using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Endereco
{
    public class EnderecoTestes
    {
        public static string CepOriginal { get; set; }
        public static string LogradouroOriginal { get; set; }
        public static string NumeroOriginal { get; set; }
        public static string CepAlterado { get; set; }
        public static string LogradouroAlterado { get; set; }
        public static string NumeroAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdEndereco { get; set; }

        public List<EnderecoDto> listaDto = new List<EnderecoDto>();
        public EnderecoDto enderecoDto;
        public EnderecoDtoCreate enderecoDtoCreate;
        public EnderecoDtoCreateResult enderecoDtoCreateResult;
        public EnderecoDtoUpdate enderecoDtoUpdate;
        public EnderecoDtoUpdateResult enderecoDtoUpdateResult;

        public EnderecoTestes()
        {
            IdMunicipio = Guid.NewGuid();
            IdEndereco = Guid.NewGuid();
            CepOriginal = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumeroOriginal = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroOriginal = Faker.Address.StreetName();
            CepAlterado = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroAlterado = Faker.Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new EnderecoDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 1000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Cidade = Faker.Address.City(),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Estado = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaDto.Add(dto);
            }

            enderecoDto = new EnderecoDto
            {
                Id = IdEndereco,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = IdMunicipio,
                    Cidade = Faker.Address.City(),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Estado = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            };

            enderecoDtoCreate = new EnderecoDtoCreate
            {
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
            };

            enderecoDtoCreateResult = new EnderecoDtoCreateResult
            {
                Id = IdEndereco,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };

            enderecoDtoUpdate = new EnderecoDtoUpdate
            {
                Id = IdEndereco,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio
            };

            enderecoDtoUpdateResult = new EnderecoDtoUpdateResult
            {
                Id = IdMunicipio,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
