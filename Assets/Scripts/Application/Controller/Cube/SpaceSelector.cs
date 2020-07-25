using System;
using System.Collections.Generic;
using ParameterFlag = System.UInt32;
using System.Linq;

public class SpaceSelector : ChristofellElement {

    private const ParameterFlag nullFlag = 0;
    private const ParameterFlag M = 0b1;
    private const ParameterFlag Q = 0b10;
    private const ParameterFlag a = 0b100;
    private const ParameterFlag Lambda = 0b1000;
    private const ParameterFlag n = 0b1_0000;

    private const string NOT_HANDLED = "Nothing";

    private ParameterFlag state = nullFlag;
    private string spaceType;

    public readonly string[] handledSpaces = new [] {
        "Minkowski",
        "Schwarzschild",
        "de Sitter",
        "Kerr",
        "Reissner-Nordstrøm",
        "Taub-NUT",
        "Kerr-Newman",
        "Kottler",
        "Reissner-Nordstrøm-de Sitter",
        "Kerr-de Sitter",
        "Taub-NUT-de Sitter",
        "Kerr-Newman-de Sitter"
    };

    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.parameterSelectionButtonPressed.listOfHandlers += OnSpaceSelectionButtonPressed;
    }

    private void OnSpaceSelectionButtonPressed(object caller, ParameterSelectionButtonPressedArgs e) {
        UpdateState(e.isOn, e.parameter);
        UpdateSpaceType();
    }

    private void UpdateState(bool flag, SpaceParameter parameter) {
        if (flag) AddParameterFlagToState(parameter);
        else RemoveParameterFlagFromState(parameter);
    }

    private void AddParameterFlagToState(SpaceParameter parameter) {
        state |= ConvertParameterToFlag(parameter);
    }

    private ParameterFlag ConvertParameterToFlag(SpaceParameter parameter) {
        return (ParameterFlag) parameter;
    }

    private void RemoveParameterFlagFromState(SpaceParameter parameter) {
        state &= ~ConvertParameterToFlag(parameter);
    }

    private void UpdateSpaceType() {
        spaceType = GetSpaceTypeFromState();
        IfStateChangedAndHandledChangeSpaceTypeOfCube();
    }

    private string GetSpaceTypeFromState() {
        switch (state) {
            case nullFlag:
                return "Minkowski";
            case M:
                return "Schwarzschild";
            case Lambda:
                return "de Sitter";
            case M | Lambda:
                return "Kottler";
            case M | n:
                return "Taub-NUT";
            case M | Q:
                return "Reissner-Nordstrøm";
            case M | a:
                return "Kerr";
            case M | Q | a:
                return "Kerr-Newman";
            case M | Q | Lambda:
                return "Reissner-Nordstrøm-de Sitter";
            case M | a | Lambda:
                return "Kerr-de Sitter";
            case M | n | Lambda:
                return "Taub-NUT-de Sitter";
            case M | Q | a | Lambda:
                return "Kerr-Newman-de Sitter";
            default:
                return NOT_HANDLED;
        };
    }

    private void IfStateChangedAndHandledChangeSpaceTypeOfCube() {
        if (DidStateChanged()) ChangeSpaceTypeOfCubeOrShowWarning();
    }

    private bool DidStateChanged() {
        return spaceType != App.model.cube.spaceType;
    }

    private void ChangeSpaceTypeOfCubeOrShowWarning() {
        if (IsStateHandled()) {
            HideNotHandledCombinationWarning();
            ChangeSpaceTypeOfCube();
        } else ShowNotHandledCombinationWarning();
    }

    private bool IsStateHandled() {
        return spaceType != NOT_HANDLED;
    }

    private void ChangeSpaceTypeOfCube() {
        App.controller.cube.SetSpaceType(spaceType);
    }

    private void HideNotHandledCombinationWarning() {
        App.view.menu.toolsMenu.warning.SetActive(false);
    }

    private void ShowNotHandledCombinationWarning() {
        App.view.menu.toolsMenu.warning.SetActive(true);
    }

    private void Start() {
        InitializeState();
    }

    private void InitializeState() {
        SelectionCrossModel crossModel = App.model.menu.toolsMenu.selectionCross;
        if (crossModel.M) state |= M;
        if (crossModel.Q) state |= Q;
        if (crossModel.a) state |= a;
        if (crossModel.Lambda) state |= Lambda;
        if (crossModel.n) state |= n;
    }
}