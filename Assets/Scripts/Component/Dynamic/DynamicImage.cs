using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]

public class DynamicImage : MonoBehaviour {
    public RectTransform RectTransform => GetComponent<RectTransform>();
    private Image Image => GetComponent<Image>();
    public Texture2D Texture {
        set => SetTexture(value);
    }

    private Texture2D texture;

    private void SetTexture(Texture2D texture) {
        this.texture = texture;
        Image.sprite = SpriteCreator.Create(texture, GetPixelsPerUnit(texture));
    }

    protected virtual int GetPixelsPerUnit(Texture2D texture) {
        return 100;
    }
}