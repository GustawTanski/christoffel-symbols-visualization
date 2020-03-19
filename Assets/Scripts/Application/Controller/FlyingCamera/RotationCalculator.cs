using UnityEngine;
public class RotationCalculator {
    private FlyingCameraModel model;
    public Quaternion Rotation {
        get;
        private set;
    }

    public RotationCalculator(FlyingCameraModel model) {
        this.model = model;
    }

    public void CalculateRotation() {
        ComputeAxisAngles();
        Rotation = Quaternion.AngleAxis(model.FromXAxisAngle, Vector3.up);
        Rotation *= Quaternion.AngleAxis(model.FromYAxisAngle, Vector3.left);
    }

    private void ComputeAxisAngles() {
        model.FromXAxisAngle += Input.GetAxis("Mouse X") * GetRotationBase();
        model.FromYAxisAngle += Input.GetAxis("Mouse Y") * GetRotationBase();
        model.FromYAxisAngle = Mathf.Clamp(model.FromYAxisAngle, -90, 90);
    }

    private float GetRotationBase() {
        return model.cameraSensitivity * Time.deltaTime;
    }
}