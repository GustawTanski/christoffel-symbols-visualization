using Data;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MeshCollider))]

public class MiniCubeRotator : ChristoffelElement {
    public Direction axis;
    public float rotationAngle;
    public float growFactor;
    private Ray ray;
    private RaycastHit hit;

    private void DispatchMinuCubeRotatorClickedEvent() {
        MiniCubeRotatorClickedArgs e = new MiniCubeRotatorClickedArgs(new Dimension(axis), rotationAngle);
        App.miniCubeRotatorClicked.DispatchEvent(this, e);
    }

    private void Update() {
        if (IsHit()) HandleHit();
    }

    private bool IsHit() {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        return Physics.Raycast(ray, out hit);
    }

    private void HandleHit() {
        if (IsHittedAndMouseUp()) DispatchMinuCubeRotatorClickedEvent();
    }

    private bool IsHittedAndMouseUp() {
        return IsHitted() && WasMouseReleasedThisFrame();
    }

    private bool IsHitted() {
        return hit.transform == transform;
    }

    private bool WasMouseReleasedThisFrame() {
        return Mouse.current.press.wasReleasedThisFrame;
    }
}