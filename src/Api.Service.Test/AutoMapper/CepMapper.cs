using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class EnderecoMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Endereço")]
        public void E_Possivel_Mapear_os_Modelos_Cep()
        {
            var model = new EnderecoModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Bairro = Faker.Address.UsState(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<EnderecoEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new EnderecoEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Cidade = Faker.Address.UsState(),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Estado = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<EnderecoEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Bairro, model.Bairro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var enderecoDto = Mapper.Map<EnderecoDto>(entity);
            Assert.Equal(enderecoDto.Id, entity.Id);
            Assert.Equal(enderecoDto.Logradouro, entity.Logradouro);
            Assert.Equal(enderecoDto.Bairro, entity.Bairro);
            Assert.Equal(enderecoDto.Numero, entity.Numero);
            Assert.Equal(enderecoDto.Cep, entity.Cep);

            var enderecoDtoCompleto = Mapper.Map<EnderecoDto>(listaEntity.FirstOrDefault());
            Assert.Equal(enderecoDto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(enderecoDto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(enderecoDto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(enderecoDto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.NotNull(enderecoDto.Municipio);
            Assert.NotNull(enderecoDto.Municipio.Uf);

            var listaDto = Mapper.Map<List<EnderecoDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Bairro, listaEntity[i].Bairro);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
            }

            var enderecoDtoCreateResult = Mapper.Map<EnderecoDtoCreateResult>(entity);
            Assert.Equal(enderecoDtoCreateResult.Id, entity.Id);
            Assert.Equal(enderecoDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(enderecoDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(enderecoDtoCreateResult.Bairro, entity.Bairro);
            Assert.Equal(enderecoDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(enderecoDtoCreateResult.CreateAt, entity.CreateAt);

            var enderecoDtoUpdateResult = Mapper.Map<EnderecoDtoUpdateResult>(entity);
            Assert.Equal(enderecoDtoUpdateResult.Id, entity.Id);
            Assert.Equal(enderecoDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(enderecoDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(enderecoDtoUpdateResult.Bairro, entity.Bairro);
            Assert.Equal(enderecoDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(enderecoDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto para Model
            enderecoDto.Numero = "";
            var enderecoModel = Mapper.Map<EnderecoModel>(enderecoDto);
            Assert.Equal(enderecoModel.Id, enderecoDto.Id);
            Assert.Equal(enderecoModel.Cep, enderecoDto.Cep);
            Assert.Equal(enderecoModel.Logradouro, enderecoDto.Logradouro);
            Assert.Equal(enderecoModel.Bairro, enderecoDto.Bairro);
            Assert.Equal("S/N", enderecoDto.Numero);

            var enderecoDtoCreate = Mapper.Map<EnderecoDtoCreate>(enderecoModel);
            Assert.Equal(enderecoDtoCreate.Cep, enderecoModel.Cep);
            Assert.Equal(enderecoDtoCreate.Logradouro, enderecoModel.Logradouro);
            Assert.Equal(enderecoDtoCreate.Bairro, enderecoModel.Bairro);
            Assert.Equal(enderecoDtoCreate.Numero, enderecoModel.Numero);

            var enderecoDtoUpdate = Mapper.Map<EnderecoDtoUpdate>(enderecoModel);
            Assert.Equal(enderecoDtoUpdate.Id, enderecoModel.Id);
            Assert.Equal(enderecoDtoUpdate.Cep, enderecoModel.Cep);
            Assert.Equal(enderecoDtoUpdate.Logradouro, enderecoModel.Logradouro);
            Assert.Equal(enderecoDtoUpdate.Bairro, enderecoModel.Bairro);
            Assert.Equal(enderecoDtoUpdate.Numero, enderecoModel.Numero);

        }
    }
}
