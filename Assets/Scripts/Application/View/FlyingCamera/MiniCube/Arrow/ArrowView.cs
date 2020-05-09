using System.Threading.Tasks;
using Data;
using UnityEngine;
public class ArrowView : ChristofellElement {
    public DynamicSprite indexSprite;
    public uint index;
    private string laTeX;
    private Texture2D texture;
    private TensorProperties properties;

    private async void Start() {
        SetListeners();
    }

    private void SetListeners() {
        App.spaceChanged.listOfHandlers += OnSpaceDropdownChanged;
    }

    private async void OnSpaceDropdownChanged(object caller, SpaceChangedArgs e) {
        properties = e.tensorProperties;
        await SetIndexTexture();
    }

    private async Task SetIndexTexture() {
        SetLaTeX();
        await FetchTexture();
        SetSpriteTexture();
    }

    private void SetLaTeX() {
        laTeX = GetLaTeXFromTensorProperties();
    }

    private string GetLaTeXFromTensorProperties() {
        return properties.Indexes[index].LaTeX;
    }

    private async Task FetchTexture() {
        texture = await LaTeXTextureDownloader.FetchOneTexture(laTeX);
    }
    private void SetSpriteTexture() {
        indexSprite.SetTexture(texture);
    }

}