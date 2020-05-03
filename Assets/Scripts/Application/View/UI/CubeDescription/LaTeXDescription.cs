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
        set => description.text = "- "+value;
    }

    public async void UpdateImage() {
        var texture = await LaTeXTextureDownloader.FetchOneTexture(parameter);
        parameterImage.Texture = texture;
        Vector3 pos = description.rectTransform.localPosition;
        pos = pos - Vector3.right * pos.x;
        pos.x = parameterImage.RectTransform.rect.width * parameterImage.RectTransform.localScale.x + parameterImage.RectTransform.rect.x + 5;
        description.rectTransform.localPosition = pos;
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}