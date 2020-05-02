using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class LaTeXDescription : MonoBehaviour, IParameterDescription {
    private string parameter;

    public DynamicImage parameterImage;
    public TextMeshProUGUI description;

    public RectTransform RectTransform => GetComponent<RectTransform>();
    public string Parameter {
        get => parameter;
        set {
            parameter = value;
            UpdateImage();
        }
    }

    public string Description {
        get => description.text;
        set => description.text = value;
    }

    public async void UpdateImage() {
        Debug.Log("woof1");
        var texture = await LaTeXTextureDownloader.FetchOneTexture(parameter);
        parameterImage.Texture = texture;
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}