using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParameterFlag = System.UInt32;
using System.Linq;

public class SpaceSelector : ChristoffelElement {

    private const ParameterFlag nullFlag = 0;
    private const ParameterFlag M = 0b1;
    private const ParameterFlag Q = 0b10;
    private const ParameterFlag a = 0b100;
    private const ParameterFlag Lambda = 0b1000;
    private const ParameterFlag n = 0b1_0000;
    private const ParameterFlag alpha = 0b10_0000;
    private const ParameterFlag H = 0b100_0000;

    private const string NOT_HANDLED = "Nothing";

    private ParameterFlag state = nullFlag;
    private string spaceType;

    public ReadOnlyCollection<string> handledSpaces;

    private readonly Dictionary<ParameterFlag, string> stateToSpaceType = new Dictionary<ParameterFlag, string> {
        [nullFlag] = "Minkowski",
        [M] = "Schwarzschild",
        [Lambda] = "de Sitter",
        [H] = "Friedman-Robertson-Walker",
        [M | Q] = "Reissner-Nordstrøm",
        [M | a] = "Kerr",
        [M | Lambda] = "Kottler",
        [M | n] = "Taub-NUT",
        [M | alpha] = "C-metric",
        [M | Q | a] = "Kerr-Newman",
        [M | Q | Lambda] = "Reissner-Nordstrøm-de Sitter",
        [M | a | Lambda] = "Kerr-de Sitter",
        [M | n | Lambda] = "Taub-NUT-de Sitter",
        [M | Q | a | Lambda] = "Kerr-Newman-de Sitter",
        [M | Q | a | Lambda | n | alpha] = "Plebański-Demiański"
    };

    private void Awake() {
        SetListeners();
        InitializeHandledSpacesArray();
    }

    private void SetListeners() {
        App.parameterSelectionButtonPressed.listOfHandlers += OnSpaceSelectionButtonPressed;
    }

    private void InitializeHandledSpacesArray() {
        handledSpaces = Array.AsReadOnly(stateToSpaceType.Values.ToArray());
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
        if (IsStateHandled()) return GetSpaceTypeCorrespondingWithState();
        else return NOT_HANDLED;
    }

    private bool IsStateHandled() {
        return stateToSpaceType.ContainsKey(state);
    }

    private string GetSpaceTypeCorrespondingWithState() {
        return stateToSpaceType[state];
    }

    private void IfStateChangedAndHandledChangeSpaceTypeOfCube() {
        if (DidStateChanged()) ChangeSpaceTypeOfCubeOrShowWarning();
    }

    private bool DidStateChanged() {
        return spaceType != App.model.cube.spaceType;
    }

    private void ChangeSpaceTypeOfCubeOrShowWarning() {
        if (IsCombinationHandled()) {
            HideNotHandledCombinationWarning();
            ChangeSpaceTypeOfCube();
        } else ShowNotHandledCombinationWarning();
    }

    private bool IsCombinationHandled() {
        return spaceType != NOT_HANDLED;
    }

    private void ChangeSpaceTypeOfCube() {
        App.controller.cube.SetSpaceType(spaceType);
    }

    private void HideNotHandledCombinationWarning() {
        App.view.menu.metricSelection.warning.SetActive(false);
    }

    private void ShowNotHandledCombinationWarning() {
        App.view.menu.metricSelection.warning.SetActive(true);
    }

    private void Start() {
        InitializeState();
    }

    private void InitializeState() {
        ParametersPanelModel panelModel = App.model.menu.metricSelection.parametersPanel;
        if (panelModel.M) state |= M;
        if (panelModel.Q) state |= Q;
        if (panelModel.a) state |= a;
        if (panelModel.Lambda) state |= Lambda;
        if (panelModel.n) state |= n;
    }
}