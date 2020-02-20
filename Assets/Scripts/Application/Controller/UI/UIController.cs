using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class UIController : ChristofellElement {
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
        App.view.UI.zerosToggle.onValueChanged.AddListener((_) => App.controller.cube.OnZeroToggleClicked());
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
        App.view.UI.dropdown.onValueChanged.AddListener(App.controller.cube.OnSpaceValueChanged);
    }
}