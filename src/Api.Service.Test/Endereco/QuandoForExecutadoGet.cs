using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Interfaces.Services.Endereco;
using Moq;
using Xunit;

namespace Api.Service.Test.Endereco
{
    public class QuandoForExecutadoGet : EnderecoTestes
    {
        private IEnderecoService _service;
        private Mock<IEnderecoService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Get(IdEndereco)).ReturnsAsync(enderecoDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdEndereco);
            Assert.NotNull(result);
            Assert.True(result.Id == IdEndereco);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);

            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Get(CepOriginal)).ReturnsAsync(enderecoDto);
            _service = _serviceMock.Object;

            result = await _service.Get(CepOriginal);
            Assert.NotNull(result);
            Assert.True(result.Id == IdEndereco);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);

            _serviceMock = new Mock<IEnderecoService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((EnderecoDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
