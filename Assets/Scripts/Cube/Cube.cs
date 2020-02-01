using System;
using Latex;
using UnityEngine;

namespace Cube {

    internal class Cube {
        private LatexSprite prefab;

        private LatexSprite[, , ] elements;

        private string[, , ] latexTensor;

        private float distance = 12;

        public Cube(LatexSprite prefab, string[, , ] latexTensor, Func<LatexSprite, LatexSprite> creator) {
            this.prefab = prefab;
            this.latexTensor = latexTensor;
            elements = new LatexSprite[4, 4, 4];
            InitializeElements(creator);
        }

        private void InitializeElements(Func<LatexSprite, LatexSprite> creator) {
            for (int i = 0; i < latexTensor.GetLength(0); i++) {
                for (int j = 0; j < latexTensor.GetLength(1); j++) {
                    for (int k = 0; k < latexTensor.GetLength(2); k++) {
                        var element = creator(prefab);
                        elements[i, j, k] = element;
                        element.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
                        element.Latex = @"{\color{white}" + latexTensor[i, j, k] + @"}";
                    }
                }
            }
        }
    }
}