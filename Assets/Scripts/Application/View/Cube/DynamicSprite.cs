using UnityEngine;

public class DynamicSprite : MonoBehaviour {

    private Texture2D texture;

    public Vector3 LocalPosition {
        get {
            return transform.localPosition;
        }
        set {
            transform.localPosition = value;
        }
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

    public void ToggleAppear() {
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