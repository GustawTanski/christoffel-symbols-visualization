using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Latex {

    public class LatexSprite : MonoBehaviour {
        // Start is called before the first frame update

        private Vector3 translation = new Vector3(0, 0, 0);

        private Vector3 localPosition = new Vector3(0, 0, 0);

        private string latex = "0";
        private Texture2D texture;

        private UnityWebRequest www;

        public string Latex {
            get {
                return latex;
            }
            set {
                Debug.Log(value);
                latex = value;
                StartCoroutine(DownloadLatexTexture());
            }
        }

        public Vector3 LocalPosition {
            get {
                return localPosition;
            }
            set {
                localPosition = value;
                transform.localPosition = value + translation;
            }
        }

        public Vector3 Translation {
            get {
                return translation;
            }

            set {
                translation = value;
                transform.localPosition = value + localPosition;
            }
        }

        public void Translate(Vector3 translation) {
            LocalPosition += translation;
        }

        public void Translate(float x, float y, float z) {
            Translate(new Vector3(x, y, z));
        }

        public void SetTexture(Texture2D texture) {
            this.texture = texture;
            SetSprite();
        }

        private IEnumerator DownloadLatexTexture() {
            yield return FetchTexture();
            LoadTexture();
            SetSprite();
        }

        private UnityWebRequestAsyncOperation FetchTexture() {
            www = UnityWebRequestTexture.GetTexture(GetUrl());
            return www.SendWebRequest();
        }

        private string GetUrl() {
            return $"https://latex.codecogs.com/png.latex?{GetLatexString()}";
        }

        private string GetLatexString() {
            return @"\dpi{999}" + latex;
        }

        private void LoadTexture() {
            texture = DownloadHandlerTexture.GetContent(www);
        }

        private void SetSprite() {
            GetComponent<SpriteRenderer>().sprite = CreateSprite();
        }

        private Sprite CreateSprite() {
            const int PIXELS_PER_UNIT = 100;
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                PIXELS_PER_UNIT
            );
        }

        private void Update() {
            transform.rotation = Camera.main.transform.rotation;
        }

    }
}