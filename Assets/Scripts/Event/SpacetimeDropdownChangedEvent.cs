using System;
public class SpacetimeDropdownChangedArgs : EventArgs {
    public string spaceType;

    public SpacetimeDropdownChangedArgs(string spaceType) {
        this.spaceType = spaceType;
    }
}