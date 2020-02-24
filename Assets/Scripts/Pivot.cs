using UnityEngine;
public struct Pivot {
    public Vector3 Position {
        get;
        set;
    }

    public bool IsAttached {
        get;
        set;
    }

    public Pivot(Vector3 position = new Vector3(), bool isAttached = false) {
        Position = position;
        IsAttached = isAttached;
    }

    public void Attach() {
        IsAttached = true;
    }

    public void Detach() {
        IsAttached = false;
    }

    public void SetPosition(Vector3 position) {
        Position = position;
    }

}