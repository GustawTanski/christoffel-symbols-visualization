using UnityEngine;
using UnityEngine.InputSystem;
public class RotationCalculator {

    private InputControl<Vector2> mouseDelta;
    private FlyingCameraModel model;
    public Quaternion Rotation {
        get;
        private set;
    }

    public RotationCalculator(FlyingCameraModel model) {
        this.model = model;
        mouseDelta = Mouse.current.delta;
    }

    public void Calculate() {
        ComputeAxisAngles();
        Rotation = Quaternion.AngleAxis(model.FromXAxisAngle, Vector3.up);
        Rotation *= Quaternion.AngleAxis(model.FromYAxisAngle, Vector3.left);
    }

    private void ComputeAxisAngles() {
        Vector2 delta = mouseDelta.ReadValue();
        model.FromXAxisAngle += delta.x * GetRotationBase();
        model.FromYAxisAngle += delta.y * GetRotationBase();
        model.FromYAxisAngle = Mathf.Clamp(model.FromYAxisAngle, -90, 90);
    }

    private float GetRotationBase() {
        return model.cameraSensitivity * Time.deltaTime;
    }
}