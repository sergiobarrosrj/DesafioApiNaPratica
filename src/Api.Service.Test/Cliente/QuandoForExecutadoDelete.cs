using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cliente;
using Moq;
using Xunit;

namespace Api.Service.Test.Cliente
{
    public class QuandoForExecutadoDelete : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.Delete(IdCliente))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdCliente);
            Assert.True(deletado);

            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}
