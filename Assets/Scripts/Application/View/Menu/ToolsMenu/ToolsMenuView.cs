using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsMenuView : MenuElement {
    public Dropdown dropdown;
    public Toggle zerosToggle;
    public Button resetButton;
    public LineRenderer line;
    public Slider labelSlider;
    public TMP_Text labelSliderCaption;

    public CubeDescriptionView cubeDescription;
    public SelectionCrossView selectionCross;

    public void HideLine() {
        line.startWidth = line.endWidth = 0;
    }

    public void DrawLine() {
        line.startWidth = line.endWidth = 0.1f;
        line.SetPositions(new Vector3[] { App.model.menu.toolsMenu.LineStartPivot.Position, App.model.menu.toolsMenu.LineEndPivot.Position });
    }
}