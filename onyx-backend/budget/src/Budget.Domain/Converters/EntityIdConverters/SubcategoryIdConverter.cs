﻿using Budget.Domain.Subcategories;
using Newtonsoft.Json;

namespace Budget.Domain.Converters.EntityIdConverters;

public class SubcategoryIdConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var id = value as SubcategoryId;
        serializer.Serialize(writer, id?.Value.ToString());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var guid = serializer.Deserialize<string>(reader);

        return guid is null ? null : new SubcategoryId(guid);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SubcategoryId);
    }
}