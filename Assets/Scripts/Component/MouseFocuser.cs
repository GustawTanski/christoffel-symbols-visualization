using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class MouseFocuser : MonoBehaviour {
    public Texture2D focusCursor;
    public Material standardMaterial;
    public Material focusMaterial;
    private void OnMouseOver() {
        Focus();
    }

    private void Focus() {
        Cursor.SetCursor(focusCursor, Vector2.zero, CursorMode.Auto);
        SetMaterialOnAllChildren(focusMaterial);
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
    }
}