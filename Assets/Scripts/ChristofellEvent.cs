using System;
using System.Collections.Generic;
public sealed class ChristofellEvent : BaseChristofellEvent<Action> {
    public override Action DispatchEvent {
        get {
            return () => {
                listeners.ForEach(listener => listener());
            };
        }
    }
}

public sealed class ChristofellEvent<T> : BaseChristofellEvent<Action<T>> {
    public override Action<T> DispatchEvent {
        get {
            return (T arg) => {
                listeners.ForEach(listener => listener(arg));
            };
        }
    }
}

public sealed class ChristofellEvent<T1, T2> : BaseChristofellEvent<Action<T1, T2>> {
    public override Action<T1, T2> DispatchEvent {
        get {
            return (T1 arg1, T2 arg2) => {
                listeners.ForEach(listener => listener(arg1, arg2));
            };
        }
    }
}

public abstract class BaseChristofellEvent<T> where T : Delegate {
    protected List<T> listeners = new List<T>();

    public void AddListener(T callback) {
        listeners.Add(callback);
    }

    public void RemoveListener(T callback) {
        listeners.Remove(callback);
    }

    abstract public T DispatchEvent { get; }
}