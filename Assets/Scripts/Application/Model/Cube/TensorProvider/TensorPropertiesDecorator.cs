using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BetterMultidimensionalArray;
using Data;
public static class TensorPropertiesDecorator {
    private const string REGEX_BASE = @"(?<!([\\][a-zA-Z]*(?!\\))|(\\color\[[a-zA-z]*))";
    private static readonly Regex BACKSLASH_REGEX = new Regex(@"\\", RegexOptions.Compiled);
    private static TensorProperties properties;
    private static Regex laTeXCharacterRegex;
    private static TensorProperties.LaTeXCharacter currentLaTeXCharacter;

    public static void DecorateData(TensorProperties props) {
        properties = props;
        GetAllLaTeXCharactersToDecorate().ForEach(DecorateLaTeXCharacter);
    }

    private static List<TensorProperties.LaTeXCharacter> GetAllLaTeXCharactersToDecorate() {
        return properties.Coordinates.Concat(properties.Parameters).ToList();
    }

    private static void DecorateLaTeXCharacter(TensorProperties.LaTeXCharacter character) {
        currentLaTeXCharacter = character;
        SetLaTeXCharacterRegex();
        properties.Data = properties.Data.Select(DecorateLaTeXCharacterRegexMatches);
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
}