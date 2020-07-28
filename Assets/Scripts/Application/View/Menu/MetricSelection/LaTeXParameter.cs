using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(HorizontalLayoutGroup))]

public class LaTeXParameter : MonoBehaviour, IChristoffelParameter {
    public DynamicImage parameterImage;
    private string parameter;

    public string Parameter {
        get => parameter;
        set {
            parameter = value;
            UpdateImage();
        }
    }

    public string Description {
        get;
        set;
    }

    public async void UpdateImage() {
        parameterImage.Texture = await LaTeXTextureDownloader.FetchOneTexture(parameter);
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}