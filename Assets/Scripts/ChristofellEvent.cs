using System;
using System.Collections.Generic;

public class ChristofellEvent<T> where T : EventArgs {
    public event EventHandler<T> listOfHandlers;
    public void DispatchEvent(object sender, T eventArgs) {
        listOfHandlers?.Invoke(sender, eventArgs);
    }
}

