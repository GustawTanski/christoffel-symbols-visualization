using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class TextParameter : MonoBehaviour, IChristoffelParameter {

    public TMP_Text parameter;
    public string Parameter {
        get => parameter.text;
        set => parameter.text = value;
    }

    public string Description {
        get;
        set;
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}