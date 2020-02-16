using Data;
using Latex;
using UnityEngine;

namespace Cube {
    public class Matrix3D : MonoBehaviour {
        public SpaceTypeDictionary dict;
        public SpaceType space;
        public CubeElement cubePrefab;
        private ChristofellProvider christofell;
        private Cube cube;

        private void Start() {
            InitializeChristofell();
            InitializeCube();
        }

        private void InitializeChristofell() {
            christofell = new ChristofellProvider(dict, space);
            christofell.FetchTensor();
        }

        private void InitializeCube() {
            cube = new Cube(cubePrefab, christofell.Tensor);
            StartCoroutine(cube.InitializeElements(CreateElement));
        }

        private CubeElement CreateElement(CubeElement prefab) {
            return Instantiate(prefab, transform);
        }

        private void Update() {
            if(Input.GetKeyUp(KeyCode.Tab)) {
                cube.SwitchIndexes();
            }
        }
    }
}