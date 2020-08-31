using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using ParameterFlag = System.UInt32;
using System.Linq;

public class SpaceSelector : ChristoffelElement {

    private const ParameterFlag nullFlag = 0;
    private const ParameterFlag M = 0b1;
    private const ParameterFlag Q = 0b10;
    private const ParameterFlag a = 0b100;
    private const ParameterFlag Lambda = 0b1000;
    private const ParameterFlag n = 0b1_0000;
    private const ParameterFlag H = 0b10_0000;

    private const string NOT_HANDLED = "Nothing";

    private ParameterFlag state = nullFlag;
    private string spaceType;

    private List<SpaceParameter> pressedParameters;

    private readonly Dictionary<ParameterFlag, string> stateToSpaceType = new Dictionary<ParameterFlag, string> {
        [nullFlag] = "Minkowski",
        [M] = "Schwarzschild",
        [Lambda] = "de Sitter",
        [H] = "Friedman-Robertson-Walker",
        [M | Q] = "Reissner-Nordstrøm",
        [M | a] = "Kerr",
        [M | Lambda] = "(A)dS-Schwarzschild",
        [M | n] = "Taub-NUT",
        [M | Q | a] = "Kerr-Newman",
        [M | Q | Lambda] = "(A)dS-Reissner-Nordstrøm",
        [M | a | Lambda] = "(A)dS-Kerr",
        [M | n | Lambda] = "Taub-NUT-de Sitter",
        [M | Q | a | Lambda] = "Kerr-Newman-de Sitter"
    };

    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.parameterSelectionButtonPressed.listOfHandlers += OnSpaceSelectionButtonPressed;
        App.spacetimeDropdownChanged.listOfHandlers += OnSpacetimeDropdownChanged;
    }

    private void OnSpaceSelectionButtonPressed(object caller, ParameterSelectionButtonPressedArgs e) {
        HideAllWarnings();
        UpdateStateAndPressedParametersFromParameters(e.isOn, e.parameter);
        this.spaceType = GetSpaceTypeFromState();
        IfSpaceTypeChangedAndHandledChangeSpaceTypeOfCube();
        ForceDropdownState();
    }

    private void HideAllWarnings() {
        HideNoCombinationWarning();
        HideNotHandledCombinationWarning();
    }

    private void HideNoCombinationWarning() {
        App.view.menu.metricSelection.noCombinationWarning.SetActive(false);
    }

    private void HideNotHandledCombinationWarning() {
        App.view.menu.metricSelection.notHandledWarning.SetActive(false);
    }

    private void UpdateStateAndPressedParametersFromParameters(bool isPressed, SpaceParameter parameter) {
        if (isPressed) AddParameter(parameter);
        else RemoveParameter(parameter);
    }

    private void AddParameter(SpaceParameter parameter) {
        AddParameterFlagToState(parameter);
        AddParameterToPressedParameters(parameter);
    }

    private void AddParameterFlagToState(SpaceParameter parameter) {
        state |= ConvertParameterToFlag(parameter);
    }

    private void AddParameterToPressedParameters(SpaceParameter parameter) {
        if (!pressedParameters.Contains(parameter)) pressedParameters.Add(parameter);
    }

    private ParameterFlag ConvertParameterToFlag(SpaceParameter parameter) {
        return (ParameterFlag) parameter;
    }

    private void RemoveParameter(SpaceParameter parameter) {
        RemoveParameterFlagFromState(parameter);
        RemoveParameterPressedParameters(parameter);
    }

    private void RemoveParameterFlagFromState(SpaceParameter parameter) {
        state &= ~ConvertParameterToFlag(parameter);
    }

    private void RemoveParameterPressedParameters(SpaceParameter parameter) {
        pressedParameters.Remove(parameter);
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

    private void IfSpaceTypeChangedAndHandledChangeSpaceTypeOfCube() {
        if (DidSpaceTypeChanged()) ChangeSpaceTypeOfCubeOrShowWarning();
    }

    private bool DidSpaceTypeChanged() {
        return spaceType != App.model.cube.spaceType;
    }

    private void ChangeSpaceTypeOfCubeOrShowWarning() {
        if (IsCombinationHandled()) ChangeSpaceTypeOfCube();
        else ShowNotHandledCombinationWarning();
    }

    private bool IsCombinationHandled() {
        return spaceType != NOT_HANDLED;
    }

    private void ChangeSpaceTypeOfCube() {
        App.controller.cube.SetSpaceType(spaceType);
    }

    private void ShowNotHandledCombinationWarning() {
        App.view.menu.metricSelection.notHandledWarning.SetActive(true);
    }

    private void ForceDropdownState() {
        App.controller.menu.metricSelection.ForceDropdownState(spaceType);
    }

    private void OnSpacetimeDropdownChanged(object caller, SpacetimeDropdownChangedArgs e) {
        HideAllWarnings();
        this.spaceType = e.spaceType;
        UpdateStateAndPressedParametersFromDropdown();
        IfSpaceTypeChangedAndHandledChangeSpaceTypeOfCube();
        ForceParametersState();
    }

    private void UpdateStateAndPressedParametersFromDropdown() {
        if (HasSpaceTypeMatchingCombinationOfParametrs())
            UpdateStateAndPressedParametersWhenSpaceTypeMathesCombination();
        else {
            ResetStateAndPressedParameters();
            ShowNoCombinationWarning();
        }
    }

    private bool HasSpaceTypeMatchingCombinationOfParametrs() {
        return stateToSpaceType.ContainsValue(spaceType);
    }

    private void UpdateStateAndPressedParametersWhenSpaceTypeMathesCombination() {
        state = GetStateCorrespondingWithSpaceType();
        pressedParameters = GetPressedParametersFromState();
    }

    private ParameterFlag GetStateCorrespondingWithSpaceType() {
        return stateToSpaceType.KeyByValue(spaceType);
    }

    private List<SpaceParameter> GetPressedParametersFromState() {
        return new [] { M, Q, a, Lambda, n, H }
            .Where(IsFlagInState)
            .Select(CastToSpaceParameter)
            .ToList();
    }

    private bool IsFlagInState(ParameterFlag flag) => (flag & state) != 0;

    private SpaceParameter CastToSpaceParameter(ParameterFlag flag) => (SpaceParameter) flag;

    private void ResetStateAndPressedParameters() {
        state = nullFlag;
        pressedParameters = new List<SpaceParameter>();
    }

    private void ShowNoCombinationWarning() {
        App.view.menu.metricSelection.noCombinationWarning.SetActive(true);
    }

    private void ForceParametersState() {
        App.controller.menu.metricSelection.parametersPanel.ForceParametersState(pressedParameters);
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
        if (panelModel.H) state |= H;
    }
}