using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]

public class DynamicImage : MonoBehaviour {
    public int heightLimit = int.MaxValue;
    public RectTransform RectTransform => GetComponent<RectTransform>();
    private Image Image => GetComponent<Image>();
    public Texture2D Texture {
        set => SetTexture(value);
    }

    private Texture2D texture;

    private void SetTexture(Texture2D texture) {
        this.texture = texture;
        int PIXELS_PER_UNIT = (int) ((float) texture.height / RectTransform.rect.height);
        Image.sprite = SpriteCreator.Create(texture, PIXELS_PER_UNIT);
    }
}