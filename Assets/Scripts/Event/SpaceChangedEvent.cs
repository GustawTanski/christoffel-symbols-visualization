using System;
using Data;
public class SpaceChangedArgs : EventArgs {
    public TensorProperties tensorProperties;

    public SpaceChangedArgs(TensorProperties tensorProperties) {
        this.tensorProperties = tensorProperties;
    }
}