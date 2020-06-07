using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GraphicsController : ChristofellElement {

    public GraphicsModel Model => App.model.menu.graphics;
    public GraphicsView View => App.view.menu.graphics;
    private void Start() {
        InitializeFullScreen();
        InitializeResolution();
    }

    private void InitializeFullScreen() {
        Screen.fullScreen = Model.IsFullScreen;
        View.SetToggle(Model.IsFullScreen);
    }

    private void InitializeResolution() {
        PopulateResolutionDropdown();
        SetDropdownInitialState();
    }

    private void PopulateResolutionDropdown() {
        View.resolutionDropdown.ClearOptions();
        View.resolutionDropdown.AddOptions(GetResolutionOptions());
    }

    private List<string> GetResolutionOptions() {
        return Model.Resolutions.Select(res => $"{res.width} × {res.height}").ToList();
    }

    private void SetDropdownInitialState() {
        View.resolutionDropdown.value = GetCurrentResolutionIndex();
        View.resolutionDropdown.RefreshShownValue();
    }

    private int GetCurrentResolutionIndex() {
        return Model.Resolutions.FindIndex(IsCurrentResolution);
    }

    private bool IsCurrentResolution(Resolution res) {
        return res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height;
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