using Microsoft.Extensions.DependencyInjection;
using PomaPlayer.Crypto.Logic.Interfaces.Repositories;
using PomaPlayer.Crypto.Logic.Interfaces.Services;
using PomaPlayer.Crypto.Logic.Refits;
using PomaPlayer.Crypto.Logic.Repositories;
using PomaPlayer.Crypto.Logic.Services;
using Refit;

namespace PomaPlayer.Crypto.Logic.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddLogicServices(this IServiceCollection services)
    {
        // repositories
        services.AddSingleton<IMemoryRepository, MemoryRepository>();

        // services
        services.AddSingleton<IRSACryptoService, RSACryptoService>();
        services.AddSingleton<IGenerateTestDataService, GenerateTestDataService>();

        services.AddApiRefitServices();
    }

    private static void AddApiRefitServices(this IServiceCollection services)
    {
        services
            .AddRefitClient<IApiSpacexdataShip>(_ => new RefitSettings()
            {
                CollectionFormat = CollectionFormat.Multi
            })
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://api.spacexdata.com");
            });
    }
}
