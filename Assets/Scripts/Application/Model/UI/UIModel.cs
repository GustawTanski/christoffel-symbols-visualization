using UnityEngine;
public class UIModel : ChristofellElement {
    public Vector3 LineStart {
        get;
        set;
    }
    public Vector3 LineEnd {
        get;
        set;
    }

    public Vector3 LineDifferenceVector {
        get {
            return LineEnd - LineStart;
        }
    }
}