using System.Collections.Generic;
using UnityEngine.InputSystem;
public class KeyBindingsModel : ChristofellElement {

    public InputAction moveAction;

    public KeyBinding MenuToggle { get; } = new KeyBinding("escape", "Menu Toggle");
    public KeyBinding Accelerate { get; } = new KeyBinding("leftShift", "Accelerate");
    public KeyBinding Decelerate { get; } = new KeyBinding("leftCtrl", "Decelerate");
    public KeyBinding IndexToggle { get; } = new KeyBinding("tab", "Index Toggle");
    public KeyBinding Up { get; } = new KeyBinding("q", "Up");
    public KeyBinding Down { get; } = new KeyBinding("e", "Down");
    public KeyBindingWithAction Forward { get; private set; }
    public KeyBindingWithAction Backward { get; private set; }
    public KeyBindingWithAction Left { get; private set; }
    public KeyBindingWithAction Right { get; private set; }
    public List<KeyBinding> KeyBindings { get; private set; }

    private void Awake() {
        InitializeMoveAction();
        InitializeKeyBindingsList();
    }

    private void InitializeMoveAction() {
        Forward = new KeyBindingWithAction("w", "Forward", moveAction, 1);
        Backward = new KeyBindingWithAction("s", "Backward", moveAction, 2);
        Left = new KeyBindingWithAction("a", "Left", moveAction, 3);
        Right = new KeyBindingWithAction("d", "Right", moveAction, 4);
    }

    private void InitializeKeyBindingsList() {
        KeyBindings = new List<KeyBinding> {
            MenuToggle,
            Accelerate,
            Decelerate,
            IndexToggle,
            Up,
            Down,
            Forward,
            Backward,
            Left,
            Right
        };
    }

    private void OnEnable() {
        moveAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
    }
};