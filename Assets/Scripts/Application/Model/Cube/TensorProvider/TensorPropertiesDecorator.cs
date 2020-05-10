using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BetterMultidimensionalArray;
using Data;
using UnityEngine;
public static class TensorPropertiesDecorator {
    private const string REGEX_PREFIX = @"(?<!([\\][a-zA-Z]*(?!\\))|(\\color\[[a-zA-z]*))";
    private const string REGEX_SUFFIX = @"(?!_)";
    private static readonly Regex ESCAPED_REGEX = new Regex(@"([\\\(\)\[\]\{\}\.\+\?\*\|])", RegexOptions.Compiled);
    private static TensorProperties properties;
    private static Regex laTeXCharacterRegex;
    private static TensorProperties.LaTeXCharacter currentLaTeXCharacter;

    public static void DecorateData(TensorProperties props) {
        properties = props;
        GetAllLaTeXCharactersToDecorate().ForEach(DecorateLaTeXCharacter);
    }

    private static List<TensorProperties.LaTeXCharacter> GetAllLaTeXCharactersToDecorate() {
        return properties.Parameters.Concat(properties.Coordinates).ToList();
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
        return new Regex(REGEX_PREFIX + BackslashEscapedChars(currentLaTeXCharacter.LaTeX) + REGEX_SUFFIX);
    }

    private static string BackslashEscapedChars(string word) {
        return ESCAPED_REGEX.Replace(word, (match) => @"\" + match.Captures[0].Value);
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