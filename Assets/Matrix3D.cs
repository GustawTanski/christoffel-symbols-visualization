using Data;
using UnityEngine;

public class Matrix3D : MonoBehaviour {
    public LatexSprite template;
    public string color = "Black";

    public int distance = 10;
    private ChristofellProvider christofell;
    private Vector3[, , ] positions = new Vector3[4, 4, 4];

    private Vector3[, , ] translations = new Vector3[4, 4, 4];
    private LatexSprite[, , ] sprites = new LatexSprite[4, 4, 4];

    void Start() {
        christofell = GetComponent<ChristofellProvider>();
        if (christofell == null) Debug.LogError("Matrix3D require ChristofellProvider to work.");
        InitializeElements();
    }

    private void InitializeElements() {
        for (int i = 0; i < christofell.Tensor.GetLength(0); i++) {
            for (int j = 0; j < christofell.Tensor.GetLength(1); j++) {
                for (int k = 0; k < christofell.Tensor.GetLength(2); k++) {
                    var sprite = Instantiate(template);
                    sprites[i, j, k] = sprite;
                    sprite.transform.SetParent(transform);
                    sprite.transform.localPosition = new Vector3(i * distance, -j * distance, k * distance);
                    sprite.Latex = @"{\color{" + color + @"}" + christofell.Tensor[i, j, k] + @"}";
                }
            }
        }
    }

    private void ComputePositions() {
        for (int i = 0; i < christofell.Tensor.GetLength(0); i++) {
            for (int j = 0; j < christofell.Tensor.GetLength(1); j++) {
                for (int k = 0; k < christofell.Tensor.GetLength(2); k++) {
                    ComputePosition(i, j, k);
                }
            }
        }
    }

    private void ComputePosition(int i, int j, int k) {
        positions[i, j, k] = new Vector3(i * distance, -j * distance, k * distance) + translations[i, j, k];
    }
    void Update() {}

    void OnGUI() {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.control) {
            Debug.Log("ctrl");
            for (int i = 0; i < christofell.Tensor.GetLength(1); i++) {
                for (int j = 0; j < christofell.Tensor.GetLength(2); j++) {
                    translations[i, j, 1] = new Vector3(0, 30, 0);
                }
            }
            MoveSprites();
        }
    }

    private void MoveSprites() {
        ComputePositions();
        for (int i = 0; i < christofell.Tensor.GetLength(0); i++) {
            for (int j = 0; j < christofell.Tensor.GetLength(1); j++) {
                for (int k = 0; k < christofell.Tensor.GetLength(2); k++) {
                    sprites[i, j, k].transform.localPosition = positions[i, j, k];
                }
            }
        }
    }
}