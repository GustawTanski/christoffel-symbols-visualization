using System;
using Data;

public class CubeRotationStartedEventArgs : EventArgs {
    public Dimension axis;
    public float angle;

    public CubeRotationStartedEventArgs(Dimension axis, float angle) {
        this.axis = axis;
        this.angle = angle;
    }
}