using Data;
using Latex;
using UnityEngine;

namespace Cube {
    public class Matrix3D : MonoBehaviour {
        public SpaceTypeDictionary dict;
        public SpaceType space;

        public LatexSprite prefab;
        private ChristofellProvider christofell;
        private Cube cube;

        private void Start() {
            christofell = new ChristofellProvider(dict, space);
            christofell.FetchTensor();
            cube = new Cube(prefab, christofell.Tensor);
            StartCoroutine(cube.InitializeElements(CreateElement));
        }

        private LatexSprite CreateElement(LatexSprite prefab) {
            return Instantiate(prefab, transform);
        }
    }
}