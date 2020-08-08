using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshCollider))]

public class MouseFocuser : MonoBehaviour {
    public Texture2D focusCursor;
    public Material standardMaterial;
    public Material focusMaterial;

    private bool isFocused = false;

    private void Update() {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform == transform) {
                if (!isFocused)
                    Focus();
            } else if (isFocused) {
                Debug.Log("Blurrin...");
                Blur();
            }
        }
    }

    public void Focus() {
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

    private void OnMouseExit() {
        Blur();
    }

    private void Blur() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SetMaterialOnAllChildren(standardMaterial);
        isFocused = false;
    }

}