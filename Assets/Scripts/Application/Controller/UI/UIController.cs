using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class UIController : ChristofellElement {
    public LineController line;

    public UIView View => App.view.uI;

    private void Awake() {
        App.cursorStateChanged.listOfHandlers += OnCursorStateChanged;
    }

    private void OnCursorStateChanged(object caller, CursorStateChangedEventArgs e) {
        View.SetCanvasActivity(e.isCursorActive);
    }

    private void Start() {
        InitializeToggle();
        InitializeDropdown();
        InitializeResetButton();
    }

    private void InitializeToggle() {
        SetZerosToggleState();
        SetZerosToggleListener();
    }

    private void SetZerosToggleState() {
        App.view.uI.zerosToggle.isOn = App.model.cube.areZerosVisible;
    }

    private void SetZerosToggleListener() {
        App.view.uI.zerosToggle.onValueChanged.AddListener(OnZerosToggleChange);
    }

    private void OnZerosToggleChange(bool _) {
        App.zerosHided.DispatchEvent(this, new ZerosHidedArgs());
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }

    private void SetDropdownState() {
        App.view.uI.dropdown.value = 0;
        OnSpaceDropdownChanged(App.view.uI.dropdown.value);
    }

    private void PopulateDropdown() {
        List<string> names = App.model.cube.SpaceDictionaryNew.Keys.ToList();
        App.view.uI.dropdown.AddOptions(names);
    }

    private void SetDropdownListener() {
        App.view.uI.dropdown.onValueChanged.AddListener(OnSpaceDropdownChanged);
    }

    private void OnSpaceDropdownChanged(int value) {
        SpaceDropdownChangedArgs e = new SpaceDropdownChangedArgs(View.dropdown.options[value].text);
        App.spaceDropdownChanged.DispatchEvent(App.view.uI.dropdown, e);
    }

    private void InitializeResetButton() {
        App.view.uI.resetButton.onClick.AddListener(OnResetButtonPressed);
    }

    public void OnResetButtonPressed() {
        ResetButtonClickedArgs e = new ResetButtonClickedArgs();
        App.resetButtonClicked.DispatchEvent(App.view.uI.resetButton, e);
    }

}