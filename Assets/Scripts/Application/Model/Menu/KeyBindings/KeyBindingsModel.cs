using System.Collections.Generic;
public class KeyBindingsModel : ChristofellElement {

    public KeyBinding MenuToggle { get; } = new KeyBinding("escape", "Menu Toggle");
    public KeyBinding Accelerate { get; } = new KeyBinding("leftShift", "Accelerate");
    public KeyBinding Decelerate { get; } = new KeyBinding("leftControl", "Decelerate");
    public List<KeyBinding> KeyBindings { get; private set; }

    private void Awake() {
        KeyBindings = new List<KeyBinding> { MenuToggle, Accelerate, Decelerate };
    }
};