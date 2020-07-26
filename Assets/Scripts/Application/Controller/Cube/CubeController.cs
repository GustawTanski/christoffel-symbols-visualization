using System;
using System.Threading.Tasks;

public class CubeController : ChristofellElement {
    public CubePlaneSlicer cubePlaneSlicer;
    public SpaceSelector spaceSelector;
    private CubeModel Model => App.model.cube;
    private CubeView View => App.view.cube;

    private void Awake() {
        SetEventListeners();
        SetZerosVisibility();
    }

    // private void Start() {
    //     var system = new EasySaveDataSystem();
    //     foreach(var asset in Model.SpaceDictionaryNew.Values) {
    //         system.Save(asset);
    //     }
    // }
    private void SetEventListeners() {
        App.zerosHided.listOfHandlers += OnZerosHided;
        App.labelSliderValueChanged.listOfHandlers += OnLabelSliderValueChanged;
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
        App.view.cube.ToggleIndexes();
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
        foreach (CubeElement element in plane) element.Select();
    }

    public async void SetSpaceType(string spaceType) {
        ChangeSpace(spaceType);

    }

    private void ChangeSpace(string spaceType) {
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

    public async void UpdateCube() {
        await UpdateTextures();
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