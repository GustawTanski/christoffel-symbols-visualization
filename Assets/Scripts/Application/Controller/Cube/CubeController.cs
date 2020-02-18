public class CubeController : ChristofellElement {
    private async void Start() {
        await App.model.cube.FetchAllTextures();
        App.view.cube.SetAllTextures();
    }
}