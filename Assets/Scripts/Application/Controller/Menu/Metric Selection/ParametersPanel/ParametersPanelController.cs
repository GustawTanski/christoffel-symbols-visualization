using System;
using UnityEngine.Events;
public class ParametersPanelController : ChristoffelElement {
    private ParametersPanelView View => App.view.menu.metricSelection.parametersPanel;
    private ParametersPanelModel Model => App.model.menu.metricSelection.parametersPanel;

    private void Awake() {
        InitializeButtons();
    }

    private void InitializeButtons() {
        InitializeButtonsStates();
        SetButtonsListeners();
    }

    private void InitializeButtonsStates() {
        View.a.isOn = Model.a;
        View.Lambda.isOn = Model.Lambda;
        View.Q.isOn = Model.Q;
        View.n.isOn = Model.n;
        View.M.isOn = Model.M;
        View.alpha.isOn = Model.alpha;
        View.H.isOn = Model.H;
    }

    private void SetButtonsListeners() {
        View.a.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.a));
        View.Lambda.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.Lambda));
        View.Q.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.Q));
        View.n.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.n));
        View.M.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.M));
        View.alpha.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.alpha));
        View.H.onValueChanged.AddListener(OnButtonChangeCreator(SpaceParameter.H));
    }

    private UnityAction<bool> OnButtonChangeCreator(SpaceParameter parameter) {
        return (bool isOn) => {
            SetParameterFlag(parameter, isOn);
            DispatchParameterSelectionButtonPressedEvent(parameter, isOn);
        };
    }

    private void SetParameterFlag(SpaceParameter parameter, bool isOn) {
        switch (parameter) {
            case SpaceParameter.a:
                Model.a = isOn;
                break;
            case SpaceParameter.Q:
                Model.Q = isOn;
                break;
            case SpaceParameter.n:
                Model.n = isOn;
                break;
            case SpaceParameter.M:
                Model.M = isOn;
                break;
            case SpaceParameter.Lambda:
                Model.Lambda = isOn;
                break;
        };
    }

    private void DispatchParameterSelectionButtonPressedEvent(SpaceParameter parameter, bool isOn) {
        ParameterSelectionButtonPressedArgs e = new ParameterSelectionButtonPressedArgs(isOn, parameter);
        App.parameterSelectionButtonPressed.DispatchEvent(View, e);
    }
}