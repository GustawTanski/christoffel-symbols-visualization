using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
public class KeyBindingsModel : ChristofellElement {

    public InputAction moveAction;
    public KeyBinding MenuToggle { get; private set; } 
    public KeyBinding Accelerate { get; private set; } 
    public KeyBinding Decelerate { get; private set; } 
    public KeyBinding IndexToggle { get; private set; } 
    public KeyBinding Up { get; private set; } 
    public KeyBinding Down { get; private set; } 
    public KeyBindingWithAction Forward { get; private set; }
    public KeyBindingWithAction Backward { get; private set; }
    public KeyBindingWithAction Left { get; private set; }
    public KeyBindingWithAction Right { get; private set; }
    public List<KeyBinding> KeyBindings { get; private set; }

    private Dictionary<string, string> defaultKeyBindings = new Dictionary<string, string> {
        ["Menu Toggle"] = "escape",
        ["Accelerate"] = "leftShift",
        ["Decelerate"] = "leftCtrl",
        ["Index Toggle"] = "tab",
        ["Up"] = "q",
        ["Down"] = "e",
        ["Forward"] = "w",
        ["Backward"] = "s",
        ["Left"] = "a",
        ["Right"] = "d"
    };

    private void Awake() {
        InitializeKeyBindings();
        InitializeMoveAction();
        InitializeKeyBindingsList();
    }

    private void InitializeKeyBindings() {
        MenuToggle = GetInitialKeyBinding("Menu Toggle");
        Accelerate = GetInitialKeyBinding("Accelerate");
        Decelerate = GetInitialKeyBinding("Decelerate");
        IndexToggle = GetInitialKeyBinding("Index Toggle");
        Up = GetInitialKeyBinding("Up");
        Down = GetInitialKeyBinding("Down");
    }

    private KeyBinding GetInitialKeyBinding(string commandName) {
        string key = GetKeyFromMemoryOrDefault(commandName);
        return new KeyBinding(key, commandName);
    }

    private string GetKeyFromMemoryOrDefault(string commandName) {
        if (PlayerPrefs.HasKey(commandName)) return PlayerPrefs.GetString(commandName);
        else return defaultKeyBindings[commandName];
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