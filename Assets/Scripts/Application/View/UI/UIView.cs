using UnityEngine;
using UnityEngine.UI;

public class UIView : ChristofellElement {
    public Dropdown dropdown;
    public Toggle zerosToggle;
    public Button resetButton;
    public LineRenderer line;

    public Canvas canvas;

    public CubeDescriptionView cubeDescription;

    public void SetCanvasActivity(bool isActive) {
        canvas.gameObject.SetActive(isActive);
    }

    public void HideLine() {
        line.startWidth = line.endWidth = 0;
    }

    public void DrawLine() {
        line.startWidth = line.endWidth = 0.1f;
        line.SetPositions(new Vector3[] { App.model.uI.LineStartPivot.Position, App.model.uI.LineEndPivot.Position });
    }
}