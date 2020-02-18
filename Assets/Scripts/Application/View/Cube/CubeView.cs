using BetterMultidimensionalArray;
using Cube;
using UnityEngine;
public class CubeView : ChristofellElement {
    public CubeElement cubeElementPrefab;
    private CubeElement[, , ] elements = new CubeElement[4, 4, 4];

    private void Awake() {
        elements = elements.Select((_, i, j, k) => {
            float distance = App.model.cube.distance;
            CubeElement element = Instantiate(cubeElementPrefab, transform);
            element.LocalPosition = new Vector3(i, -j, k) * distance;
            element.Initialize();
            return element;
        });
    }

    public void SetAllTextures() {
        SetIndexTextures();
        SetFormulaTextures();
    }

    public void SetFormulaTextures() {
        elements.ForEach((element, i, j, k) => {
            element.FormulaTexture = App.model.cube.FormulaTextures[i, j, k];
        });
    }

    public void SetIndexTextures() {
        elements.ForEach((element, i, j, k) => {
            element.IndexTexture = App.model.cube.IndexTextures[i, j, k];
        });
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            elements.ForEach((element) => {
                element.ToggleIndex();
            });
        }
    }

}