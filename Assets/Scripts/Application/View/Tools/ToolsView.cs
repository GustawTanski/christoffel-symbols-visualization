using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsView : ChristofellElement {
    public Toggle zerosToggle;
    public Button resetButton;
    public LineRenderer line;
    public Slider labelSlider;
    public TMP_Text labelSliderCaption;
    public TMP_Text spacetimeName;

    public CubeDescriptionView cubeDescription;

    public void HideLine() {
        line.startWidth = line.endWidth = 0;
    }

    public void DrawLine() {
        line.startWidth = line.endWidth = 0.1f;
        line.SetPositions(new Vector3[] { App.model.tools.LineStartPivot.Position, App.model.tools.LineEndPivot.Position });
    }
}