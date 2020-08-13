using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshCollider))]

public class MouseFocuser : MonoBehaviour {
    public Texture2D focusCursor;
    public Material standardMaterial;
    public Material focusMaterial;

    private bool isFocused = false;
    private Ray ray;
    private RaycastHit hit;

    private void Update() {
        if (IsHit() && IsHitted()) IfIsNotFocusedFocus();
        else IfIsFocusedBlur();
    }

    private bool IsHit() {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        return Physics.Raycast(ray, out hit);
    }

    private bool IsHitted() {
        return hit.transform == transform;
    }

    private void IfIsNotFocusedFocus() {
        if (!isFocused) Focus();
    }

    private void Focus() {
        Cursor.SetCursor(focusCursor, Vector2.zero, CursorMode.Auto);
        SetMaterialOnAllChildren(focusMaterial);
        isFocused = true;
    }

    private void SetMaterialOnAllChildren(Material material) {
        foreach (Transform child in transform) SetMaterialOnChild(material, child);
    }

    private void SetMaterialOnChild(Material material, Transform child) {
        Renderer renderer = child.GetComponent<Renderer>();
        if (renderer != null) renderer.materials = new [] { material };
    }

    private void IfIsFocusedBlur() {
        if (isFocused) Blur();
    }

    private void Blur() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SetMaterialOnAllChildren(standardMaterial);
        isFocused = false;
    }

}