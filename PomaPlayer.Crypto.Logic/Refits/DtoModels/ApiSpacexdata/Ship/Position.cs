using System.Text.Json.Serialization;

namespace PomaPlayer.Crypto.Logic.Refits.DtoModels.ApiSpacexdata.Ship;

public sealed record Position
{
    [JsonPropertyName("latitude")]
    public string Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; init; }
}
