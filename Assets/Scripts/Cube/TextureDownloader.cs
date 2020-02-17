using System.Threading.Tasks;
using BetterMultiDimensional;
using UnityEngine;
using UnityEngine.Networking;

namespace Cube {
    public class LaTeXTextureDownloader {

        private const string baseURL = @"https://latex.codecogs.com/png.latex?";
        private string[, , ] laTeXTensor;

        public static Task<Texture2D[, , ]> Fetch(string[, , ] laTeX) {
            LaTeXTextureDownloader downloader = new LaTeXTextureDownloader(laTeX);
            return downloader.Fetch();
        }

        private LaTeXTextureDownloader(string[, , ] laTeX) {
            this.laTeXTensor = laTeX;
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
            return @"\dpi{999}{\color{white}" + laTeX + "}";
        }

    }
}