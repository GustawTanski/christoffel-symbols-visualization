using System;
using System.Threading.Tasks;
using Data;
using UnityEngine;

public class CubeController : ChristofellElement {
    public CubePlaneSlicer cubePlaneSlicer;
    private CubeModel Model => App.model.cube;
    private CubeView View => App.view.cube;

    private IDataLoadAndSaveSystem dataSystem = new ResourceDataSystem();

    private void Awake() {
        SetEventListeners();
        SetZerosVisibility();
        var resources = dataSystem.LoadAll();
        foreach (var resource in resources) {
            Debug.Log(resource);
        }
        Debug.Log(resources.Length);
    }

    private void SetEventListeners() {
        App.zerosHided.listOfHandlers += OnZerosHided;
        App.spaceDropdownChanged.listOfHandlers += OnSpaceDropdownChanged;
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

    private async void OnSpaceDropdownChanged(object sender, SpaceDropdownChangedArgs e) {
        ChangeSpace(e.space);
        await UpdateTextures();
    }

    private void ChangeSpace(SpaceType space) {
        SetSpaceState(space);
        Model.UpdateModel();
        DispatchSpaceChangedEvent();
    }

    private void SetSpaceState(SpaceType space) {
        Model.space = space;
    }

    private void DispatchSpaceChangedEvent() {
        App.spaceChanged.DispatchEvent(this, new SpaceChangedArgs(Model.Properties));
    }

    private async Task UpdateTextures() {
        await FetchTextures();
        SetTextures();
        IfInvisibleUpdateZeros();
    }

    private async Task FetchTextures() {
        await Model.FetchAllTextures();
    }

    private void IfInvisibleUpdateZeros() {
        if (!Model.areZerosVisible) View.UpdateZeros();
    }

    private void SetTextures() {
        View.SetAllTextures();
    }

    private void SetZerosVisibility() {
        if (!Model.areZerosVisible) View.ToggleZeros();
    }

    private void Update() {
        if (IsTabKeyUp()) ToggleIndexes();
        View.DeselectAllElements();
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