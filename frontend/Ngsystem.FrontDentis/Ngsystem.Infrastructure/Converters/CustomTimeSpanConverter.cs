using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ngsystem.Infrastructure.Converters;

public class CustomTimeSpanConverter : JsonConverter<TimeSpan?>
{
    public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        if (string.IsNullOrWhiteSpace(str))
            return null;

        if (TimeSpan.TryParse(str, CultureInfo.InvariantCulture, out var ts))
            return ts;

        if (DateTime.TryParse(str, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            return dt.TimeOfDay;

        return null;
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString(@"hh\:mm", CultureInfo.InvariantCulture));
        else
            writer.WriteNullValue();
    }
}
