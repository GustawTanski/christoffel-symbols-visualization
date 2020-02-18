using System.Linq;
using BetterMultidimensionalArray;
using Latex;
using Newtonsoft.Json;
using UnityEngine;

public static class TensorProvider {

    public static string[, , ] GetIndexTensor() {
        return new string[4, 4, 4].Select(IndexesToLatex);
    }

    private static string IndexesToLatex(string el, int i, int j, int k) {
        string[] latexArray = new int[] { i, j, k }.Select(GetIndexLatex).ToArray();
        return "(" + string.Join(", ", latexArray) + ")";
    }

    private static string GetIndexLatex(int number) {
        return LatexDictionaries.index[number];
    }

    public static string[, , ] GetFormulaTensor(TextAsset jsonFile) {
        return JsonConvert.DeserializeObject<string[, , ]>(jsonFile.text);
    }
}