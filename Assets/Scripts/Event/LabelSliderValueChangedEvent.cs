using System;
public class LabelSliderValueChangedArgs : EventArgs {
    public float value;

    public LabelSliderValueChangedArgs(float value) {
        this.value = value;
    }
}