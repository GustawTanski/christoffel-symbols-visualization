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
        if (IsCommandInMemory(commandName)) return GetKeyFromMemory(commandName);
        else return GetDefaultKey(commandName);
    }

    private bool IsCommandInMemory(string commandName) {
        return PlayerPrefs.HasKey(Decorate(commandName));
    }

    private string Decorate(string commandName) {
        return $"keyBinding/{commandName}";
    }

    private string GetKeyFromMemory(string commandName) {
        return PlayerPrefs.GetString(Decorate(commandName));
    }

    private string GetDefaultKey(string commandName) {
        return defaultKeyBindings[commandName];
    }

    private void InitializeMoveAction() {
        Forward = GetInitialMoveActionKeyBinding("Forward", 1);
        Backward = GetInitialMoveActionKeyBinding("Backward", 2);
        Left = GetInitialMoveActionKeyBinding("Left", 3);
        Right = GetInitialMoveActionKeyBinding("Right", 4);
    }

    private KeyBindingWithAction GetInitialMoveActionKeyBinding(string commandName, int index) {
        string key = GetKeyFromMemoryOrDefault(commandName);
        return new KeyBindingWithAction(key, commandName, moveAction, index);
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