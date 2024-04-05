using System.Text.Json.Serialization;

namespace PomaPlayer.Crypto.Logic.Refits.DtoModels.ApiSpacexdata.Ship;

public sealed record ShipData
{
    [JsonPropertyName("ship_id")]
    public string ShipId { get; set; }

    [JsonPropertyName("ship_name")]
    public string ShipName { get; set; }

    [JsonPropertyName("ship_model")]
    public string ShipModel { get; set; }

    [JsonPropertyName("ship_type")]
    public string ShipType { get; set; }

    [JsonPropertyName("roles")]
    public string[] roles { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    [JsonPropertyName("abs")]
    public int? Abs { get; set; }

    [JsonPropertyName("class")]
    public int? Class { get; set; }

    [JsonPropertyName("weight_lbs")]
    public int? WeightLbs { get; set; }

    [JsonPropertyName("weight_kg")]
    public int? WeightKg { get; set; }

    [JsonPropertyName("year_built")]
    public int? YearBuilt { get; set; }

    [JsonPropertyName("home_port")]
    public string HomePort { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("speed_kn")]
    public object SpeedKn { get; set; }

    [JsonPropertyName("course_deg")]
    public object CourseDeg { get; set; }

    [JsonPropertyName("position")]
    public Position Position { get; set; }

    [JsonPropertyName("successful_landings")]
    public int? SuccessfulLandings { get; set; }

    [JsonPropertyName("attempted_landings")]
    public int? AttemptedLandings { get; set; }

    [JsonPropertyName("missions")]
    public Mission[] Missions { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("attempted_catches")]
    public int? AttemptedCatches { get; set; }

    [JsonPropertyName("successful_catches")]
    public int? SuccessfulCatches { get; set; }
}
