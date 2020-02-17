using Latex;
using UnityEngine;

namespace Cube {
    public class CubeElement : MonoBehaviour {
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

        public Vector3 LocalPosition {
            set {
                transform.localPosition = value;
            }
            get {
                return transform.localPosition;
            }
        }

        public void Initialize() {
            formula = Instantiate(latexPrefab, transform);
            formula.LocalPosition = new Vector3(0.5f, 0.5f, -0.5f) * distance;
            index = Instantiate(latexPrefab, transform);
            index.LocalPosition = new Vector3(0.5f, 0.75f, -0.5f) * distance;
            index.SwitchAppear();
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Tab)) {
                index.SwitchAppear();
            }
            transform.rotation = Camera.main.transform.rotation;
        }

        public void ToggleAppear() {
            if (IsVisible()) Disappear();
            else Appear();
        }

        public void Appear() {
            transform.localScale = Vector3.one;
        }

        public void Disappear() {
            transform.localScale = Vector3.zero;
        }

        private bool IsVisible() {
            return transform.localScale == Vector3.one;
        }
    }
}