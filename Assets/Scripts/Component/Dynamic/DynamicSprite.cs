using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

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
        GetComponent<SpriteRenderer>().sprite = SpriteCreator.Create(texture);
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