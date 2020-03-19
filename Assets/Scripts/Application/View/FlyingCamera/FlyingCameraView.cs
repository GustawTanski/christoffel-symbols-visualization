using UnityEngine;

public class FlyingCameraView : ChristofellElement {
    public void RotateTo(Quaternion rotation) {
        transform.rotation = rotation;
    }

    public void Translate(Vector3 translation) {
        transform.Translate(translation);
    }
}