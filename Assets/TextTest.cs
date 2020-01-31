using System.Collections;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class TextTest : MonoBehaviour {

    private TextMeshPro text;
    private string[][] tensor;
    private Texture2D texture;
    IEnumerator Start() {
        text = gameObject.GetComponent<TextMeshPro>();
        text.text = "";
        using(StreamReader r = new StreamReader("./Assets/Data/PlainMetric.json")) {
            string json = r.ReadToEnd();
            tensor = JsonConvert.DeserializeObject<string[][]>(json);
            var www = new WWW($"https://latex.codecogs.com/png.latex?{tensor[3][3]}");
            yield return www;
            texture = www.texture;

        }
    }

    // Update is called once per frame
    void OnGUI() {
        if (texture != null)
            GUI.DrawTexture(new Rect(50, 50, texture.width, texture.height), texture);

    }
}