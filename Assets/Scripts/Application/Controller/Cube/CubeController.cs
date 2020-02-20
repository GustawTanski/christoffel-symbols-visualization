using Data;
public class CubeController : ChristofellElement {
    private async void Start() {
        await App.model.cube.FetchAllTextures();
        App.view.cube.SetAllTextures();
        if (!App.model.cube.areZerosVisible) App.view.cube.ToggleZeros();
    }

    public void OnZeroToggleClicked() {
        App.model.cube.areZerosVisible = !App.model.cube.areZerosVisible;
        App.view.cube.ToggleZeros();
    }

    public async void OnSpaceValueChanged(int space) {
        CubeModel model = App.model.cube;
        CubeView view = App.view.cube;
        model.space = (SpaceType) space;
        if (!model.areZerosVisible) {
            view.ToggleZeros();
            model.ResetFormulaTensor();
            view.ToggleZeros();
        } else {
            model.ResetFormulaTensor();
        }
        await model.FetchFormulaTextures();
        App.view.cube.SetFormulaTextures();
    }
}