using System;
using System.Collections;
using System.Linq;
using ForEach;
using Latex;
using UnityEngine;
using UnityEngine.Networking;

namespace Cube {

    internal class Cube {
        private CubeElement cubePrefab;
        private CubeElement[, , ] elements = new CubeElement[4, 4, 4];
        private string[, , ] latexTensor;
        private Texture2D[, , ] textures = new Texture2D[4, 4, 4];
        private bool[, , ] textureDownloadFlags = new bool[4, 4, 4];
        private readonly float distance = 12;

        public Cube(CubeElement cubePrefab, string[, , ] latexTensor) {
            this.cubePrefab = cubePrefab;
            this.latexTensor = latexTensor;
        }

        public IEnumerator InitializeElements(Func<CubeElement, CubeElement> creator) {
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

        private Action<int, int, int> CreateElement(Func<CubeElement, CubeElement> creator) {
            return (i, j, k) => {
                CubeElement cubeElement = creator(cubePrefab);
                elements[i, j, k] = cubeElement;
                cubeElement.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
                cubeElement.Initialize();
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
            elements[i, j, k].FormulaTexture = texture;
        }

        public void SwitchIndexes() {
            foreach (CubeElement cubeElement in elements) {
                cubeElement.SwitchIndex();
            }
        }
    }
}