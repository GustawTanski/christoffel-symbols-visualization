using Latex;
using UnityEngine;

namespace Cube {
    class CubeElement : MonoBehaviour {
        public LatexSprite latexPrefab;
        public float distance = 12;
        private LatexSprite formula;
        private LatexSprite index;

        public Texture2D IndexTexture {
            set {
                index.SetTexture(value);
            }
        }

        public Texture2D FormulaTexture {
            set {
                formula.SetTexture(value);
            }
        }

        private void Start() {
            formula = Instantiate(latexPrefab, transform);
            formula.transform.localPosition = new Vector3(0.5f, -0.5f, 0.5f) * distance;
            index = Instantiate(latexPrefab, transform);
            index.transform.localPosition = new Vector3(0.5f, 0.2f, 0.5f) * distance;
        }

    }
}