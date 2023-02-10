using System.Collections.Generic;

namespace AssemblerToMachineLanguage.Extensions;

public static class DictionaryExtension
{
    public static TValue GetValueOrDefault<TKey, TValue> 
        (this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        return dictionary.TryGetValue(key, out var value) 
            ? value
            : defaultValue;
    }
}