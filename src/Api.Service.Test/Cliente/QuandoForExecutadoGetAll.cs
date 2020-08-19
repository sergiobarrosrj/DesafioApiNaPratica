using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Moq;
using Xunit;

namespace Api.Service.Test.Cliente
{
    public class QuandoForExecutadoGetAll : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaClienteDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<ClienteDto>();
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
