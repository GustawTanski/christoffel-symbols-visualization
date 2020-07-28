using System.Collections.Generic;
using System.Linq;

public class MetricSelectionController : ChristoffelElement {
    public ParametersPanelController parametersPanel;
    private MetricSelectionView View => App.view.menu.metricSelection;


    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.spaceDataChanged.listOfHandlers += OnSpaceDataChanged;
    }

    private void OnSpaceDataChanged(object caller, SpaceChangedArgs e) {
        View.spacetimeName.text = e.tensorProperties.Name;
        View.UpdateParameters(e.tensorProperties.Parameters);
    }

    private void Start() {
        InitializeDropdown();
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        InitializeDropdownState();
        SetDropdownListener();
    }
    private void PopulateDropdown() {
        List<string> names = App.model.cube.SpaceDictionaryNew.Keys
            .Where(IsNotHandledBySpaceSelector)
            .ToList();
        View.dropdown.AddOptions(names);
    }

    private bool IsNotHandledBySpaceSelector(string spaceType) {
        return !App.controller.cube.spaceSelector.handledSpaces.Contains(spaceType);
    }

    private void InitializeDropdownState() {
        View.dropdown.SetValueWithoutNotify(0);
    }

    private void SetDropdownListener() {
        View.dropdown.onValueChanged.AddListener(OnSpaceDropdownChanged);
    }
    private void OnSpaceDropdownChanged(int value) {
        string spaceType = View.dropdown.options[value].text;
        App.controller.cube.SetSpaceType(spaceType);
    }
}