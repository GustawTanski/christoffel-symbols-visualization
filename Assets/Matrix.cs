using Data;
using Newtonsoft.Json;
using Latex;
using UnityEngine;

public class Matrix : MonoBehaviour {
    public LatexSprite template;
    public SpaceType matrixType;
    public string color = "Black";
    public SpaceTypeDictionary dict;

    private string[][] tensor;

    void Start() {
        GetTensor();
        RenderElements();
    }

    private void GetTensor() {
        var textAsset = dict[matrixType];
        string json = textAsset.text;
        tensor = JsonConvert.DeserializeObject<string[][]>(json);
    }

    private void RenderElements() {
        for (int i = 0; i < tensor.Length; i++) {
            for (int j = 0; j < tensor[i].Length; j++) {
                var sprite = Instantiate(template);
                sprite.transform.SetParent(transform);
                sprite.transform.localPosition = new Vector3(i * 10, -j * 10, 0);
                sprite.Latex = @"{\color{" + color + @"}" + tensor[i][j] + @"}";
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}