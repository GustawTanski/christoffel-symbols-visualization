using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class MetricView : ChristoffelElement {

    private RawImage Image => GetComponent<RawImage>();
    private RectTransform RectTransform => GetComponent<RectTransform>();
    public Texture2D Texture {
        set {
            float height = RectTransform.rect.height;
            Image.texture = value;
            Image.SetNativeSize();
            float scale = height / RectTransform.rect.height;
            RectTransform.sizeDelta *= scale;
        }
    }

}