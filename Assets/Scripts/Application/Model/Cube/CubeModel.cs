using System.Threading.Tasks;
using Cube;
using Data;
using UnityEngine;
public class CubeModel : ChristofellElement {
    public SpaceType space = SpaceType.PlainSpace;
    public SpaceTypeDictionary spaceDictionary;
    public float distance = 12;

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

    private void Awake() {
        IndexTensor = TensorProvider.GetIndexTensor();
        FormulaTensor = TensorProvider.GetFormulaTensor(GetJsonFile());
    }

    private TextAsset GetJsonFile() {
        return spaceDictionary[space];
    }

    public async Task FetchAllTextures() {
        await Task.WhenAll(FetchIndexTextures(), FetchFormulaTextures());
    }

    public async Task FetchIndexTextures() {
        IndexTextures = await LaTeXTextureDownloader.Fetch(IndexTensor, new TextureSettings { size = Size.tiny });
    }

    public async Task FetchFormulaTextures() {
        FormulaTextures = await LaTeXTextureDownloader.Fetch(FormulaTensor);
    }

}