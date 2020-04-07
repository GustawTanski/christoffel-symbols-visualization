using System;
using UnityEngine;
public class MiniCubeModel : ChristofellElement {
    public Quaternion TargetRotation { get; set; }
    public Quaternion ZeroRotation { get; set; }
    public Quaternion LocalRotation { get; set; }
    public Quaternion RelativeToCubeRotation { get; set; }

    public bool IsRotating => (TargetRotation.eulerAngles - LocalRotation.eulerAngles).magnitude > 100;

}
