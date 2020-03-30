using Data;
using UnityEngine;
public class MiniCubeView : ChristofellElement {
    private Quaternion zeroRotation;
    private Quaternion targetRotation;
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
        targetRotation = zeroRotation;
    }

    private void Update() {
        if (LocalRotation != targetRotation) {
            LocalRotation = Quaternion.Slerp(LocalRotation, targetRotation, Time.deltaTime);
        }
    }

    public void RotateAroundX(float angle) {
        RotateAroundAxis(new Dimension(Direction.x), angle);
    }

    public void RotateAroundY(float angle) {
        RotateAroundAxis(new Dimension(Direction.y), angle);
    }

    public void RotateAroundZ(float angle) {
        RotateAroundAxis(new Dimension(Direction.z), angle);
    }

    private void RotateAroundAxis(Dimension axis, float angle) {
        StartRotation(Quaternion.AngleAxis(angle, axis.DirVector));
    }

    private void StartRotationTo(Quaternion target) {
        targetRotation = target;
    }

    private void StartRotation(Quaternion rotation) {
        targetRotation = rotation * targetRotation;
    }
}