using System.Threading.Tasks;
using Data;
using UnityEngine;
public class SymbolController : ChristoffelElement {
    private SymbolView View => App.view.tools.symbol;

    private TensorProperties tensorProperties;
    private string laTeX;
    private Texture2D texture;

    private void Awake() {
        App.spaceVisualizedByCubeChanged.listOfHandlers += OnSpaceVisualizedByCubeChanged;
    }

    private void OnSpaceVisualizedByCubeChanged(object sender, SpaceChangedArgs e) {
        tensorProperties = e.tensorProperties;
        FetchAndShowSymbol();
    }

    private async void FetchAndShowSymbol() {
        View.HideSymbol();
        View.ShowLoader();
        string nameOfFetched = tensorProperties.Name;
        GenerateLaTeX();
        await FetchTexture();
        IfNameOfFetchedIsCurrentTensorNameUpdateSymbol(nameOfFetched);
    }

    private void GenerateLaTeX() {
        laTeX = SymbolIndexToLaTeXConverter.Convert(tensorProperties);
    }

    private async Task FetchTexture() {
        texture = await LaTeXTextureDownloader.FetchOneTexture(laTeX);
    }

    private void IfNameOfFetchedIsCurrentTensorNameUpdateSymbol(string nameOfFetched) {
        if (IsNameOfFetchedTheCurrentTensorName(nameOfFetched)) UpdateSymbol();
    }

    private bool IsNameOfFetchedTheCurrentTensorName(string nameOfFetched) {
        return nameOfFetched == tensorProperties.Name;
    }

    private void UpdateSymbol() {
        View.Texture = texture;
        View.HideLoader();
        View.ShowSymbol();
    }
}