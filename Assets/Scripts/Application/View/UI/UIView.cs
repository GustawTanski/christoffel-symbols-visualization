using UnityEngine;
using UnityEngine.UI;

public class UIView : ChristofellElement {
    public Dropdown dropdown;
    public Toggle zerosToggle;
    public Image line;
    public void HideLine() {
        line.rectTransform.sizeDelta = Vector2.zero;
    }

    public void UpdateLine() {
        SetLineSize();
        SetLinePivot();
        SetLinePosition();
        SetLineRotation();
    }

    private void SetLineSize() {
        line.rectTransform.sizeDelta = new Vector2(GetLineLength(), 3);
    }

    private float GetLineLength() {
        return App.model.uI.LineDifferenceVector.magnitude / line.canvas.scaleFactor;
    }

    private void SetLinePivot() {
        line.rectTransform.pivot = new Vector2(0, 0.5f);
    }

    private void SetLinePosition() {
        line.rectTransform.position = App.model.uI.LineStart;
    }

    private void SetLineRotation() {
        Vector2 differenceVector = App.model.uI.LineDifferenceVector;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        line.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}