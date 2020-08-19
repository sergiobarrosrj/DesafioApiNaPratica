using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Cliente;

namespace Api.Service.Test.Cliente
{
    public class ClienteTestes
    {
        public static string NomeCliente { get; set; }
        public static string NomeClienteAlterado { get; set; }
        public static Guid IdCliente { get; set; }

        public List<ClienteDto> listaClienteDto = new List<ClienteDto>();
        public ClienteDto clienteDto;
        public ClienteDtoCreate clienteDtoCreate;
        public ClienteDtoCreateResult clienteDtoCreateResult;
        public ClienteDtoUpdate clienteDtoUpdate;
        public ClienteDtoUpdateResult clienteDtoUpdateResult;

        public ClienteTestes()
        {
            IdCliente = Guid.NewGuid();
            NomeCliente = Faker.Name.FullName();
            NomeClienteAlterado = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new ClienteDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName()
                };
                listaClienteDto.Add(dto);
            }

            clienteDto = new ClienteDto
            {
                Id = IdCliente,
                Nome = NomeCliente
            };

            clienteDtoCreate = new ClienteDtoCreate
            {
                Nome = NomeCliente
            };


            clienteDtoCreateResult = new ClienteDtoCreateResult
            {
                Id = IdCliente,
                Nome = NomeCliente,
                CreateAt = DateTime.UtcNow
            };

            clienteDtoUpdate = new ClienteDtoUpdate
            {
                Id = IdCliente,
                Nome = NomeClienteAlterado
            };

            clienteDtoUpdateResult = new ClienteDtoUpdateResult
            {
                Id = IdCliente,
                Nome = NomeClienteAlterado,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
