using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace handlyAdminScreens.Helpers
{
    /// <summary>
    /// Convertidor de fechas tolerante. La API a veces devuelve formatos no-ISO
    /// (ej: "2026-04-01 09:00:00" tal cual viene de Postgres, sin la T separadora).
    /// El parser por defecto de System.Text.Json rechaza esos formatos y rompe la
    /// deserialización entera. Este convertidor prueba varios formatos antes de rendirse.
    /// </summary>
    public class FlexibleDateTimeConverter : JsonConverter<DateTime>
    {
        // formatos típicos que puede mandar la API
        private static readonly string[] Formats = new[]
        {
            "yyyy-MM-ddTHH:mm:ss",         // ISO 8601
            "yyyy-MM-ddTHH:mm:ss.fff",
            "yyyy-MM-ddTHH:mm:ssZ",
            "yyyy-MM-ddTHH:mm:ss.fffZ",
            "yyyy-MM-dd HH:mm:ss",          // Postgres timestamp típico
            "yyyy-MM-dd HH:mm:ss.fff",
            "yyyy-MM-dd",                   // sólo fecha
            "dd/MM/yyyy",                   // formato español
            "dd/MM/yyyy HH:mm:ss",
        };

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // si viene null lo tratamos como DateTime.MinValue (lo gestiona SafeData luego)
            if (reader.TokenType == JsonTokenType.Null)
            {
                return DateTime.MinValue;
            }

            // a veces System.Text.Json ya parsea bien con TryGetDateTime
            if (reader.TokenType == JsonTokenType.String)
            {
                if (reader.TryGetDateTime(out DateTime dt))
                {
                    return dt;
                }

                // si falla, probamos los formatos manualmente
                string s = reader.GetString();
                if (string.IsNullOrWhiteSpace(s)) return DateTime.MinValue;

                foreach (var fmt in Formats)
                {
                    if (DateTime.TryParseExact(s, fmt, CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeLocal, out DateTime parsed))
                    {
                        return parsed;
                    }
                }

                // último intento: parse libre
                if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime any))
                {
                    return any;
                }
            }

            // no rompemos: devolvemos MinValue para que el resto del usuario sí se cargue
            return DateTime.MinValue;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // al serializar, formato ISO 8601 estándar (lo que la API entiende)
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));
        }
    }

    // mismo convertidor pero para DateTime? (nullable)
    public class FlexibleNullableDateTimeConverter : JsonConverter<DateTime?>
    {
        private static readonly FlexibleDateTimeConverter Inner = new FlexibleDateTimeConverter();

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return null;

            var parsed = Inner.Read(ref reader, typeof(DateTime), options);
            // si el parser no pudo sacar nada significativo, lo dejamos como null
            return parsed == DateTime.MinValue ? (DateTime?)null : parsed;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }
            Inner.Write(writer, value.Value, options);
        }
    }
}
