using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class ClienteMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos")]
        public void E_Possivel_Mapear_os_Modelos()
        {
            var model = new ClienteModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Cpf = "52422022030",
                Rg = "1111111",
                DataNascimento = DateTime.UtcNow,
                Idade = 37,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<ClienteEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new ClienteEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Cpf = "52422022030",
                    Rg = "1111111",
                    DataNascimento = DateTime.UtcNow,
                    Idade = 37,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<ClienteEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Cpf, model.Cpf);
            Assert.Equal(entity.Rg, model.Rg);
            Assert.Equal(entity.DataNascimento, model.DataNascimento);
            Assert.Equal(entity.Idade, model.Idade);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var clienteDto = Mapper.Map<ClienteDto>(entity);
            Assert.Equal(clienteDto.Id, entity.Id);
            Assert.Equal(clienteDto.Nome, entity.Nome);
            Assert.Equal(clienteDto.Cpf, entity.Cpf);
            Assert.Equal(clienteDto.Rg, entity.Rg);
            Assert.Equal(clienteDto.DataNascimento, entity.DataNascimento);
            Assert.Equal(clienteDto.Idade, entity.Idade.ToString());
            Assert.Equal(clienteDto.CreateAt, entity.CreateAt);

            var listaDto = Mapper.Map<List<ClienteDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].Cpf, listaEntity[i].Cpf);
                Assert.Equal(listaDto[i].Rg, listaEntity[i].Rg);
                Assert.Equal(listaDto[i].DataNascimento, listaEntity[i].DataNascimento);
                Assert.Equal(listaDto[i].Idade, listaEntity[i].Idade.ToString());
                Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
                Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var clienteDtoCreateResult = Mapper.Map<ClienteDtoCreateResult>(entity);
            Assert.Equal(clienteDtoCreateResult.Id, entity.Id);
            Assert.Equal(clienteDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(clienteDtoCreateResult.Cpf, entity.Cpf);
            Assert.Equal(clienteDtoCreateResult.Rg, entity.Rg);
            Assert.Equal(clienteDtoCreateResult.DataNascimento, entity.DataNascimento);
            Assert.Equal(clienteDtoCreateResult.Idade, entity.Idade);
            Assert.Equal(clienteDtoCreateResult.CreateAt, entity.CreateAt);

            var clienteDtoUpdateResult = Mapper.Map<ClienteDtoUpdateResult>(entity);
            Assert.Equal(clienteDtoUpdateResult.Id, entity.Id);
            Assert.Equal(clienteDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(clienteDtoUpdateResult.Cpf, entity.Cpf);
            Assert.Equal(clienteDtoUpdateResult.Rg, entity.Rg);
            Assert.Equal(clienteDtoUpdateResult.DataNascimento, entity.DataNascimento);
            Assert.Equal(clienteDtoUpdateResult.Idade, entity.Idade);
            Assert.Equal(clienteDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto para Model
            var clienteModel = Mapper.Map<ClienteModel>(clienteDto);
            Assert.Equal(clienteModel.Id, clienteDto.Id);
            Assert.Equal(clienteModel.Nome, clienteDto.Nome);
            Assert.Equal(clienteModel.Cpf, clienteDto.Cpf);
            Assert.Equal(clienteModel.Rg, clienteDto.Rg);
            Assert.Equal(clienteModel.DataNascimento, clienteDto.DataNascimento);
            Assert.Equal(clienteModel.Idade.ToString(), clienteDto.Idade);
            Assert.Equal(clienteModel.CreateAt, clienteDto.CreateAt);

            var clienteDtoCreate = Mapper.Map<ClienteDtoCreate>(clienteModel);
            Assert.Equal(clienteDtoCreate.Nome, clienteModel.Nome);
            Assert.Equal(clienteDtoCreate.Cpf, clienteModel.Cpf);
            Assert.Equal(clienteDtoCreate.Rg, clienteModel.Rg);
            Assert.Equal(clienteDtoCreate.DataNascimento, clienteModel.DataNascimento);
            Assert.Equal(clienteDtoCreate.Idade, clienteModel.Idade);

            var clienteDtoUpdate = Mapper.Map<ClienteDtoUpdate>(clienteModel);
            Assert.Equal(clienteDtoUpdate.Id, clienteModel.Id);
            Assert.Equal(clienteDtoUpdate.Nome, clienteModel.Nome);
            Assert.Equal(clienteDtoUpdate.Cpf, clienteModel.Cpf);
            Assert.Equal(clienteDtoUpdate.Rg, clienteModel.Rg);
            Assert.Equal(clienteDtoUpdate.DataNascimento, clienteModel.DataNascimento);
            Assert.Equal(clienteDtoUpdate.Idade, clienteModel.Idade);

        }
    }
}
