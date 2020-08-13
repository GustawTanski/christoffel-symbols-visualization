using System;
public class ToolsToggledArgs : EventArgs {
    public bool isActive;

    public ToolsToggledArgs(bool isActive) {
        this.isActive = isActive;
    }
}