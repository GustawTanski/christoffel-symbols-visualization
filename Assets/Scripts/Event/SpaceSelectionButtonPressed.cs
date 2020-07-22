using System;
public enum SpaceParameter {
    M,
    Q,
    a,
    Lambda,
    n
}

public class SpaceSelectionButtonPressedArgs : EventArgs {
    public bool isOn;
    public SpaceParameter parameter;

    public SpaceSelectionButtonPressedArgs(bool isOn, SpaceParameter parameter) {
        this.isOn = isOn;
        this.parameter = parameter;
    }
}