using System;
using System.Collections;
using System.Linq;
using ForEach;
using Latex;
using UnityEngine;
using UnityEngine.Networking;

namespace Cube {

    internal class Cube {
        private LatexSprite prefab;
        private LatexSprite[, , ] elements = new LatexSprite[4, 4, 4];
        private string[, , ] latexTensor;
        private Texture2D[, , ] textures = new Texture2D[4, 4, 4];
        private bool[, , ] textureDownloadFlags = new bool[4, 4, 4];
        private readonly float distance = 12;

        public Cube(LatexSprite prefab, string[, , ] latexTensor) {
            this.prefab = prefab;
            this.latexTensor = latexTensor;
        }

        public IEnumerator InitializeElements(Func<LatexSprite, LatexSprite> creator) {
            ForEachElement(CreateElement(creator));
            yield return ChangeElementTextures();
        }

        private void ForEachElement(Action<int, int, int> action) {
            for (int i = 0; i < latexTensor.GetLength(0); i++) {
                for (int j = 0; j < latexTensor.GetLength(1); j++) {
                    for (int k = 0; k < latexTensor.GetLength(2); k++) {
                        action(i, j, k);
                    }
                }
            }
        }

        private Action<int, int, int> CreateElement(Func<LatexSprite, LatexSprite> creator) {
            return (i, j, k) => {
                LatexSprite element = creator(prefab);
                elements[i, j, k] = element;
                element.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
            };
        }

        public IEnumerator ChangeElementTextures() {
            ForEachElement(FetchTexture);
            for (;;) {
                if (AreTexturesFetched()) {
                    SetTextures();
                    yield break;
                } else yield return null;
            }
        }

        private void FetchTexture(int i, int j, int k) {
            UnityWebRequest www;
            www = UnityWebRequestTexture.GetTexture(CreateDownloadLink(i, j, k));
            www.SendWebRequest().completed += (operation) => {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                textures[i, j, k] = texture;
                textureDownloadFlags[i, j, k] = true;
            };
        }

        private string CreateDownloadLink(int i, int j, int k) {
            return $"https://latex.codecogs.com/png.latex?{@"\dpi{999}{\color{white}" + latexTensor[i, j, k]}}}";
        }

        private bool AreTexturesFetched() {
            return textureDownloadFlags.Cast<bool>().All(value => value);
        }

        private void SetTextures() {
            ForEachElement(SetTexture);
        }

        private void SetTexture(int i, int j, int k) {
            Texture2D texture = textures[i, j, k];
            elements[i, j, k].SetTexture(texture);
        }
    }
}