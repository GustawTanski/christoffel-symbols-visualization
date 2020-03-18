using System;
using Data;
public class SpaceChangedArgs : EventArgs {
    public SpaceType space;
    public SpaceChangedArgs(SpaceType space) {
        this.space = space;
    }
}