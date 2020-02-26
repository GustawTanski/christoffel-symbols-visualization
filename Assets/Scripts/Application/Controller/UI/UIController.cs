using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

public class UIController : ChristofellElement {
    private RaycastHit hit;
    private bool isHit = false;

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
        if (WasMouseButtonPressed()) {
            Raycast();
            CubeElement dog = hit.transform.GetComponent<CubeElement>();
            if (IsElementHit()) AttachStartPivot();
        }
        if (IsMousePressed() && App.model.uI.LineStartPivot.IsAttached) {
            Raycast();
            if (IsElementHit() && IsSamePlane()) {
                AttachEndPivot();
                DrawLine();
            } else {
                App.model.uI.LineEndPivot.Detach();
                HideLine();
            }
        }
        if (WasMouseButtonReleased()) HideLine();
    }

    private void Raycast() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isHit = Physics.Raycast(ray, out hit);
    }

    private bool IsElementHit() {
        return isHit && hit.transform.GetComponent<CubeElement>() != null;
    }

    private bool IsSamePlane() {
        return hit.normal == App.model.uI.LineStartPivot.PlaneNormal;
    }

    private void AttachStartPivot() {
        App.model.uI.LineStartPivot = new Pivot(hit.point, true, hit.normal);
    }

    private void AttachEndPivot() {
        App.model.uI.LineEndPivot = new Pivot(hit.point, true, hit.normal);
    }

    private bool WasMouseButtonPressed() {
        return Input.GetMouseButtonDown(1);
    }

    private bool WasMouseButtonReleased() {
        return Input.GetMouseButtonUp(1);
    }

    private bool IsMousePressed() {
        return Input.GetMouseButton(1);
    }

    private void HideLine() {
        App.view.uI.HideLine();
    }

    private void DrawLine() {
        App.view.uI.UpdateLine();
    }
}