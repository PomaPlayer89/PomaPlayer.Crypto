using System.Text.Json.Serialization;

namespace PomaPlayer.Crypto.Logic.Refits.DtoModels.ApiSpacexdata.Ship;

public sealed record Mission
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("flight")]
    public int Flight { get; init; }
}
