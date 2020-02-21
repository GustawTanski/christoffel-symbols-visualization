using System.Threading.Tasks;
using Data;
using UnityEngine;
public class CubeController : ChristofellElement, INotifiable {

    private CubeModel cubeModel;
    private CubeView cubeView;

    private async void Start() {
        SetReferences();
        await FetchAllTextures();
        SetTextures();
        SetZerosVisibility();
    }

    private void SetReferences() {
        cubeModel = App.model.cube;
        cubeView = App.view.cube;
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
    }

    private bool IsTabKeyUp() {
        return Input.GetKeyUp(KeyCode.Tab);
    }

    private void ToggleIndexes() {
        App.view.cube.ToggleIndexes();
    }
    public void OnNotification(ChristofellNotification notification, object target, params object[] data) {
        switch (notification) {
            case ChristofellNotification.ZeroHided:
                OnZeroToggleClicked();
                break;
            case ChristofellNotification.SpaceTypeChanged:
                OnSpaceValueChanged((SpaceType) data[0]);
                break;
        }
    }

    private void OnZeroToggleClicked() {
        ToggleZerosVisibilityState();
        ToggleZerosVisibility();
    }

    private void ToggleZerosVisibilityState() {
        cubeModel.areZerosVisible = !cubeModel.areZerosVisible;
    }

    private void ToggleZerosVisibility() {
        cubeView.ToggleZeros();
    }

    private async void OnSpaceValueChanged(SpaceType space) {
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
        cubeView.UpdateZeros();
    }

    private async Task FetchFormulaTextures() {
        await cubeModel.FetchFormulaTextures();
    }

    private void SetFormulaTextures() {
        cubeView.SetFormulaTextures();
    }

}