using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Endereco;
using Moq;
using Xunit;

namespace Api.Service.Test.Endereco
{
    public class QuandoForExecutadoUpdate : EnderecoTestes
    {
        private IEnderecoService _service;
        private Mock<IEnderecoService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Put(enderecoDtoUpdate)).ReturnsAsync(enderecoDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(enderecoDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CepAlterado, resultUpdate.Cep);
            Assert.Equal(LogradouroAlterado, resultUpdate.Logradouro);
            Assert.Equal(NumeroAlterado, resultUpdate.Numero);
        }
    }
}
