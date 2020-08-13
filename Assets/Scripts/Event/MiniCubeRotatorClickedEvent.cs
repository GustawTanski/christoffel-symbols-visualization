using System;
using Data;

public class MiniCubeRotatorClickedArgs : EventArgs {
    public Dimension axis;
    public float angle;

    public MiniCubeRotatorClickedArgs(Dimension axis, float angle) {
        this.axis = axis;
        this.angle = angle;
    }
}