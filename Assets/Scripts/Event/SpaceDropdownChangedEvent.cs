using System;
using Data;
public class SpaceDropdownChangedArgs : EventArgs {
    public string spaceType;
    public SpaceDropdownChangedArgs(string spaceType) {
        this.spaceType = spaceType;
    }
}