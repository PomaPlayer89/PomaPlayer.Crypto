using Microsoft.Extensions.Logging;
using PomaPlayer.Crypto.Logic.Interfaces.Services;
using PomaPlayer.Crypto.Logic.Refits;

namespace PomaPlayer.Crypto.Logic.Services;

public sealed class GenerateTestDataService : IGenerateTestDataService
{
    private readonly IApiSpacexdataShip _apiSpacexdataShip;
    private readonly ILogger<GenerateTestDataService> _logger;

    public GenerateTestDataService(
        IApiSpacexdataShip apiSpacexdataShip,
        ILogger<GenerateTestDataService> logger)
    {
        _apiSpacexdataShip = apiSpacexdataShip;
        _logger = logger;
    }

    public async Task<string> GetRandomShipAsync(CancellationToken cancellationToken)
    {
        try
        {
            var ships = await _apiSpacexdataShip.GetAllShips(cancellationToken);
            if (ships?.Any() == true)
            {
                var rand = new Random();
                var randumNumber = rand.Next(0, ships.Length - 1);

                return ships[randumNumber].ShipName;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при выполнении запроса");
        }

        return "default";
    }
}
