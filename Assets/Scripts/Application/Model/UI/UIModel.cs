using UnityEngine;
public class UIModel : ChristofellElement {
    public Pivot LineStartPivot {
        get;
        set;
    }
    public Pivot LineEndPivot {
        get;
        set;
    }

    public Vector3 LineDifferenceVector {
        get {
            return LineEndPivot.Position - LineStartPivot.Position;
        }
    }

}