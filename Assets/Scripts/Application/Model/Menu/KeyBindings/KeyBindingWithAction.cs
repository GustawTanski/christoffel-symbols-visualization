using UnityEngine.InputSystem;
public class KeyBindingWithAction : KeyBinding {

    private InputAction action;
    private int index;

    public KeyBindingWithAction(string key, InputAction action, int index) : this(key, "", action, index) {}
    public KeyBindingWithAction(char key, InputAction action, int index) : this(key, "", action, index) {}

    public KeyBindingWithAction(
        string key,
        string commandName,
        InputAction action,
        int index
    ) : base(key, commandName) {
        this.action = action;
        this.index = index;
        ChangeActionBinding(key);
    }
    public KeyBindingWithAction(
        char key,
        string commandName,
        InputAction action,
        int index
    ) : this(key.ToString(), commandName, action, index) {}

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
}