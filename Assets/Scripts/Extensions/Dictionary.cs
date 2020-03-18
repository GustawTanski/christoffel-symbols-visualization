using System.Collections.Generic;
using System.Linq;
static class DictionaryExtension {
    public static TKey KeyByValue<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TValue val) {
        return dictionary.First(el => el.Value.Equals(val)).Key;
    }
}