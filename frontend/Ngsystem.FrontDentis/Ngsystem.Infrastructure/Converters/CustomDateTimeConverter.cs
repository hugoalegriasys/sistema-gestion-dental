using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ngsystem.Infrastructure.Converters;

public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    private static readonly string[] Formats =
    {
        "MM/dd/yyyy HH:mm:ss",
        "dd/MM/yyyy HH:mm:ss",
        "yyyy-MM-ddTHH:mm:ss",
        "MM/dd/yyyy",
        "dd/MM/yyyy",
        "yyyy-MM-dd"
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        if (string.IsNullOrWhiteSpace(str))
            return null;

        if (DateTime.TryParseExact(str, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            return dt;

        if (DateTime.TryParse(str, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            return dt;

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
        else
            writer.WriteNullValue();
    }
}
