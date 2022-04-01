using System.Text.Json.Serialization;

namespace Model;
public record User
{
    public Guid id { get; init; }
    public string name { get; init; } = default!;
    public string username { get; init; } = default!;
    [JsonIgnore]
    public string password { get; init; } = default!;
    [JsonIgnore]
    public Boolean isAdmin { get; init; }
};