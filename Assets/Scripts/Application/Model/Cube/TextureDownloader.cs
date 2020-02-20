using System.Threading.Tasks;
using BetterMultidimensionalArray;
using Data;
using UnityEngine;
using UnityEngine.Networking;

public class LaTeXTextureDownloader {

    private const string baseURL = @"https://latex.codecogs.com/png.latex?";
    private string[, , ] laTeXTensor;
    private TextureSettings settings;

    public static Task<Texture2D[, , ]> Fetch(string[, , ] laTeX, TextureSettings? settings) {
        LaTeXTextureDownloader downloader = new LaTeXTextureDownloader(laTeX, settings);
        return downloader.Fetch();
    }

    public static Task<Texture2D[, , ]> Fetch(string[, , ] laTeX) {
        LaTeXTextureDownloader downloader = new LaTeXTextureDownloader(laTeX, null);
        return downloader.Fetch();
    }

    private LaTeXTextureDownloader(string[, , ] laTeX, TextureSettings? settings) {
        this.laTeXTensor = laTeX;
        this.settings = settings ?? new TextureSettings() { size = Size.normal };
    }

    private Task<Texture2D[, , ]> Fetch() {
        return laTeXTensor.Select(FetchIndexTexture).WaitForAll();
    }

    private async Task<Texture2D> FetchIndexTexture(string laTeX) {
        UnityWebRequest www;
        www = UnityWebRequestTexture.GetTexture(baseURL + DecorateLaTeX(laTeX));
        await www.SendWebRequest();
        return DownloadHandlerTexture.GetContent(www);
    }

    private string DecorateLaTeX(string laTeX) {
        return @"\dpi{999}" + LatexDictionaries.size[settings.size] + @"{\color{white}" + laTeX + "}";
    }

}