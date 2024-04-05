using PomaPlayer.Crypto.Logic.Exceptions;
using PomaPlayer.Crypto.Logic.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace PomaPlayer.Crypto.Logic.Services;

public sealed class RSACryptoService : IRSACryptoService
{
    public RSAParameters GetPublicKey(string key)
    {
        var sourceArray = Convert.FromBase64String(key);
        var result = new RSAParameters();

        result.Exponent = new byte[sourceArray[0] + 1];
        int i = 1;

        for (; i < sourceArray[0] + 2; i++)
            result.Exponent[i - 1] = sourceArray[i];

        result.Modulus = new byte[sourceArray[i] + 1];
        i++;

        for (; i < sourceArray.Length; i++)
            result.Modulus[i - result.Exponent.Length - 2] = sourceArray[i];

        return result;
    }

    public string ToEncodedString(RSAParameters source)
    {
        var exp = source.Exponent;
        var modules = source.Modulus;

        var superArr = new byte[exp.Length + modules.Length + 2];
        superArr[0] = (byte)(exp.Length - 1);

        var i = 1;

        for (; i < exp.Length + 1; i++)
            superArr[i] = exp[i - 1];

        superArr[i] = (byte)(modules.Length - 1);
        i++;

        for (var j = 0; j < modules.Length; j++)
            superArr[i + j] = modules[j];

        return Convert.ToBase64String(superArr);
    }

    public async Task<string> SignContentAsync(string content, RSAParameters key, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            byte[] signedBytes;
            var byteContent = new UTF8Encoding().GetBytes(content);

            using (var provider = new RSACryptoServiceProvider())
            {
                try
                {
                    provider.ImportParameters(key);
                    signedBytes = provider.SignData(byteContent, CryptoConfig.MapNameToOID("SHA256"));
                }
                catch (Exception ex)
                {
                    throw new CryptoException()
                    {
                        ErrorCode = ex.Message
                    };
                }
            }

            return Convert.ToBase64String(signedBytes);
        }, cancellationToken);
    }
}
