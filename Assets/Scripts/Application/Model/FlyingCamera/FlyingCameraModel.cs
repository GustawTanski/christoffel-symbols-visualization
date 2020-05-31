using UnityEngine;
public class FlyingCameraModel : ChristofellElement {

    public MiniCubeModel miniCube;
    public float cameraSensitivity = 10;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;
    public bool isActive = true;
    public float FromXAxisAngle { get; set; }
    public float FromYAxisAngle { get; set; }
    public Vector3 InitialPosition { get; set; }
}