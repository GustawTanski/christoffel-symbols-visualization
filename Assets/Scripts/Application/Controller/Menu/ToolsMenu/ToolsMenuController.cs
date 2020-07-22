using System.Collections.Generic;
using System.Linq;

public class ToolsMenuController : ChristofellElement {
    public LineController line;
    public SelectionCrossController selectionCross;

    public ToolsMenuView View => App.view.menu.toolsMenu;

    private void Start() {
        InitializeToggle();
        InitializeDropdown();
        InitializeResetButton();
        InitializeLabelSlider();
    }

    private void InitializeToggle() {
        SetZerosToggleState();
        SetZerosToggleListener();
    }

    private void SetZerosToggleState() {
        View.zerosToggle.isOn = App.model.cube.areZerosVisible;
    }

    private void SetZerosToggleListener() {
        View.zerosToggle.onValueChanged.AddListener(OnZerosToggleChange);
    }

    private void OnZerosToggleChange(bool _) {
        App.zerosHided.DispatchEvent(this, new ZerosHidedArgs());
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }

    private void SetDropdownState() {
        View.dropdown.value = 0;
        OnSpaceDropdownChanged(View.dropdown.value);
    }

    private void PopulateDropdown() {
        List<string> names = App.model.cube.SpaceDictionaryNew.Keys
            .Where(name => !App.controller.cube.spaceSelector.handledSpaces.Contains(name))
            .ToList();
        View.dropdown.AddOptions(names);
    }

    private void SetDropdownListener() {
        View.dropdown.onValueChanged.AddListener(OnSpaceDropdownChanged);
    }

    private void OnSpaceDropdownChanged(int value) {
        string spaceType = View.dropdown.options[value].text;
        App.controller.cube.SetSpaceType(spaceType);
    }

    private void InitializeResetButton() {
        View.resetButton.onClick.AddListener(OnResetButtonPressed);
    }

    private void OnResetButtonPressed() {
        ResetButtonClickedArgs e = new ResetButtonClickedArgs();
        App.resetButtonClicked.DispatchEvent(View.resetButton, e);
    }

    private void InitializeLabelSlider() {
        AddLabelSliderListener();
        SetInitialValueToLabelSlider();
    }
    private void AddLabelSliderListener() {
        View.labelSlider.onValueChanged.AddListener(OnLabelSliderValueChanged);
    }

    private void OnLabelSliderValueChanged(float value) {
        DispatchLabelSliderValueChangedEvent(value);
        UpdateLabelSliderCaption(value);
    }

    private void DispatchLabelSliderValueChangedEvent(float value) {
        App.labelSliderValueChanged.DispatchEvent(View.labelSlider, new LabelSliderValueChangedArgs(value));
    }

    private void UpdateLabelSliderCaption(float value) {
        View.labelSliderCaption.text = $"Labels × {value:G2}";
    }

    private void SetInitialValueToLabelSlider() {
        View.labelSlider.value = App.model.cube.scaleFactor;
    }

}