using System;
using System.Linq;
using System.Threading.Tasks;
using BetterMultiDimensional;
using Latex;
using UnityEngine;

namespace Cube {

    internal class Cube {
        private CubeElement cubePrefab;
        private CubeElement[, , ] elements = new CubeElement[4, 4, 4];
        private string[, , ] formulasTensor;
        private string[, , ] indexesTensor;
        private Texture2D[, , ] formulaTextures;
        private Texture2D[, , ] indexTextures;
        private readonly float distance = 12;

        public Cube(CubeElement cubePrefab, string[, , ] formulasTensor, string[, , ] indexesTensor) {
            this.cubePrefab = cubePrefab;
            this.formulasTensor = formulasTensor;
            this.indexesTensor = indexesTensor;
        }

        public async Task Initialize(Func<CubeElement, CubeElement> creator) {
            InitializeElements(creator);
            await InitializeFormulas();
            await InitializeIndexes();
        }

        private void InitializeElements(Func<CubeElement, CubeElement> creator) {
            elements = formulasTensor.Select(CreateElement(creator));
            elements.ForEach(InitializeElement);
        }

        private Func<CubeElement> CreateElement(Func<CubeElement, CubeElement> creator) {
            return () => {
                CubeElement cubeElement = creator(cubePrefab);
                return cubeElement;
            };
        }

        private void InitializeElement(CubeElement element, int i, int j, int k) {
            element.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
            element.Initialize();
        }

        private async Task InitializeFormulas() {
            formulaTextures = await LaTeXTextureDownloader.Fetch(formulasTensor);
            SetFormulaTextures();
        }

        private void SetFormulaTextures() {
            elements.ForEach((element, i, j, k) => {
                element.FormulaTexture = formulaTextures[i, j, k];
            });
        }

        private async Task InitializeIndexes() {
            indexTextures = await LaTeXTextureDownloader.Fetch(indexesTensor);
            SetIndexTextures();
        }

        private void SetIndexTextures() {
            elements.ForEach((element, i, j, k) => {
                element.IndexTexture = indexTextures[i, j, k];
            });
        }

    }
}