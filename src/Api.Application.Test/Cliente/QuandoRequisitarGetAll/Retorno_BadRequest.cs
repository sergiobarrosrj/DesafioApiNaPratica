using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cliente.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private ClientesController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IClienteService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<ClienteDto>
                 {
                    new ClienteDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow
                    },
                    new ClienteDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow
                    }
                 }
            );
            _controller = new ClientesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
