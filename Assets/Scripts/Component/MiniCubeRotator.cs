using Data;
using UnityEngine;
[RequireComponent(typeof(MeshCollider))]

public class MiniCubeRotator : ChristofellElement {

    #region ROTATE

    public Direction axis;
    public float rotationAngle;

    #endregion
    
    void OnMouseUp() {
        App.cubeRotationStartedEvent.DispatchEvent(this, new CubeRotationStartedEventArgs(new Dimension(axis), rotationAngle));
    }

}