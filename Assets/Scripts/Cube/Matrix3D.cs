using System.Threading.Tasks;
using Data;
using UnityEngine;

namespace Cube {
    public class Matrix3D : MonoBehaviour {
        public SpaceTypeDictionary dict;
        public SpaceType space;
        public CubeElement cubePrefab;
        private ChristofellProvider christofell;
        private Cube cube;

        private async void Start() {
            InitializeChristofell();
            await InitializeCube();
        }

        private void InitializeChristofell() {
            christofell = new ChristofellProvider(dict, space);
            christofell.GetFormulas();
        }

        private async Task InitializeCube() {
            cube = new Cube(cubePrefab, christofell.FormulaTensor, christofell.IndexesTensor);
            await cube.Initialize(CreateElement);
        }

        private CubeElement CreateElement(CubeElement prefab) {
            return Instantiate(prefab, transform);
        }

        public void ToggleZeros() {
            cube.ToggleZeros();
        }

        public async void SetSpace(int space) {
            christofell.Space = (SpaceType) space;
            christofell.GetFormulas();
            cube.FormulaTensor = christofell.FormulaTensor;
            await cube.ChangeFormulaTextures();
        }
    }
}