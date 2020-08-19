using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Moq;
using Xunit;

namespace Api.Service.Test.Cliente
{
    public class QuandoForExecutadoGet : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.Get(IdCliente)).ReturnsAsync(clienteDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdCliente);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCliente);
            Assert.Equal(NomeCliente, result.Nome);

            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ClienteDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdCliente);
            Assert.Null(_record);

        }
    }
}
