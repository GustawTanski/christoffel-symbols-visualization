using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsView : ChristoffelElement {
    public Toggle zerosToggle;
    public Toggle cubesToggle;
    public Button resetButton;
    public LineRenderer line;
    public Slider labelSlider;
    public TMP_Text labelSliderCaption;
    public TMP_Text spacetimeName;
    public SymbolView symbol;

    public void HideLine() {
        line.startWidth = line.endWidth = 0;
    }

    public void DrawLine() {
        line.startWidth = line.endWidth = 0.1f;
        line.SetPositions(new Vector3[] { App.model.tools.LineStartPivot.Position, App.model.tools.LineEndPivot.Position });
    }
}