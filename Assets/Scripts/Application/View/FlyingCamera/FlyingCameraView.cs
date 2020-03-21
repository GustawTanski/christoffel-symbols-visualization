using UnityEngine;

public class FlyingCameraView : ChristofellElement {
    public void RotateTo(Quaternion rotation) {
        transform.localRotation = rotation;
    }

    public void Translate(Vector3 translation) {
        transform.position += translation;
    }
}