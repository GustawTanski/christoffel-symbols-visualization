using System;
using System.Threading.Tasks;

public class CubeController : ChristoffelElement {
    public CubePlaneSlicer cubePlaneSlicer;
    public SpaceSelector spaceSelector;
    private CubeModel Model => App.model.cube;
    private CubeView View => App.view.cube;

    private void Awake() {
        SetEventListeners();
        SetZerosVisibility();
    }

    private void SetEventListeners() {
        App.zerosHided.listOfHandlers += OnZerosHided;
        App.labelSliderValueChanged.listOfHandlers += OnLabelSliderValueChanged;
        App.cubesToggled.listOfHandlers += OnCubesToggled;
    }

    private void OnZerosHided(object sender, EventArgs e) {
        ToggleZerosVisibilityState();
        ToggleZerosVisibility();
    }

    private void ToggleZerosVisibilityState() {
        Model.areZerosVisible = !Model.areZerosVisible;
    }

    private void ToggleZerosVisibility() {
        View.ToggleZeros();
    }

    private void OnLabelSliderValueChanged(object caller, LabelSliderValueChangedArgs e) {
        Model.scaleFactor = e.value;
        View.ScaleLabelsTo(e.value);
    }

    private void OnCubesToggled(object caller, CubesToggledArgs e) {
        SetCubesVisibilityState(e.areOn);
        SetCubesVisibility(e.areOn);
    }

    private void SetCubesVisibilityState(bool areOn) {
        Model.areCubesVisible = areOn;
    }

    private void SetCubesVisibility(bool areOn) {
        View.SetCubesVisibility(areOn);
    }

    private void Update() {
        IfIndexToggleKeyIsUpToggleIndexes();
        //! Commented out due to none functionality and probably lowering efficiency.
        //TODO fix it and check it  
        // UpdateSelectionOfElements();
    }

    private void IfIndexToggleKeyIsUpToggleIndexes() {
        if (IsIndexToggleKeyUp()) ToggleIndexes();
    }

    private bool IsIndexToggleKeyUp() {
        return App.model.menu.keyBindings.IndexToggle.WasReleasedThisFrame();
    }

    private void ToggleIndexes() {
        View.ToggleIndexes();
        Model.areIndexesVisible = !Model.areIndexesVisible;
        App.controller.tools.SetIndexesToggleState(Model.areIndexesVisible);
    }

    private void UpdateSelectionOfElements() {
        View.DeselectAllElements();
        SelectElementsPresentInSelectedPlanes();
    }

    private void SelectElementsPresentInSelectedPlanes() {
        foreach (CubeElement[, ] plane in cubePlaneSlicer.SelectedPlanes)
            SelectAllElementsOfPlane(plane);
    }

    private void SelectAllElementsOfPlane(CubeElement[, ] plane) {
        foreach (CubeElement element in plane) element.ShowCube();
    }

    public void SetSpaceType(string spaceType) {
        SetSpaceState(spaceType);
        Model.UpdateModel();
        DispatchSpaceDataChangedEvent();
    }

    private void SetSpaceState(string spaceType) {
        Model.spaceType = spaceType;
    }

    private void DispatchSpaceDataChangedEvent() {
        App.spaceDataChanged.DispatchEvent(this, new SpaceChangedArgs(Model.Properties));
    }

    private void Start() {
        InitializeCube();
    }

    private void InitializeCube() {
        SetIndexesActive(Model.areIndexesVisible);
        UpdateCube();
    }

    public void SetIndexesActive(bool areActive) {
        View.SetIndexesActive(areActive);
        Model.areIndexesVisible = areActive;
    }

    public async void UpdateCube() {
        DispatchSpaceVisualizedByCubeChangedEvent();
        App.controller.tools.SetSpacetimeLoaderActive(true);
        await UpdateTextures();
        App.controller.tools.SetSpacetimeLoaderActive(false);
    }

    private void DispatchSpaceVisualizedByCubeChangedEvent() {
        App.spaceVisualizedByCubeChanged.DispatchEvent(this, new SpaceChangedArgs(Model.Properties));
    }

    private async Task UpdateTextures() {
        await FetchTextures();
        SetTextures();
        IfInvisibleUpdateZeros();
    }

    private async Task FetchTextures() {
        await Model.FetchAllTextures();
    }
    private void SetTextures() {
        View.SetAllTextures();
    }

    private void SetZerosVisibility() {
        if (!Model.areZerosVisible) View.ToggleZeros();
    }

    private void IfInvisibleUpdateZeros() {
        if (!Model.areZerosVisible) View.UpdateZeros();
    }
}