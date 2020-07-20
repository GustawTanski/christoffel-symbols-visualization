using UnityEngine;
public class ToolsMenuModel : ChristofellElement {
    public Pivot LineStartPivot {
        get;
        set;
    } = new Pivot();
    public Pivot LineEndPivot {
        get;
        set;
    } = new Pivot();

    public Vector3 LineDifferenceVector {
        get {
            if (LineEndPivot.IsAttached && LineStartPivot.IsAttached)
                return LineEndPivot.Position - LineStartPivot.Position;
            else return Vector3.zero;
        }
    }

}