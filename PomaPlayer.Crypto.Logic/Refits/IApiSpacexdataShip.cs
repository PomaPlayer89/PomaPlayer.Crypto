using PomaPlayer.Crypto.Logic.Refits.DtoModels.ApiSpacexdata.Ship;
using Refit;

namespace PomaPlayer.Crypto.Logic.Refits;

public interface IApiSpacexdataShip
{
    [Get("/v3/ships")]
    Task<ShipData[]> GetAllShips(CancellationToken cancellationToken = default);
}
