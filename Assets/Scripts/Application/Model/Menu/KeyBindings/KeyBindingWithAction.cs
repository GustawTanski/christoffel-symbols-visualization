using UnityEngine.InputSystem;

public class KeyBindingWithAction : KeyBinding {

    private InputAction action;
    private int index;

    public KeyBindingWithAction(string key, InputAction action, int index) : base(key) {
        this.action = action;
        this.index = index;
    }
    public KeyBindingWithAction(char key, InputAction action, int index) : base(key) {
        this.action = action;
        this.index = index;
    }

    public override void SetKey(string key) {
        ChangeActionBinding(key);
        base.SetKey(key);
    }

    private void ChangeActionBinding(string key) {
        action.ChangeBinding(index).WithPath($"<Keyboard>/{key}");
    }

    public override void SetKey(char key) {
        ChangeActionBinding(key.ToString());
        base.SetKey(key);
    }
