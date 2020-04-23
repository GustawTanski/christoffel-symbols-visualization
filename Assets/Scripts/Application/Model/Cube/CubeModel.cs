using System.Threading.Tasks;
using Data;
using UnityEngine;
public class CubeModel : ChristofellElement {
    public SpaceType space = SpaceType.Minkowski;
    public SpaceTypeDictionary spaceDictionary;
    public float elementSize = 12;
    public bool areZerosVisible;

    public string[, , ] IndexTensor {
        get;
        private set;
    }

    public string[, , ] FormulaTensor {
        get;
        private set;
    }

    public Texture2D[, , ] IndexTextures {
        get;
        private set;
    }

    public Texture2D[, , ] FormulaTextures {
        get;
        private set;
    }

    public Vector3Int SelectedCubeElementIndexes {
        get;
        set;
    } = Vector3Int.one * -1;

    private void Awake() {
        UpdateFormulas();
        UpdateIndexTensor();
    }

    private void UpdateJsonFileOfTensorProvider() {
        TensorProvider.JsonFile = GetJsonFile().text;

    }

    private TextAsset GetJsonFile() {
        return spaceDictionary[space];
    }

    public void UpdateIndexTensor() {
        IndexTensor = TensorProvider.GetIndexTensor();
    }

    public void UpdateFormulas() {
        UpdateJsonFileOfTensorProvider();
        FormulaTensor = TensorProvider.GetFormulaTensor();
    }

    public async Task FetchAllTextures() {
        await Task.WhenAll(FetchIndexTextures(), FetchFormulaTextures());
    }

    public async Task FetchIndexTextures() {
        IndexTextures = await LaTeXTextureDownloader.Fetch(IndexTensor, new TextureSettings { size = Size.normal });
    }

    public async Task FetchFormulaTextures() {
        FormulaTextures = await LaTeXTextureDownloader.Fetch(FormulaTensor);
    }

}