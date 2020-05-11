using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class AutoResizeVerticalText : MonoBehaviour {

    TextMeshProUGUI TextMesh => GetComponent<TextMeshProUGUI>();
    RectTransform RectTransform => GetComponent<RectTransform>();

    private void Start() {
        TextMesh.overflowMode = TextOverflowModes.Truncate;
        AdjustRectHeightToText();
    }
    private void AdjustRectHeightToText() {
        RectTransform.offsetMin = CalculateCorrectOffsetMin();
    }
    private Vector2 CalculateCorrectOffsetMin() {
        return new Vector2(RectTransform.offsetMin.x, RectTransform.offsetMax.y - TextMesh.preferredHeight);;
    }
    private void Update() {
        if (HasRectDifferentHeightThanText()) AdjustRectHeightToText();
    }
    private bool HasRectDifferentHeightThanText() {
        return Mathf.Abs(RectTransform.rect.height - TextMesh.preferredHeight) > 1;
    }
}