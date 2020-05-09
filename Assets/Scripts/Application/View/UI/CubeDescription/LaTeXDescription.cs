using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(HorizontalLayoutGroup))]

public class LaTeXDescription : MonoBehaviour, IParameterDescription {
    private string parameter;

    public DynamicImage parameterImage;
    public TextMeshProUGUI description;

    public string Parameter {
        get => parameter;
        set {
            parameter = value;
            UpdateImage();
        }
    }

    public string Description {
        get => description.text;
        set => description.text = "— " + value;
    }

    public async void UpdateImage() {
        parameterImage.Texture = await LaTeXTextureDownloader.FetchOneTexture(parameter);
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}