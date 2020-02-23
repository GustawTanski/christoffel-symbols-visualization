using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

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

    private void Update() {
        UpdateLine();
    }

    private void UpdateLine() {
        if (WasMouseButtonPressed()) SetLineStart();
        if (WasMouseButtonReleased()) HideLine();
        if (IsMousePressed()) DrawLine();

    }

    private bool WasMouseButtonPressed() {
        return Input.GetMouseButtonDown(0);
    }

    private bool WasMouseButtonReleased() {
        return Input.GetMouseButtonUp(0);
    }

    private bool IsMousePressed() {
        return Input.GetMouseButton(0);
    }

    private void SetLineStart() {
        App.model.uI.LineStart = Input.mousePosition;
    }

    private void HideLine() {
        App.view.uI.HideLine();
    }

    private void DrawLine() {
        SetLineEnd();
        App.view.uI.UpdateLine();
    }

    private void SetLineEnd() {
        App.model.uI.LineEnd = Input.mousePosition;
    }
}