using UnityEngine;
public class Pivot {
    public Vector3 Position {
        get;
        set;
    }

    public bool IsAttached {
        get;
        set;
    }

    public Vector3 PlaneNormal {
        get;
        set;
    }

    public void Attach() {
        IsAttached = true;
    }

    public void Detach() {
        IsAttached = false;
    }

}