using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Popper : MonoBehaviour {
    public TMP_Text caption;

    public void SetText(string text) {
        caption.text = text;
    }

    public void MoveAndShow(Vector3 localPosition) {
        Move(localPosition);
        Show();
    }

    public void Move(Vector3 localPosition) {
        transform.localPosition = localPosition;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}