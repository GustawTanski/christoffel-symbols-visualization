public class FlyingCameraModel : ChristofellElement {
    public float cameraSensitivity = 90;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;
    public bool IsActive { get; set; } = true;
    public float FromXAxisAngle { get; set; }
    public float FromYAxisAngle { get; set; }
}