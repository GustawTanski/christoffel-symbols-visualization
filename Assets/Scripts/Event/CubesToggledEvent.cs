using System;

public class CubesToggledArgs: EventArgs {
    public bool areOn;

    public CubesToggledArgs(bool areOn) {
        this.areOn = areOn;
    }
} 