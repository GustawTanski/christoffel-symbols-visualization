// using Data;
// using Latex;
// using UnityEngine;

// public class Matrix3D : MonoBehaviour {
//     public LatexSprite template;
//     public string color = "Black";

//     public int distance = 10;
//     private ChristofellProvider christofell;
//     private LatexSprite[, , ] sprites = new LatexSprite[4, 4, 4];

//     void Start() {
//         christofell = GetComponent<ChristofellProvider>();
//         if (christofell == null) Debug.LogError("Matrix3D require ChristofellProvider to work.");
//         // InitializeElements();
//     }

//     public void InitializeElements() {
//         for (int i = 0; i < christofell.Tensor.GetLength(0); i++) {
//             for (int j = 0; j < christofell.Tensor.GetLength(1); j++) {
//                 for (int k = 0; k < christofell.Tensor.GetLength(2); k++) {
//                     var sprite = Instantiate(template);
//                     sprites[i, j, k] = sprite;
//                     sprite.transform.SetParent(transform);
//                     sprite.LocalPosition = new Vector3(i * distance, -j * distance, k * distance);
//                     sprite.Latex = @"{\color{" + color + @"}" + christofell.Tensor[i, j, k] + @"}";
//                 }
//             }
//         }
//     }

//     public void ReloadTexture() {
//         for (int i = 0; i < christofell.Tensor.GetLength(0); i++) {
//             for (int j = 0; j < christofell.Tensor.GetLength(1); j++) {
//                 for (int k = 0; k < christofell.Tensor.GetLength(2); k++) {
//                     sprites[i, j, k].Latex = @"{\color{" + color + @"}" + christofell.Tensor[i, j, k] + @"}";
//                 }
//             }
//         }
//     }
// }