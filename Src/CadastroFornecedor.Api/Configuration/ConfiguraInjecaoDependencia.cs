using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Domain.Service.Interface;
using CadastroFornecedor.Api.Infra.Repository;

namespace CadastroFornecedor.Api.Configuration;

public static class ConfiguraInjecaoDependencia
{
    public static IServiceCollection ConfiguraDependencias(this IServiceCollection service)
    {
        //configuracao injecao dependencia
        service.AddScoped<IFornecedorRepository, FornecedorRepository>();
        service.AddScoped<IFornecedorService, FornecedorService>();

        return service;
    }
}
