using TMPro;
using UnityEngine;

public class Popper : MonoBehaviour {
    public TMP_Text caption;

    public void SetText(string text) {
        caption.text = text;
    }

    public void MoveAndShow(Vector3 position) {
        Move(position);
        Show();
    }

    public void Move(Vector3 position) {
        transform.position = position;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}