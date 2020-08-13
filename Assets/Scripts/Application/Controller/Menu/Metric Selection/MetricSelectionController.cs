using System.Collections.Generic;
using System.Linq;
using Data;
using TMPro;

public class MetricSelectionController : ChristoffelElement {
    public ParametersPanelController parametersPanel;
    public MetricController metric;
    private MetricSelectionView View => App.view.menu.metricSelection;

    private TensorProperties tensorProperties;

    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.spaceDataChanged.listOfHandlers += OnSpaceDataChanged;
    }

    private void OnSpaceDataChanged(object caller, SpaceChangedArgs e) {
        tensorProperties = e.tensorProperties;
        SetNewTitle();
        View.spacetimeDescription.text = e.tensorProperties.Description;
        View.UpdateParameters(e.tensorProperties.Parameters);
    }

    private void SetNewTitle() {
        if (tensorProperties.WikipediaPath.Length > 0) SetHyperlinkTitle();
        else SetNormalTitle();
    }

    private void SetHyperlinkTitle() {
        SetTitleUnderlined();
        SetHyperlinkAsTitleText();
    }

    private void SetHyperlinkAsTitleText() {
        View.spacetimeName.text = CreateHyperLink();
    }

    private void SetTitleUnderlined() {
        View.spacetimeName.fontStyle |= FontStyles.Underline;
    }

    private string CreateHyperLink() {
        return $"<link=https://en.wikipedia.org/wiki/{tensorProperties.WikipediaPath}>{tensorProperties.Name}</link>";
    }

    private void SetNormalTitle() {
        UnsetTitleUnderlined();
        View.spacetimeName.text = tensorProperties.Name;
    }

    private void UnsetTitleUnderlined() {
        View.spacetimeName.fontStyle &= ~FontStyles.Underline;
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
        List<string> names = GetNameOfSpaceTypesThatAreNotHandledBySpaceSelector();
        View.dropdown.AddOptions(names);
    }

    private List<string> GetNameOfSpaceTypesThatAreNotHandledBySpaceSelector() {
        return App.model.cube.SpaceDictionaryNew.Keys
            .Where(IsNotHandledBySpaceSelector)
            .ToList();
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