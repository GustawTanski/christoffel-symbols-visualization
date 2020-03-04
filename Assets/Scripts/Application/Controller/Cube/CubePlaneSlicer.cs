using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
public class CubePlaneSlicer : ChristofellElement {

    private Dimension planeDimension;
    private int planeIndex;

    private readonly float MINIMAL_DIFFERENCE_MAGNITUDE = 0.1f;

    public List<CubeElement[, ]> SelectedPlanes {
        get;
        private set;
    } = new List<CubeElement[, ]>();

    private void Update() {
        if (IsRightMouseButtonPressed()) ManageSelectedPlanes();
    }

    private bool IsRightMouseButtonPressed() {
        return Input.GetMouseButton(1);
    }

    private void ManageSelectedPlanes() {
        if (IsLeftControlNotPressed()) UnselectPlanes();
        if (IsHit() && IsDifferenceVectorLongEnough()) SelectPlane();
    }

    private bool IsLeftControlNotPressed() {
        return !Input.GetKey(KeyCode.LeftControl);
    }

    private void UnselectPlanes() {
        SelectedPlanes = new List<CubeElement[, ]>();
    }

    private bool IsHit() {
        return App.controller.UI.line.IsElementHit();
    }

    private bool IsDifferenceVectorLongEnough() {
        return App.model.uI.LineDifferenceVector.magnitude >= MINIMAL_DIFFERENCE_MAGNITUDE;
    }

    private void SelectPlane() {
        SetPlaneDimension();
        SetPlaneIndex();
        AddToSelectedPlanes();
    }

    private void SetPlaneDimension() {
        planeDimension = new Dimension(GetOnSurfacePlaneDirectionVector());
    }

    private Vector3 GetOnSurfacePlaneDirectionVector() {
        return GetOnPlaneDirectionsProjectionSorted().First().vector;
    }

    private Direction[] GetAllDirections() {
        return new [] { Direction.x, Direction.y, Direction.z };
    }

    private IOrderedEnumerable < (Vector3 vector, float projection) > GetOnPlaneDirectionsProjectionSorted() {
        return GetAllDirections()
            .Select(dir => new Dimension(dir).DirVector)
            .Where(IsOnHitPlane)
            .Select(GetVectorProjectionPair)
            .OrderBy(pair => pair.projection);
    }

    private bool IsOnHitPlane(Vector3 vector) {
        Vector3 projection = Vector3.ProjectOnPlane(vector, App.model.uI.LineStartPivot.PlaneNormal);
        return projection.sqrMagnitude != 0;
    }

    private(Vector3 vector, float projection) GetVectorProjectionPair(Vector3 vector) {
        float projection = ProjectOnDifferenceVector(vector);
        return (
            vector,
            projection
        );
    }

    private float ProjectOnDifferenceVector(Vector3 vector) {
        Vector3 normalizedDifference = App.model.uI.LineDifferenceVector.normalized;
        return Vector3.Project(normalizedDifference, vector).magnitude;
    }

    private void SetPlaneIndex() {
        planeIndex = Dimension.Project(App.model.cube.SelectedCubeElementIndexes, planeDimension);
    }

    private void AddToSelectedPlanes() {
        CubeElement[, ] plane = GetPlane();
        SelectedPlanes.Add(plane);
    }

    private CubeElement[, ] GetPlane() {
        return App.view.cube.GetPlane(planeDimension.Dir, planeIndex);;
    }

}