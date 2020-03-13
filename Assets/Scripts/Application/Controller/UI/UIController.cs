using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class UIController : ChristofellElement {
    public LineController line;

    private void Start() {
        InitializeToggle();
        InitializeDropdown();
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
        App.zerosHidedEvent.DispatchEvent();
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }

    private void SetDropdownState() {
        App.view.uI.dropdown.value = (int) App.model.cube.space;
    }

    private void PopulateDropdown() {
        List<string> names = Enum.GetNames(typeof(SpaceType)).ToList();
        App.view.uI.dropdown.AddOptions(names);
    }

    private void SetDropdownListener() {
        App.view.uI.dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void OnDropdownChanged(int value) {
        App.spaceChangedEvent.DispatchEvent((SpaceType) value);
    }

}