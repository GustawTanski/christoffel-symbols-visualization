using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class SymbolView : ChristoffelElement {
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

    private void ShowMaskableGraphic(MaskableGraphic graphic) {
        graphic.color = new Color(255, 255, 255, 255);
    }

    private void HideMaskableGraphic(MaskableGraphic graphic) {
        graphic.color = new Color(255, 255, 255, 0);
    }

    public void ShowSymbol() {
        ShowMaskableGraphic(Image);
    }

    public void HideSymbol() {
        HideMaskableGraphic(Image);
    }

    public void ShowLoader() {
        ShowMaskableGraphic(loader);
    }

    public void HideLoader() {
        HideMaskableGraphic(loader);
    }
}