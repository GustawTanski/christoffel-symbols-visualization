using System;

public class ChristoffelEvent<T> where T : EventArgs {
    public event EventHandler<T> listOfHandlers;
        public void DispatchEvent(object sender, T eventArgs) {
        listOfHandlers?.Invoke(sender, eventArgs);
    }
}

