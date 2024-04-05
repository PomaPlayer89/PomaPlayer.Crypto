using System.Net;

namespace PomaPlayer.Crypto.Logic.Exceptions;

public class CryptoException : Exception
{
    public string ErrorCode { get; set; }

    public object ErrorDetails { get; set; }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.UnprocessableEntity;
}
