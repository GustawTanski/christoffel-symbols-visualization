using System;
using Data;

public class MiniCubeRotatorClickedEventArgs : EventArgs {
    public Dimension axis;
    public float angle;

    public MiniCubeRotatorClickedEventArgs(Dimension axis, float angle) {
        this.axis = axis;
        this.angle = angle;
    }
}