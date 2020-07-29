using UnityEngine;

public class AutoscalingDynamicImage : DynamicImage {
    protected override int GetPixelsPerUnit() {
        int pixelsPerUnit = (int)((float)texture.height / RectTransform.rect.height);
        return pixelsPerUnit > 0 ? pixelsPerUnit : 1;
    }
}