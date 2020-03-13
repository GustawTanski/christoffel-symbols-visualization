using System.Linq;
using BetterMultidimensionalArray;
using Data;
using Newtonsoft.Json;
using UnityEngine;

public static class TensorProvider {

    public static string[, , ] GetIndexTensor() {
        return new string[4, 4, 4].Select(IndexesToLatex);
    }

    private static string IndexesToLatex(string el, int i, int j, int k) {
        string[] indexes = new int[] { i, j, k }.Select(GetIndexLatex).ToArray();
        return $"\\Gamma^{indexes[0]}_{{{indexes[1]} {indexes[2]}}}";
    }

    private static string GetIndexLatex(int number) {
        return LatexDictionaries.index[number];
    }

    public static string[, , ] GetFormulaTensor(TextAsset jsonFile) {
        return JsonConvert.DeserializeObject<string[, , ]>(jsonFile.text);
    }
}