using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class MetricView : ChristoffelElement {

    public MaskableGraphic loader;

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

    public void ShowMetric() {
        ShowMaskableGraphic(Image);
    }

    public void HideMetric() {
        HideMaskableGraphic(Image);
    }

    public void ShowLoader() {
        ShowMaskableGraphic(loader);
    }

    public void HideLoader() {
        HideMaskableGraphic(loader);
    }

    private void ShowMaskableGraphic(MaskableGraphic graphic) {
        graphic.color = new Color(255, 255, 255, 255);
    }

    private void HideMaskableGraphic(MaskableGraphic graphic) {
        graphic.color = new Color(255, 255, 255, 0);
    }

}