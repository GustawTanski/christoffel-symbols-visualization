using System.Collections.Generic;
using System.Linq;
public class MetricSelectionController : ChristofellElement {
    public ParametersPanelController parametersPanel;
    private MetricSelectionView View => App.view.menu.metricSelection;

    private void Start() {
        InitializeDropdown();
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }
    private void PopulateDropdown() {
        List<string> names = App.model.cube.SpaceDictionaryNew.Keys
            .Where(IsNotHandledBySpaceSelector)
            .ToList();
        View.dropdown.AddOptions(names);
    }

    private void SetDropdownState() {
        View.dropdown.value = 0;
        OnSpaceDropdownChanged(View.dropdown.value);
    }

    private void OnSpaceDropdownChanged(int value) {
        string spaceType = View.dropdown.options[value].text;
        App.controller.cube.SetSpaceType(spaceType);
    }

    private bool IsNotHandledBySpaceSelector(string spaceType) {
        return !App.controller.cube.spaceSelector.handledSpaces.Contains(spaceType);
    }

    private void SetDropdownListener() {
        View.dropdown.onValueChanged.AddListener(OnSpaceDropdownChanged);
    }
}