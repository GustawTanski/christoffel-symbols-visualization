using UnityEngine;
using UnityEngine.InputSystem;
public class RotationCalculator {

    private InputAction mouseDeltaAction;
    private FlyingCameraModel model;
    public Quaternion Rotation {
        get;
        private set;
    }

    public RotationCalculator(FlyingCameraModel model, InputAction mouseDeltaAction) {
        this.model = model;
        this.mouseDeltaAction = mouseDeltaAction;
    }

    public void Calculate() {
        ComputeAxisAngles();
        Rotation = Quaternion.AngleAxis(model.FromXAxisAngle, Vector3.up);
        Rotation *= Quaternion.AngleAxis(model.FromYAxisAngle, Vector3.left);
    }

    private void ComputeAxisAngles() {
        Vector2 mouseDelta = mouseDeltaAction.ReadValue<Vector2>();
        model.FromXAxisAngle += mouseDelta.x * GetRotationBase();
        model.FromYAxisAngle += mouseDelta.y * GetRotationBase();
        model.FromYAxisAngle = Mathf.Clamp(model.FromYAxisAngle, -90, 90);
    }

    private float GetRotationBase() {
        return model.cameraSensitivity * Time.deltaTime;
    }
}