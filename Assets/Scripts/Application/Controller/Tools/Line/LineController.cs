using UnityEngine;

public class LineController : ChristofellElement {

    private RaycastHit hit;
    private bool isHit = false;

    private void Update() {
        UpdateLine();
    }

    private void UpdateLine() {
        if (WasMouseButtonPressed()) OnMouseDown();
        if (IsMousePressed()) OnMousePressed();
        if (WasMouseButtonReleased()) OnMouseUp();
    }

    private bool WasMouseButtonPressed() {
        return Input.GetMouseButtonDown(1);
    }

    private void OnMouseDown() {
        MouseRaycast();
        if (IsElementHit()) SetHitElementIndexesAndAttachStartPivot();
    }

    private void MouseRaycast() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isHit = Physics.Raycast(ray, out hit);
    }

    // Should be used always after MouseRaycast 
    public bool IsElementHit() {
        return isHit && hit.transform.GetComponent<CubeElement>() != null;
    }

    private void SetHitElementIndexesAndAttachStartPivot() {
        SetHitElementIndexes();
        AttachStartPivot();
    }

    private void SetHitElementIndexes() {
        CubeElement hitElement = hit.transform.GetComponent<CubeElement>();
        App.model.cube.SelectedCubeElementIndexes = App.view.cube.IndexesOf(hitElement);
    }

    private void AttachStartPivot() {
        App.model.tools.LineStartPivot = new Pivot() {
            Position = hit.point,
            PlaneNormal = hit.normal,
            IsAttached = true
        };
    }

    private bool IsMousePressed() {
        return Input.GetMouseButton(1);
    }

    private void OnMousePressed() {
        if (App.model.tools.LineStartPivot.IsAttached) {
            MouseRaycast();
            if (IsElementHit() && IsSamePlane()) AttachEndPivotAndDrawLine();
            else DetachEndPivotAndDrawLine();
        }
    }

    private bool IsSamePlane() {
        return hit.normal == App.model.tools.LineStartPivot.PlaneNormal;
    }

    private void AttachEndPivotAndDrawLine() {
        AttachEndPivot();
        DrawLine();
    }

    private void AttachEndPivot() {
        App.model.tools.LineEndPivot = new Pivot() {
            Position = hit.point,
            PlaneNormal = hit.normal,
            IsAttached = true
        };
    }

    private void DrawLine() {
        App.view.tools.DrawLine();
    }

    private void DetachEndPivotAndDrawLine() {
        DetachEndPivot();
        HideLine();
    }

    private void DetachEndPivot() {
        App.model.tools.LineEndPivot.Detach();
    }

    private void HideLine() {
        App.view.tools.HideLine();
    }

    private bool WasMouseButtonReleased() {
        return Input.GetMouseButtonUp(1);
    }

    private void OnMouseUp() {
        UnsetHitElementIndexes();
        DetachEndPivot();
        DetachEndPivot();
        HideLine();
    }

    private void UnsetHitElementIndexes() {
        App.model.cube.SelectedCubeElementIndexes = Vector3Int.one * -1;
    }

    private void DetachStartPivot() {
        App.model.tools.LineStartPivot.Detach();
    }
}