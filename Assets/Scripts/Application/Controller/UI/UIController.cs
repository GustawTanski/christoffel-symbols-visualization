using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class UIController : ChristofellElement, INotifiable {

    public void OnNotification(ChristofellNotification notification, object target, params object[] data) {}
    private void Start() {
        InitializeToggle();
        InitializeDropdown();
    }

    private void InitializeToggle() {
        SetZerosToggleState();
        SetZerosToggleListener();
    }

    private void SetZerosToggleState() {
        App.view.UI.zerosToggle.isOn = App.model.cube.areZerosVisible;
    }

    private void SetZerosToggleListener() {
        App.view.UI.zerosToggle.onValueChanged.AddListener(OnZerosToggleChange);
    }

    private void OnZerosToggleChange(bool _) {
        App.Notify(ChristofellNotification.ZeroHided, App.view.UI.zerosToggle);
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }

    private void SetDropdownState() {
        App.view.UI.dropdown.value = (int) App.model.cube.space;
    }

    private void PopulateDropdown() {
        List<string> names = Enum.GetNames(typeof(SpaceType)).ToList();
        App.view.UI.dropdown.AddOptions(names);
    }

    private void SetDropdownListener() {
        App.view.UI.dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void OnDropdownChanged(int value) {
        App.Notify(ChristofellNotification.SpaceTypeChanged, App.view.UI.dropdown, (SpaceType)value);
    }
}