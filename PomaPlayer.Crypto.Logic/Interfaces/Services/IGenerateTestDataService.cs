namespace PomaPlayer.Crypto.Logic.Interfaces.Services;

public interface IGenerateTestDataService
{
    Task<string> GetRandomShipAsync(CancellationToken cancellationToken);
}
