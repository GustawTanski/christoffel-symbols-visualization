using System.Threading.Tasks;
using UnityEngine;
public class ArrowView : ChristofellElement {
    public DynamicSprite indexSprite;
    public uint index;

    private string laTeX;
    private Texture2D texture;
    private async void Start() {
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
        return TensorProvider.Properties.Indexes[index].LaTeX;
    }

    private async Task FetchTexture() {
        texture = await LaTeXTextureDownloader.FetchOneTexture(laTeX);
    }
    private void SetSpriteTexture() {
        indexSprite.SetTexture(texture);
    }

}