using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterMultidimensionalArray;
using Data;
using UnityEngine;
public class CubeController : ChristofellElement {

    private CubeModel cubeModel;
    private CubeView cubeView;

    private async void Start() {
        SetReferences();
        SetEventListeners();
        await FetchAllTextures();
        SetTextures();
        SetZerosVisibility();
    }

    private void SetReferences() {
        cubeModel = App.model.cube;
        cubeView = App.view.cube;
    }

    private void SetEventListeners() {
        App.zerosHidedEvent.AddListener(OnZerosHided);
        App.spaceChangedEvent.AddListener(OnSpaceChanged);
    }

    private void OnZerosHided() {
        ToggleZerosVisibilityState();
        ToggleZerosVisibility();
    }

    private void ToggleZerosVisibilityState() {
        cubeModel.areZerosVisible = !cubeModel.areZerosVisible;
    }

    private void ToggleZerosVisibility() {
        cubeView.ToggleZeros();
    }

    private async void OnSpaceChanged(SpaceType space) {
        SetSpaceState(space);
        UpdateFormulasState();
        await FetchFormulaTextures();
        SetFormulaTextures();
    }

    private void SetSpaceState(SpaceType space) {
        cubeModel.space = space;
    }

    private void UpdateFormulasState() {
        cubeModel.UpdateFormulas();
        if (!cubeModel.areZerosVisible) cubeView.UpdateZeros();
    }

    private async Task FetchFormulaTextures() {
        await cubeModel.FetchFormulaTextures();
    }

    private void SetFormulaTextures() {
        cubeView.SetFormulaTextures();
    }

    private async Task FetchAllTextures() {
        await cubeModel.FetchAllTextures();
    }

    private void SetTextures() {
        cubeView.SetAllTextures();
    }

    private void SetZerosVisibility() {
        if (!cubeModel.areZerosVisible) cubeView.ToggleZeros();
    }

    private void Update() {
        if (IsTabKeyUp()) ToggleIndexes();
        if (Input.GetMouseButton(1)) {
            Vector3 difference = App.model.uI.LineDifferenceVector;
            if (difference.magnitude > 0.1) {
                Vector3 normalizedDifference = difference.normalized;
                var casts = new List<Vector3>() { Vector3.right, Vector3.up, Vector3.forward }
                    .Where((vec) => Vector3.ProjectOnPlane(vec, App.model.uI.LineStartPivot.PlaneNormal).magnitude != 0)
                    .Select((vec) => (new { vec = vec, project = Vector3.Project(normalizedDifference, vec).magnitude }))
                    .ToList();
                casts.Sort((pair1, pair2) => pair1.project.CompareTo(pair2.project));
                Dimension dir;
                int planeIndex = -1;
                Vector3 firstVector = casts.First().vec;
                dir = DimensionDictionaries.vectorToDimension[firstVector];
                if (firstVector == Vector3.right) {
                    planeIndex = App.model.cube.SelectedCubeElementIndexes.x;
                } else if (firstVector == Vector3.up) {
                    planeIndex = App.model.cube.SelectedCubeElementIndexes.y;
                } else if (firstVector == Vector3.forward) {
                    planeIndex = App.model.cube.SelectedCubeElementIndexes.z;
                } else {
                    dir = Dimension.zero;
                }
                foreach (var element in cubeView.elements) {
                    element.SetFormulaColor(Color.white);
                }
                foreach (var element in cubeView.GetPlane(dir, planeIndex)) {
                    element.SetFormulaColor(Color.red);
                }
            }
        }
    }

    private bool IsTabKeyUp() {
        return Input.GetKeyUp(KeyCode.Tab);
    }

    private void ToggleIndexes() {
        App.view.cube.ToggleIndexes();
    }

}