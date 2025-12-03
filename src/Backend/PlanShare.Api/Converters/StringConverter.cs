using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PlanShare.Api.Converters;

public sealed partial class StringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value is null 
            ? null 
            : NormalizeSpaces().Replace(value, " ").Trim();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        => writer.WriteStringValue(value);

    [GeneratedRegex(@"\s+")]
    private static partial Regex NormalizeSpaces();
}