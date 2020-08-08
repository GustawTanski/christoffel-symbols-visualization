using Data;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MeshCollider))]

public class MiniCubeRotator : ChristoffelElement {
    public Direction axis;
    public float rotationAngle;
    public float growFactor;
    private void OnMouseUp() {
        MiniCubeRotatorClickedArgs e = new MiniCubeRotatorClickedArgs(new Dimension(axis), rotationAngle);
        App.miniCubeRotatorClicked.DispatchEvent(this, e);
    }

    private void Update() {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform == transform && Mouse.current.press.wasReleasedThisFrame) {
                OnMouseUp();
            }
        }
    }
}