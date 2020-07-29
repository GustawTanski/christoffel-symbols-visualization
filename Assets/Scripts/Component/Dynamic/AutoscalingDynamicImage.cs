using UnityEngine;

public class AutoscalingDynamicImage : DynamicImage {
    protected override int GetPixelsPerUnit(Texture2D texture) {
        int pixelsPerUnit = (int)((float)texture.height / RectTransform.rect.height);
        return pixelsPerUnit > 0 ? pixelsPerUnit : 1;
    }
}