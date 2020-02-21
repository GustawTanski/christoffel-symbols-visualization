using Data;
public class CubeController : ChristofellElement, INotifiable {

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
    private async void Start() {
        await App.model.cube.FetchAllTextures();
        App.view.cube.SetAllTextures();
        if (!App.model.cube.areZerosVisible) App.view.cube.ToggleZeros();
    }

    private void OnZeroToggleClicked() {
        App.model.cube.areZerosVisible = !App.model.cube.areZerosVisible;
        App.view.cube.ToggleZeros();
    }

    private async void OnSpaceValueChanged(SpaceType space) {
        CubeModel model = App.model.cube;
        CubeView view = App.view.cube;
        model.space = space;
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