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
        Resolutions = Screen.resolutions
            .Where(res => res.refreshRate == 60)
            .OrderByDescending(res => res.height)
            .OrderByDescending(res => res.width)
            .ToList();
        if (PlayerPrefs.HasKey("Full Screen"))
            isFullScreen = bool.Parse(PlayerPrefs.GetString("Full Screen"));
        else IsFullScreen = Screen.fullScreen;

        if (PlayerPrefs.HasKey("Resolution.width") &&
            PlayerPrefs.HasKey("Resolution.height") &&
            PlayerPrefs.HasKey("Resolution.refreshRate")) {
            resolution = new Resolution() {
                width = PlayerPrefs.GetInt("Resolution.width"),
                height = PlayerPrefs.GetInt("Resolution.height"),
                refreshRate = PlayerPrefs.GetInt("Resolution.refreshRate")
            };
        } else Resolution = Screen.currentResolution;

    }
}