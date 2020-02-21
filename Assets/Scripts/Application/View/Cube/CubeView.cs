using System.Collections.Generic;
using System.Linq;
using BetterMultidimensionalArray;
using UnityEngine;
public class CubeView : ChristofellElement {
    public CubeElement cubeElementPrefab;
    private CubeElement[, , ] elements = new CubeElement[4, 4, 4];
    private void Awake() {
        elements = elements.Select(CreateElement);
    }
    private CubeElement CreateElement(CubeElement _, int i, int j, int k) {
        CubeElement element = Instantiate(cubeElementPrefab, transform);
        element.LocalPosition = GetElementLocalPosition(i, j, k);
        element.Initialize();
        return element;
    }

    private Vector3 GetElementLocalPosition(int i, int j, int k) {
        return new Vector3(i, -j, k) * App.model.cube.distance;
    }

    public void ToggleIndexes() {
        elements.ForEach((element) => {
            element.ToggleIndex();
        });
    }

    public void SetAllTextures() {
        SetIndexTextures();
        SetFormulaTextures();
    }

    public void SetFormulaTextures() {
        elements.ForEach(SetFormalaTexture);
    }

    private void SetFormalaTexture(CubeElement element, int i, int j, int k) {
        element.FormulaTexture = App.model.cube.FormulaTextures[i, j, k];
    }

    public void SetIndexTextures() {
        elements.ForEach((element, i, j, k) => {
            element.IndexTexture = App.model.cube.IndexTextures[i, j, k];
        });
    }

    public void ToggleZeros() {
        GetZeros().ForEach(ToggleElementVisibility);
    }

    private List<CubeElement> GetZeros() {
        return elements.Where(IsElementZero).ToList();
    }

    private bool IsElementZero(CubeElement _, int i, int j, int k) {
        return App.model.cube.FormulaTensor[i, j, k] == "0";
    }

    private void ToggleElementVisibility(CubeElement element) {
        element.ToggleVisibility();
    }

    public void UpdateZeros() {
        GetZeros().ForEach(HideElement);
        GetNonZeros().ForEach(ShowElement);
    }

    private void HideElement(CubeElement element) {
        element.Disappear();
    }

    private List<CubeElement> GetNonZeros() {
        return elements.Cast<CubeElement>().Except(GetZeros()).ToList();
    }

    private void ShowElement(CubeElement element) {
        element.Appear();
    }

}