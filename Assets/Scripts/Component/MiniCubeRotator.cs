using Data;
using UnityEngine;
[RequireComponent(typeof(MeshCollider))]

public class MiniCubeRotator : ChristoffelElement {
    public Direction axis;
    public float rotationAngle;
    public float growFactor;
    private void OnMouseUp() {
        MiniCubeRotatorClickedArgs e = new MiniCubeRotatorClickedArgs(new Dimension(axis), rotationAngle);
        App.miniCubeRotatorClicked.DispatchEvent(this, e);
    }

}