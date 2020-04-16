using System;
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

public static class TensorProviderNew {
    static public string JsonFile {
        set {
            Properties = JsonConvert.DeserializeObject<TensorProperties>(value);
        }
    }
    static public TensorProperties Properties { get; private set; }

    public static string[, , ] GetIndexTensor() {
        return new string[4, 4, 4].Select(IndexesToLatex);
    }

    private static string IndexesToLatex(string el, int i, int j, int k) {
        var indexes = Properties
            .Indexes
            .Select((index, l) => (index, l))
            .Zip(
                new [] { i, j, k },
                (indexr, number) => (index: indexr.index, l: indexr.l, number)
            )
            .GroupBy(dog => dog.index.Position)
            .Select(group => {
                string[] dog = new string[3].Select(_ => @"\cdot").ToArray();
                foreach (var item in group) {
                    dog[item.l] = Properties.Coordinates[item.number].LaTeX;
                }
                return TensorProperties.positionToLaTeX[group.Key] + "{" + String.Join(" ", dog) + "}";
            });
        return Properties.Symbol + String.Join("", indexes);
    }

    public static string[, , ] GetFormulaTensor() {
        return Properties.Data;

    }
}