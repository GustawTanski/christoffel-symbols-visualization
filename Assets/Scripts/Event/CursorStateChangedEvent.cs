using System;

public class CursorStateChangedEventArgs : EventArgs {

    public bool isCursorActive;

    public CursorStateChangedEventArgs(bool isActive) {
        this.isCursorActive = isActive;
    }
}