using UnityEngine;
public class MiniCubeView : ChristofellElement {
    private Quaternion zeroRotation;
    public Quaternion LocalRotation {
        get {
            return transform.localRotation * Quaternion.Inverse(zeroRotation);
        }

        set {
            transform.localRotation = value * zeroRotation;
        }
    }
    private void Start() {
        zeroRotation = transform.localRotation;
    }
}