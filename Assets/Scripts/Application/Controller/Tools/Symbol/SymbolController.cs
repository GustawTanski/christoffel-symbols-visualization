using UnityEngine;
using Data;
public class SymbolController : ChristoffelElement {
    private SymbolView View => App.view.tools.symbol;

    private TensorProperties tensorProperties;

    private void Awake() {
        App.spaceVisualizedByCubeChanged.listOfHandlers += async (sender, e) => {
            string laTeX = SymbolIndexToLaTeXConverter.Convert(e.tensorProperties);
            View.HideSymbol();
            View.ShowLoader();
            Texture2D texture = await LaTeXTextureDownloader.FetchOneTexture(laTeX);
            View.Texture = texture;
            View.HideLoader();
            View.ShowSymbol();
        };
    }
}

public class SymbolIndexToLaTeXConverter : IndexToLaTeXConverter {

    static public string Convert(TensorProperties props) {
        return new SymbolIndexToLaTeXConverter(props).GetLaTeX();
    }

    public SymbolIndexToLaTeXConverter(TensorProperties props) : base(props) {}


    protected override IndexWrapper ConvertToWrappers(TensorProperties.Index index, int n) {
        return new IndexWrapper {
            CoordinateLaTeX = index.LaTeX,
                Number = n,
                Index = index
        };
    }
}