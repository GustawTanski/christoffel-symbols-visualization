using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BetterMultidimensionalArray;
using UnityEngine;
using UnityEngine.Networking;

public class LaTeXTextureDownloader {

    private const string url = @"http://sciencesoft.at/latex";
    private string[, , ] laTeXTensor;
    private TextureSettings settings;
    private static Dictionary<string, Task<Texture2D>> fetchedTextures = new Dictionary<string, Task<Texture2D>>();

    public static Task<Texture2D[, , ]> Fetch(string[, , ] laTeX, TextureSettings? settings) {
        LaTeXTextureDownloader downloader = new LaTeXTextureDownloader(laTeX, settings);
        return downloader.GetTextures();
    }

    public static Task<Texture2D[, , ]> Fetch(string[, , ] laTeX) {
        LaTeXTextureDownloader downloader = new LaTeXTextureDownloader(laTeX, null);
        return downloader.GetTextures();
    }

    private LaTeXTextureDownloader(string[, , ] laTeX, TextureSettings? settings) {
        this.laTeXTensor = laTeX;
        this.settings = settings ?? new TextureSettings() { size = Size.normal };
    }

    private Task<Texture2D[, , ]> GetTextures() {
        return laTeXTensor.Select(GetTexture).WaitForAll();
    }

    private Task<Texture2D> GetTexture(string latex) {
        string decoratedLaTeX = DecorateLaTeX(latex);
        if (!fetchedTextures.ContainsKey(decoratedLaTeX)) {
            fetchedTextures[decoratedLaTeX] = FetchTexture(decoratedLaTeX);
        }
        return fetchedTextures[decoratedLaTeX];
    }

    private string DecorateLaTeX(string laTeX) {
        return @"\huge\({\color{white}" + laTeX + @"}\)";
    }

    private async Task<Texture2D> FetchTexture(string laTeX) {
        try {
            UnityWebRequest www = GeneratePutRequest(laTeX);
            await www.SendWebRequest();
            www = UnityWebRequestTexture.GetTexture(GetUrlFromResponse(www));
            await www.SendWebRequest();
            return DownloadHandlerTexture.GetContent(www);
        } catch (InvalidOperationException e) {
            // Debug.LogError(e);
            // Debug.Log(e.Message);
            throw;
        }
    }

    private UnityWebRequest GeneratePutRequest(string laTeX) {
        UnityWebRequest request = UnityWebRequest.Put(url, GenerateLaTeXRequestBody(laTeX));
        request.SetRequestHeader("Content-Type", @"application/xml");
        return request;
    }

    private byte[] GenerateLaTeXRequestBody(string laTeX) {
        Debug.Log(GenerateXmlString(laTeX));
        return Encoding.Default.GetBytes(GenerateXmlString(laTeX));
    }

    private string GenerateXmlString(string laTeX) {
        return @"<?xml version=""1.0"" encoding=""UTF-8""?>  
        <latex ochem=""false"" bgcolor=""#000"">
            <dev dpi=""600"">pngalpha</dev>
            <src><![CDATA[\documentclass[20pt]{article}
                \usepackage{amssymb,amsmath,xcolor}
                \pagestyle{empty}
                \begin{document}
                " + laTeX + @"
                \end{document}]]>
            </src>
            <embeddedData>false</embeddedData>
        </latex>";
    }

    private string GetUrlFromResponse(UnityWebRequest www) {
        string xmlString = Encoding.UTF8.GetString(www.downloadHandler.data);
        XDocument doc = XDocument.Parse(xmlString);
        XElement urlElement = doc.Descendants("url").First();
        return urlElement.Value;
    }

    static public Task<Texture2D> FetchOneTexture(string laTeX) {
        return new LaTeXTextureDownloader().GetTexture(laTeX);
    }

    private LaTeXTextureDownloader() {}

}