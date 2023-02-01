using LanguageExt;

namespace Orleans.Serialization.Support.LanguageExt;

[RegisterConverter]
public class MapConverter<K, V> : IConverter<Map<K, V>, MapSurrogate<K, V>>
{
    public Map<K, V> ConvertFromSurrogate(in MapSurrogate<K, V> surrogate) => new Map<K, V>(surrogate.Items);

    public MapSurrogate<K, V> ConvertToSurrogate(in Map<K, V> value)
    {
        var items = new List<(K Key, V Value)>(value.Count);
        items.AddRange(value.Pairs);
        return new MapSurrogate<K, V> { Items = items };
    }
}

[GenerateSerializer]
public struct MapSurrogate<K, V>
{
    [Id(0)]
    public List<(K Key, V Value)> Items { get; set; }
}
