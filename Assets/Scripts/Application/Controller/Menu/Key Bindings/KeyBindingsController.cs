using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class KeyBindingsController : ChristoffelElement {
    public KeyBindingsView secondView;
    private KeyBindingsModel Model => App.model.menu.keyBindings;
    private KeyBindingsView View => App.view.menu.keyBindings;

    private bool isListening = false;
    private KeyBinding currentlyChangedBinding;
    private KeyControl keyToRebind;
    private List<KeyControl> specialKeys;

    private void Awake() {
        InitializeSpecialKeys();
    }

    private void InitializeSpecialKeys() {
        specialKeys = new List<KeyControl> {
            Keyboard.current.leftCtrlKey,
            Keyboard.current.leftShiftKey,
            Keyboard.current.leftAltKey,
            Keyboard.current.rightCtrlKey,
            Keyboard.current.rightShiftKey,
            Keyboard.current.rightAltKey,
            Keyboard.current.upArrowKey,
            Keyboard.current.leftArrowKey,
            Keyboard.current.rightArrowKey,
            Keyboard.current.downArrowKey,
            Keyboard.current.enterKey,
            Keyboard.current.capsLockKey,
            Keyboard.current.tabKey,
            Keyboard.current.backspaceKey,
            Keyboard.current.slashKey,
            Keyboard.current.semicolonKey,
            Keyboard.current.periodKey,
            Keyboard.current.commaKey,
            Keyboard.current.leftBracketKey,
            Keyboard.current.rightBracketKey,
            Keyboard.current.backquoteKey,
            Keyboard.current.quoteKey,
            Keyboard.current.escapeKey
        };
    }

    private void Update() {
        if (isListening) IfAnySpecialKeyWasPressedRebind();
    }

    private void IfAnySpecialKeyWasPressedRebind() {
        foreach (KeyControl key in specialKeys) {
            if (key.wasPressedThisFrame) {
                keyToRebind = key;
                RebindAndStopListening();
                break;
            }
        }
    }
    private void RebindAndStopListening() {
        Rebind();
        StopListeningAndHidePopUp();
    }

    private void Rebind() {
        ChangeBindingsKey();
        SaveNewBindingInMemory();
        UpdateRowOfCurrentBinding();
    }

    private void ChangeBindingsKey() {
        currentlyChangedBinding.SetKey(keyToRebind.name);
    }

    private void SaveNewBindingInMemory() {
        PlayerPrefs.SetString($"{Model.MEMORY_PREFIX}/{currentlyChangedBinding.CommandName}", keyToRebind.name);
    }
    private void UpdateRowOfCurrentBinding() {
        View.UpdateBinding(currentlyChangedBinding);
        secondView.UpdateBinding(currentlyChangedBinding);
    }

    private void StopListeningAndHidePopUp() {
        StopListening();
        HidePopUp();
    }

    private void StopListening() {
        Keyboard.current.onTextInput -= OnTextInput;
        isListening = false;
    }

    private void HidePopUp() {
        View.popUp.SetActive(false);
    }

    public void StartListeningForKeyAndRebind(KeyBinding binding) {
        currentlyChangedBinding = binding;
        StartListeningAndShowPopUp();
    }

    private void StartListeningAndShowPopUp() {
        StartListening();
        ShowPopUp();
    }

    private void StartListening() {
        Keyboard.current.onTextInput += OnTextInput;
        isListening = true;
    }

    private void ShowPopUp() {
        View.popUp.SetActive(true);
    }

    private void OnTextInput(char c) {
        try {
            keyToRebind = GetKeyControlFromCharacter(c);
            RebindAndStopListening();
        } catch {}
    }

    private KeyControl GetKeyControlFromCharacter(char c) {
        return Keyboard.current[c.ToString()] as KeyControl;
    }

}