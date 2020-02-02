using System;
using System.Collections;
using System.Linq;
using Latex;
using UnityEngine;
using UnityEngine.Networking;

namespace Cube {

    internal class Cube {
        private LatexSprite prefab;

        private LatexSprite[, , ] elements;

        private string[, , ] latexTensor;
        private Texture2D[, , ] textures = new Texture2D[4, 4, 4];
        private bool[, , ] textureDownloadFlags = new bool[4, 4, 4];

        private float distance = 12;

        public Cube(LatexSprite prefab, string[, , ] latexTensor) {
            this.prefab = prefab;
            this.latexTensor = latexTensor;
            elements = new LatexSprite[4, 4, 4];
        }

        public IEnumerator InitializeElements(Func<LatexSprite, LatexSprite> creator) {
            ForEachElement((i, j, k) => {
                var element = creator(prefab);
                elements[i, j, k] = element;
                element.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
            });
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

        public IEnumerator ChangeElementTextures() {
            ForEachElement(FetchTexture);
            for (;;) {
                if (SetTextures()) yield break;
                else yield return null;
            }
        }

        private void FetchTexture(int i, int j, int k) {
            var www = UnityWebRequestTexture.GetTexture($"https://latex.codecogs.com/png.latex?{@"\dpi{999}{\color{white}" + latexTensor[i, j, k]}}}");
            www.SendWebRequest().completed += (operation) => {
                var texture = DownloadHandlerTexture.GetContent(www);
                textures[i, j, k] = texture;
                textureDownloadFlags[i, j, k] = true;
            };
        }

        private bool SetTextures() {
            if (textureDownloadFlags.Cast<bool>().All(value => value)) {
                ForEachElement((i, j, k) => {
                    var texture = textures[i, j, k];
                    elements[i, j, k].SetTexture(texture);
                });
                return true;
            } else {
                return false;
            }
        }

    }
}