using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(PopperShower))]

public class TextParameter : MonoBehaviour, IChristoffelParameter {

    public TMP_Text parameter;
    public string Parameter {
        get => parameter.text;
        set => parameter.text = value;
    }

    public string Description {
        get => GetComponent<PopperShower>().message;
        set => GetComponent<PopperShower>().message = value;
    }

    public Popper Popper {
        set => GetComponent<PopperShower>().popper = value;
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}