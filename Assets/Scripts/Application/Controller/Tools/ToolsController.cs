public class ToolsController : ChristofellElement {
    public LineController line;

    public ToolsView View => App.view.tools;
    public ToolsModel Model => App.model.tools;

    private void Start() {
        InitializeVisibility();
        InitializeToggle();
        InitializeResetButton();
        InitializeLabelSlider();
    }

    private void InitializeVisibility() {
        SynchronizeVisibilityWithState();
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

    private void Update() {
        if (WasToolsToggleReleasedWhenMenuIsHided()) ToggleTools();
    }

    private bool WasToolsToggleReleasedWhenMenuIsHided() {
        return IsMenuHided() && WasToolsToggleReleased();
    }

    private bool IsMenuHided() {
        return !App.model.menu.isMenuOn;
    }

    private bool WasToolsToggleReleased() {
        return App.model.menu.keyBindings.ToolsToggle.WasReleasedThisFrame();
    }

    private void ToggleTools() {
        ToggleActivityState();
        SynchronizeVisibilityWithState();
    }

    private void ToggleActivityState() {
        Model.IsActive = !Model.IsActive;
    }

    private void SynchronizeVisibilityWithState() {
        View.gameObject.SetActive(Model.IsActive);
    }
}