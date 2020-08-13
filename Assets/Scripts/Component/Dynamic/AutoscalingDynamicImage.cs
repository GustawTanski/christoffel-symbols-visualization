using UnityEngine;

public class AutoscalingDynamicImage : DynamicImage {

    private int pixelsPerUnit;
    private const int FALLBACK_PIXELS_PER_UNIT = 1;
    protected override int GetPixelsPerUnit() {
        pixelsPerUnit = CalculatePixelsPerUnitBasedOnRectHeight();
        if (IsPixelsPerUnitGreaterThanZero()) return pixelsPerUnit;
        else return FALLBACK_PIXELS_PER_UNIT;
    }

    private int CalculatePixelsPerUnitBasedOnRectHeight() {
        return (int) ((float) texture.height / RectTransform.rect.height);
    }

    private bool IsPixelsPerUnitGreaterThanZero() {
        return pixelsPerUnit > 0;
    }
}