using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Endereco;
using Moq;
using Xunit;

namespace Api.Service.Test.Endereco
{
    public class QuandoForExecutadoDelete : EnderecoTestes
    {
        private IEnderecoService _service;
        private Mock<IEnderecoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Delete(IdEndereco))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdEndereco);
            Assert.True(deletado);

            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
