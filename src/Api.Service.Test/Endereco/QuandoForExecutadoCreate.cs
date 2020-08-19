using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Endereco;
using Moq;
using Xunit;

namespace Api.Service.Test.Endereco
{
    public class QuandoForExecutadoCreate : EnderecoTestes
    {
        private IEnderecoService _service;
        private Mock<IEnderecoService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Post(enderecoDtoCreate)).ReturnsAsync(enderecoDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(enderecoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);
            Assert.Equal(NumeroOriginal, result.Numero);

        }
    }
}
