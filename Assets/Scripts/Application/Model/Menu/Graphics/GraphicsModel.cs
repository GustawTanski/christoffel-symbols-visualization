using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphicsModel : ChristofellElement {

    public List<Resolution> Resolutions { get; set; }

    public Resolution Resolution {
        get => resolution;
        set {
            resolution = value;
            PlayerPrefs.SetInt("Resolution.width", value.width);
            PlayerPrefs.SetInt("Resolution.height", value.height);
            PlayerPrefs.SetInt("Resolution.refreshRate", value.refreshRate);
        }
    }

    private Resolution resolution;

    public bool IsFullScreen {
        get => isFullScreen;
        set {
            isFullScreen = value;
            PlayerPrefs.SetString("Full Screen", value.ToString());
        }
    }

    private bool isFullScreen;

    private void Awake() {
        InitializeResolutions();
        InitializeFullScreenData();
        InitializeResolutionData();
    }

    private void InitializeResolutions() {
        Resolutions = GetSortedResolutions();
    }

    private List<Resolution> GetSortedResolutions() {
        return Screen.resolutions
            .Where(res => res.refreshRate == 60)
            .OrderByDescending(res => res.height)
            .OrderByDescending(res => res.width)
            .ToList();
    }

    private void InitializeFullScreenData() {
        if (IsFullScreenDataSaved()) SetFullScreenDataFromMemory();
        else SetFullScreenInfoFromScreen();
    }

    private bool IsFullScreenDataSaved() {
        return PlayerPrefs.HasKey("Full Screen");
    }

    private void SetFullScreenDataFromMemory() {
        isFullScreen = ReadFullScreenInfo();
    }

    private bool ReadFullScreenInfo() {
        return bool.Parse(PlayerPrefs.GetString("Full Screen"));
    }

    private void SetFullScreenInfoFromScreen() {
        IsFullScreen = Screen.fullScreen;
    }

    private void InitializeResolutionData() {
        if (IsWholeResolutionDataSaved()) SetResolutionDataFromMemory();
        else SetResolutionDataFromScreen();
    }

    private bool IsWholeResolutionDataSaved() {
        return PlayerPrefs.HasKey("Resolution.width") &&
            PlayerPrefs.HasKey("Resolution.height") &&
            PlayerPrefs.HasKey("Resolution.refreshRate");
    }

    private void SetResolutionDataFromMemory() {
        resolution = ReadResolutionData();
    }

    private Resolution ReadResolutionData() {
        return new Resolution() {
            width = PlayerPrefs.GetInt("Resolution.width"),
                height = PlayerPrefs.GetInt("Resolution.height"),
                refreshRate = PlayerPrefs.GetInt("Resolution.refreshRate")
        };
    }

    private void SetResolutionDataFromScreen() {
        Resolution = Screen.currentResolution;
    }
}