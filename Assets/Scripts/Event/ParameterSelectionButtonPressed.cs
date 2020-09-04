using System;
public enum SpaceParameter {
    M = 0b1,
    Q = 0b10,
    a = 0b100,
    Lambda = 0b1000,
    n = 0b1_0000,
    H = 0b10_0000
}

public class ParameterSelectionButtonPressedArgs : EventArgs {
    public bool isOn;
    public SpaceParameter parameter;

    public ParameterSelectionButtonPressedArgs(bool isOn, SpaceParameter parameter) {
        this.isOn = isOn;
        this.parameter = parameter;
    }
}