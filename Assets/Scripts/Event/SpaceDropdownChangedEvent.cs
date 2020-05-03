using System;
using Data;
public class SpaceDropdownChangedArgs : EventArgs {
    public SpaceType space;
    public SpaceDropdownChangedArgs(SpaceType space) {
        this.space = space;
    }
}