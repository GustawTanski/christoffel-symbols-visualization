using System.Collections.Generic;
public class KeyBindingsModel : ChristofellElement {

    public KeyBinding MenuToggle { get; } = new KeyBinding("escape", "Menu Toggle");
    public KeyBinding Accelerate { get; } = new KeyBinding("leftShift", "Accelerate");
    public KeyBinding Decelerate { get; } = new KeyBinding("leftCtrl", "Decelerate");
    public KeyBinding IndexToggle { get; } = new KeyBinding("tab", "Index Toggle");
    public KeyBinding Up { get; } = new KeyBinding("q", "Up");
    public KeyBinding Down { get; } = new KeyBinding("e", "Down");
    public List<KeyBinding> KeyBindings { get; private set; }

    private void Awake() {
        KeyBindings = new List<KeyBinding> { MenuToggle, Accelerate, Decelerate, IndexToggle, Up, Down };
    }
};