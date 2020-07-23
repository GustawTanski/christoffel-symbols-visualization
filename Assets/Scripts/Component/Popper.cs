using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Popper : MonoBehaviour {
    public TMP_Text caption;
    
    public void SetText(string text) {
        caption.text = text;
    }

    public void Show(Vector3 localPosition) {
        transform.localPosition = localPosition;
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}