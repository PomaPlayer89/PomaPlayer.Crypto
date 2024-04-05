using System.Text.Json.Serialization;

namespace PomaPlayer.Crypto.Web.Middlewares.DtoModels;

public sealed record ErrorResponse
{
    public string ErrorCode { get; init; }

    public string ErrorMessage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object ErrorDetails { get; init; }
}
