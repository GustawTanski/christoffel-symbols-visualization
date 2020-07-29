using TMPro;
using UnityEngine;


public class GraphicPopper : MonoBehaviour {
    public DynamicImage Image;

    public void SetTexture(Texture2D texture) {
        Image.Texture = texture;
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