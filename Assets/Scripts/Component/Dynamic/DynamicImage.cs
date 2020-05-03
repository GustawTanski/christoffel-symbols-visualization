using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]

public class DynamicImage : MonoBehaviour {

    public RectTransform RectTransform => GetComponent<RectTransform>();
    private Image Image => GetComponent<Image>();
    public Texture2D Texture {
        set {
            Vector3 pos = RectTransform.position;
            Sprite sprite = SpriteCreator.Create(value);
            Image.sprite = sprite;
            float factor = RectTransform.rect.height / sprite.rect.height;
            RectTransform.offsetMax = sprite.rect.size * factor;
            RectTransform.offsetMin = Vector2.zero;
            // RectTransform.position = pos;
        }
    }
}