using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cliente;
using Moq;
using Xunit;

namespace Api.Service.Test.Cliente
{
    public class QuandoForExecutadoCreate : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.Post(clienteDtoCreate)).ReturnsAsync(clienteDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(clienteDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeCliente, result.Nome);
        }
    }
}
