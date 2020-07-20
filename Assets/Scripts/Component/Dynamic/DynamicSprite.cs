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

    public int dimensionLimit = int.MaxValue;

    private Vector3 initialScale;

    private void Awake() {
        initialScale = transform.localScale;
    }

    public void SetTexture(Texture2D texture) {
        GetComponent<SpriteRenderer>().sprite = SpriteCreator.Create(texture);
        int biggerDimension = texture.width > texture.height ? texture.width : texture.height;
        if ((float) biggerDimension / 100 > dimensionLimit) {
            transform.localScale = initialScale * ((float) dimensionLimit * 100 / biggerDimension) * 0.95f;
        } else {
            transform.localScale = initialScale;
        }
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