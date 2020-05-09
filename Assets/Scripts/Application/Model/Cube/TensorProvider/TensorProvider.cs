using System.Linq;
using BetterMultidimensionalArray;
using Data;
using Newtonsoft.Json;

public static class TensorProvider {

    static public TensorProperties Properties { get; private set; }
    static public string JsonFile {
        set => SetProperties(value);
    }
    private static void SetProperties(string value) {
        Properties = JsonConvert.DeserializeObject<TensorProperties>(value);
        TensorPropertiesDecorator.DecorateData(Properties);
    }

    public static string[, , ] GetIndexTensor() {
        return new string[4, 4, 4].Select<string,string>(new IndexToLaTeXConverter(Properties));
    }

    public static string[, , ] GetFormulaTensor() {
        return Properties.Data;

    }
}