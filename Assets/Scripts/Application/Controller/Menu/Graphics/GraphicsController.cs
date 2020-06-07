using System.Linq;
using UnityEngine;
public class GraphicsController : ChristofellElement {

    public GraphicsModel Model => App.model.menu.graphics;
    public GraphicsView View => App.view.menu.graphics;
    private void Start() {
        Screen.fullScreen = Model.IsFullScreen;
        View.SetToggle(Model.IsFullScreen);
        View.resolutionDropdown.ClearOptions();
        View.resolutionDropdown.AddOptions(Model.Resolutions.Select(res => $"{res.width} × {res.height}").ToList());
        int a = Model.Resolutions.FindIndex(res => res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height);
        View.resolutionDropdown.value = a;
        View.resolutionDropdown.RefreshShownValue();
    }

    public void SetFullScreen(bool isFullScreen) {
        Model.IsFullScreen = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution res = Model.Resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Model.IsFullScreen);
        Model.Resolution = res;
    }
}