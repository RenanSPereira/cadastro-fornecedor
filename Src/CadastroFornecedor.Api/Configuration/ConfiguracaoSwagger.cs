using Microsoft.OpenApi.Models;

namespace CadastroFornecedor.Api.Configuration;

public static class ConfiguracaoSwagger
{
    public static IServiceCollection AdicionarConfiguracaoSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API Cadastro de Fornecedores",
                Description = "Web API Para Gerencias Cadastros de Fornecedores",
            });
        });
        return service;
    }
}
