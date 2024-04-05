using System.Security.Cryptography;

namespace PomaPlayer.Crypto.Logic.Interfaces.Services;

public interface IRSACryptoService
{
    RSAParameters GetPublicKey(string key);

    string ToEncodedString(RSAParameters source);

    Task<string> SignContentAsync(string content, RSAParameters key, CancellationToken cancellationToken);
}
