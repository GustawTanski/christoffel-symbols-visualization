using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(RectTransform))]

public class TextDescription : MonoBehaviour, IParameterDescription {

    private string parameter;
    private string description;
    public string Parameter {
        get => parameter;
        set {
            parameter = value;
            UpdateText();
        }
    }

    public string Description {
        get => description;
        set {
            description = value;
            UpdateText();
        }
    }

    private void UpdateText() {
        GetComponent<TextMeshProUGUI>().text = $"{parameter} — {description}";
    }


    public void Destroy() {
        Destroy(gameObject);
    }
}