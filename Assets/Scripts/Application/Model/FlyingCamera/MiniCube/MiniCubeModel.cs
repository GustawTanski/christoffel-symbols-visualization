using UnityEngine;
public class MiniCubeModel : ChristoffelElement {
    public Quaternion TargetRotation { get; set; }
    public Quaternion ZeroRotation { get; set; }
    public Quaternion LocalRotation { get; set; }
    public Quaternion RelativeToCubeRotation { get; set; }
}
