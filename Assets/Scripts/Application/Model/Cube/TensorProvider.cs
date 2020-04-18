using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BetterMultidimensionalArray;
using Data;
using Newtonsoft.Json;

public static class TensorProvider {

    private const string REGEX_BASE = @"(?<![\\][a-zA-Z]*(?!\\))";
    private static readonly Regex BACKSLASH_REGEX = new Regex(@"\\", RegexOptions.Compiled);
    private static Regex laTeXCharacterRegex;

    private static TensorProperties.LaTeXCharacter currentLaTeXCharacter;

    static public TensorProperties Properties { get; private set; }
    static public string JsonFile {
        set => SetProperties(value);
    }
    private static void SetProperties(string value) {
        Properties = JsonConvert.DeserializeObject<TensorProperties>(value);
        DecorateData();
    }

    private static void DecorateData() {
        GetAllLaTeXCharactersToDecorate().ForEach(DecorateLaTeXCharacter);
    }

    private static List<TensorProperties.LaTeXCharacter> GetAllLaTeXCharactersToDecorate() {
        return Properties.Coordinates.Concat(Properties.Parameters).ToList();
    }

    private static void DecorateLaTeXCharacter(TensorProperties.LaTeXCharacter character) {
        currentLaTeXCharacter = character;
        SetLaTeXCharacterRegex();
        Properties.Data = Properties.Data.Select(DecorateLaTeXCharacterRegexMatches);
    }

    private static void SetLaTeXCharacterRegex() {
        laTeXCharacterRegex = CreateLaTeXCharacterRegex();
    }

    private static Regex CreateLaTeXCharacterRegex() {
        return new Regex(REGEX_BASE + DoubleBackslashes(currentLaTeXCharacter.LaTeX));
    }

    private static string DoubleBackslashes(string word) {
        return BACKSLASH_REGEX.Replace(word, @"\\");
    }

    private static string DecorateLaTeXCharacterRegexMatches(string laTeX) {
        return laTeXCharacterRegex.Replace(laTeX, DecorateLaTeXCharacterRegexMatch);
    }

    private static string DecorateLaTeXCharacterRegexMatch(Match match) {
        return $"{{\\color[HTML]{{{GetLaTeXCharacterColor()}}} {match.Value} }}";
    }

    private static string GetLaTeXCharacterColor() {
        return currentLaTeXCharacter.Color.Substring(1).ToUpper();
    }

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