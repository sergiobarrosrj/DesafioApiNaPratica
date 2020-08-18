using Api.Domain.Interfaces.Services.Endereco;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Interfaces.Services.Cliente;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<IEnderecoService, EnderecoService>();
        }
    }
}
