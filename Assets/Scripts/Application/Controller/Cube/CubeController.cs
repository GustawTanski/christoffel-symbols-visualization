using System.Threading.Tasks;
using Data;
using UnityEngine;

public class CubeController : ChristofellElement {
    public CubePlaneSlicer cubePlaneSlicer;

    private CubeModel cubeModel;
    private CubeView cubeView;

    private void Awake() {
        SetReferences();
    }
    private void SetReferences() {
        cubeModel = App.model.cube;
        cubeView = App.view.cube;
    }

    private async void Start() {
        SetEventListeners();
        await FetchAllTextures();
        SetTextures();
        SetZerosVisibility();
    }

    private void SetEventListeners() {
        App.zerosHidedEvent.AddListener(OnZerosHided);
        App.spaceChangedEvent.AddListener(OnSpaceChanged);
    }

    private void OnZerosHided() {
        ToggleZerosVisibilityState();
        ToggleZerosVisibility();
    }

    private void ToggleZerosVisibilityState() {
        cubeModel.areZerosVisible = !cubeModel.areZerosVisible;
    }

    private void ToggleZerosVisibility() {
        cubeView.ToggleZeros();
    }

    private async void OnSpaceChanged(SpaceType space) {
        SetSpaceState(space);
        UpdateFormulasState();
        await FetchFormulaTextures();
        SetFormulaTextures();
    }

    private void SetSpaceState(SpaceType space) {
        cubeModel.space = space;
    }

    private void UpdateFormulasState() {
        cubeModel.UpdateFormulas();
        if (!cubeModel.areZerosVisible) cubeView.UpdateZeros();
    }

    private async Task FetchFormulaTextures() {
        await cubeModel.FetchFormulaTextures();
    }

    private void SetFormulaTextures() {
        cubeView.SetFormulaTextures();
    }

    private async Task FetchAllTextures() {
        await cubeModel.FetchAllTextures();
    }

    private void SetTextures() {
        cubeView.SetAllTextures();
    }

    private void SetZerosVisibility() {
        if (!cubeModel.areZerosVisible) cubeView.ToggleZeros();
    }

    private void Update() {
        if (IsTabKeyUp()) ToggleIndexes();
        cubeView.DeselectAllElements();
        foreach (var plane in cubePlaneSlicer.SelectedPlanes) {
            foreach (var element in plane) {
                element.Select();
            }
        }
    }

    private bool IsTabKeyUp() {
        return Input.GetKeyUp(KeyCode.Tab);
    }

    private void ToggleIndexes() {
        App.view.cube.ToggleIndexes();
    }

}