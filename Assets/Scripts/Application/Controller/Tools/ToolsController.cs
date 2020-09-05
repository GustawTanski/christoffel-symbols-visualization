using UnityEngine;
public class ToolsController : ChristoffelElement {
    public LineController line;
    public SymbolController symbol;

    public ToolsView View => App.view.tools;
    public ToolsModel Model => App.model.tools;

    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.spaceVisualizedByCubeChanged.listOfHandlers += OnSpaceVisualizedByCubeChanged;
    }

    private void OnSpaceVisualizedByCubeChanged(object caller, SpaceChangedArgs e) {
        View.spacetimeName.text = e.tensorProperties.Name;
    }
    private void Start() {
        InitializeVisibility();
        InitializeZerosToggle();
        InitializeCubesToggle();
        InitializeIndexesToggle();
        InitializeResetButton();
        InitializeLabelSlider();
        InitializeSecondNavigationKeys();
    }

    private void InitializeVisibility() {
        SynchronizeVisibilityWithState();
    }

    private void InitializeZerosToggle() {
        SetZerosToggleState();
        SetZerosToggleListener();
    }

    private void SetZerosToggleState() {
        View.zerosToggle.isOn = App.model.cube.areZerosVisible;
    }

    private void SetZerosToggleListener() {
        View.zerosToggle.onValueChanged.AddListener(OnZerosToggleChanged);
    }

    private void OnZerosToggleChanged(bool _) {
        App.zerosHided.DispatchEvent(this, new ZerosHidedArgs());
    }

    private void InitializeCubesToggle() {
        View.cubesToggle.isOn = App.model.cube.areCubesVisible;
        View.cubesToggle.onValueChanged.AddListener(OnCubesToggleChanged);
    }

    private void OnCubesToggleChanged(bool isOn) {
        App.cubesToggled.DispatchEvent(this, new CubesToggledArgs(isOn));
    }

    private void InitializeIndexesToggle() {
        View.indexesToggle.isOn = App.model.cube.areIndexesVisible;
        View.indexesToggle.onValueChanged.AddListener(OnIndexesToggleChanged);
    }

    private void OnIndexesToggleChanged(bool isOn) {
        App.controller.cube.SetIndexesActive(isOn);
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
        View.labelSliderCaption.text = $"Size × {value:G2}";
    }

    private void SetInitialValueToLabelSlider() {
        View.labelSlider.value = App.model.cube.scaleFactor;
    }

    private void InitializeSecondNavigationKeys() {
        View.secondNavigationKeys.gameObject.SetActive(Model.isNavigationKeysVisible);
    }

    private void Update() {
        if (WasToolsToggleReleasedWhenMenuIsHided()) ToggleTools();
        if (WasShowNavigationKeysPressed()) SetNavigationKeysVisible(true);
        if (WasShowNavigationKeysRealesed()) SetNavigationKeysVisible(false);
    }

    private bool WasToolsToggleReleasedWhenMenuIsHided() {
        return IsMenuHided() && WasToolsToggleReleased();
    }

    private bool IsMenuHided() {
        return !App.model.menu.isMenuOn;
    }

    private bool WasToolsToggleReleased() {
        return App.model.menu.keyBindings.ActivateCamera.WasReleasedThisFrame();
    }

    private void ToggleTools() {
        ToggleActivityState();
        DispatchToolsToggledEvent();
        SynchronizeVisibilityWithState();
    }

    private void ToggleActivityState() {
        Model.IsActive = !Model.IsActive;
    }

    private void SynchronizeVisibilityWithState() {
        View.gameObject.SetActive(Model.IsActive);
    }
    private void DispatchToolsToggledEvent() {
        App.toolsToggled.DispatchEvent(this, new ToolsToggledArgs(Model.IsActive));
    }

    private bool WasShowNavigationKeysPressed() {
        return App.model.menu.keyBindings.ShowNavigationKeys.WasPressedThisFrame();
    }

    public void SetNavigationKeysVisible(bool isVisible) {
        Model.isNavigationKeysVisible = isVisible;
        View.secondNavigationKeys.gameObject.SetActive(isVisible);
    }

    private bool WasShowNavigationKeysRealesed() {
        return App.model.menu.keyBindings.ShowNavigationKeys.WasReleasedThisFrame();
    }

    public void SetIndexesToggleState(bool isOn) {
        View.indexesToggle.SetIsOnWithoutNotify(isOn);
    }

    public void SetSpacetimeLoaderActive(bool isActive) {
        View.spacetimeLoader.gameObject.SetActive(isActive);
    }
}