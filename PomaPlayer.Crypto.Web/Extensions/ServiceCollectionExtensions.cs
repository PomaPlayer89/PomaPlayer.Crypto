using PomaPlayer.Crypto.Logic.Extensions;

namespace PomaPlayer.Crypto.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddLogicServices();
    }
}
