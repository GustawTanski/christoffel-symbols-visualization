using UnityEngine.UI;
using TMPro;

public class GraphicsView : MenuElement {
    public Toggle fullScreenToggle;
    public TMP_Dropdown resolutionDropdown;

    public void SetToggle(bool isMarked) {
        fullScreenToggle.isOn = isMarked;
    }
}