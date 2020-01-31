using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Newtonsoft.Json;
using UnityEngine;

public class Matrix3D : MonoBehaviour {
    public LatexSprite template;
    public MatrixType matrixType;
    public string color = "Black";
    public Dict dict;
    public int space = 10;
    private string[, , ] tensor;

    private Vector3[, , ] positions = new Vector3[4, 4, 4];

    private Vector3[, , ] translations = new Vector3[4, 4, 4];
    private LatexSprite[, , ] sprites = new LatexSprite[4, 4, 4];

    void Start() {
        GetTensor();
        InitializeElements();
        Debug.Log(translations[0, 0, 0]);
    }

    private void GetTensor() {
        var textAsset = dict[matrixType];
        string json = textAsset.text;
        tensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        Debug.Log(tensor[1, 1, 1]);
    }

    private void InitializeElements() {
        for (int i = 0; i < tensor.GetLength(0); i++) {
            for (int j = 0; j < tensor.GetLength(1); j++) {
                for (int k = 0; k < tensor.GetLength(2); k++) {
                    var sprite = Instantiate(template);
                    sprites[i, j, k] = sprite;
                    sprite.transform.SetParent(transform);
                    sprite.transform.localPosition = new Vector3(i * space, -j * space, k * space);
                    sprite.Latex = @"{\color{" + color + @"}" + tensor[i, j, k] + @"}";
                }
            }
        }
    }

    private void ComputePositions() {
        for (int i = 0; i < tensor.GetLength(0); i++) {
            for (int j = 0; j < tensor.GetLength(1); j++) {
                for (int k = 0; k < tensor.GetLength(2); k++) {
                    ComputePosition(i, j, k);
                }
            }
        }
    }

    private void ComputePosition(int i, int j, int k) {
        positions[i, j, k] = new Vector3(i * space, -j * space, k * space) + translations[i, j, k];
    }
    void Update() {}

    void OnGUI() {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.control) {
            Debug.Log("ctrl");
            for (int i = 0; i < tensor.GetLength(1); i++) {
                for (int j = 0; j < tensor.GetLength(2); j++) {
                    translations[i, j, 1] = new Vector3(0, 30, 0);
                }
            }
            MoveSprites();
        }
    }

    private void MoveSprites() {
        ComputePositions();
        for (int i = 0; i < tensor.GetLength(0); i++) {
            for (int j = 0; j < tensor.GetLength(1); j++) {
                for (int k = 0; k < tensor.GetLength(2); k++) {
                    sprites[i, j, k].transform.localPosition = positions[i, j, k];
                }
            }
        }
    }
}