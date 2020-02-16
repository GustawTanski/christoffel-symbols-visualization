using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Latex {

    public class LatexSprite : MonoBehaviour {

        private Vector3 translation = new Vector3(0, 0, 0);

        private Vector3 localPosition = new Vector3(0, 0, 0);
        private Texture2D texture;

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

        public void SwitchAppear() {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }

        public void Appear() {
            if (!gameObject.activeInHierarchy) {
                gameObject.SetActive(true);
            }
        }

        public void Disappear() {
            if (gameObject.activeInHierarchy) {
                gameObject.SetActive(false);
            }
        }
    }
}