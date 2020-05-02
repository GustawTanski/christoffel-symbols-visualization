using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class DynamicImage : MonoBehaviour {
    public Texture2D Texture {
        set {
            Debug.Log("woof");
            GetComponent<Image>().sprite = SpriteCreator.Create(value);
            GetComponent<Image>().SetNativeSize();
        }
    }
}