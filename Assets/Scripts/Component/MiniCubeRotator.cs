using Data;
using UnityEngine;
[RequireComponent(typeof(MeshCollider))]

public class MiniCubeRotator : ChristofellElement {
    public Direction axis;
    public float rotationAngle;
    public float growFactor;
    private void OnMouseUp() {
        MiniCubeRotatorClickedEventArgs e = new MiniCubeRotatorClickedEventArgs(new Dimension(axis), rotationAngle);
        App.miniCubeRotatorClicked.DispatchEvent(this, e);
    }

}