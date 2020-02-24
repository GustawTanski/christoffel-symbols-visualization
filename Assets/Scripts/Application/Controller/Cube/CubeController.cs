using System.Threading.Tasks;
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
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                CubeElement element = hit.transform.GetComponent<CubeElement>();
                if (element != null) {
                    Vector3Int indexes = App.view.cube.FindElementsIndexes(element);
                    cubeModel.SelectedCubeElementIndexes = indexes;
                }
            }
        }
        if (Input.GetMouseButton(1)) {
            Vector3 differenceVector = App.model.uI.LineDifferenceVector;
            if (differenceVector.magnitude > 0.1) {
                Vector3 rotatedUp = cubeView.transform.rotation * Vector3.up;
                var s = Vector3.Project(Quaternion.Inverse(Camera.main.transform.rotation) * differenceVector, rotatedUp).magnitude;
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