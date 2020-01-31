using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LatexSprite : MonoBehaviour {
    // Start is called before the first frame update
    private string latex = "0";
    private Texture2D texture;
    private UnityWebRequest www;

    public string Latex {
        get {
            return latex;
        }
        set {
            latex = value;
            StartCoroutine(DownloadLatexTexture());
        }
    }

    void Start() {
        StartCoroutine(DownloadLatexTexture());
    }

    private IEnumerator DownloadLatexTexture() {
        yield return FetchTexture();
        LoadTexture();
        SetSprite();
    }

    private UnityWebRequestAsyncOperation FetchTexture() {
        www = UnityWebRequest.Get(GetUrl());
        return www.SendWebRequest();
    }

    private string GetUrl() {
        return $"https://latex.codecogs.com/png.latex?{GetLatexString()}";
    }

    private string GetLatexString() {
        return @"\dpi{999}" + latex;
    }

    private void LoadTexture() {
        var result = www.downloadHandler.data;
        texture = new Texture2D(2, 2);
        texture.LoadImage(result);
    }

    private void SetSprite() {
        GetComponent<SpriteRenderer>().sprite = CreateSprite();
    }

    private Sprite CreateSprite() {
        const int PIXELS_PER_UNIT = 100;
        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            PIXELS_PER_UNIT
        );
    }

    private void Update() {
        transform.rotation = Camera.main.transform.rotation;
    }

}