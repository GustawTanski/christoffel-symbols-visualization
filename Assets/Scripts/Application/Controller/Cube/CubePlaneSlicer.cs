using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
public class CubePlaneSlicer : ChristoffelElement {

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
        return App.controller.tools.line.IsElementHit();
    }

    private bool IsDifferenceVectorLongEnough() {
        return App.model.tools.LineDifferenceVector.magnitude >= MINIMAL_DIFFERENCE_MAGNITUDE;
    }

    private void SelectPlane() {
        SetPlaneDimension();
        SetPlaneIndex();
        AddToSelectedPlanes();
    }

    private void SetPlaneDimension() {
        planeDimension = CalculatePlaneDimension();
    }

    private Dimension CalculatePlaneDimension() {
        return GetOnPlaneDimensionsProjectionSorted().First().dimension;
    }

    private IOrderedEnumerable < (Dimension dimension, float projection) > GetOnPlaneDimensionsProjectionSorted() {
        return GetAllCubeDirectionVectors()
            .Where(IsOnHitPlane)
            .Select(GetDimensionProjectionPair)
            .OrderBy(pair => pair.projection);
    }
    private IEnumerable<Vector3> GetAllCubeDirectionVectors() {
        return new [] { Direction.x, Direction.y, Direction.z }
            .Select(dir => new Dimension(dir).DirVector)
            .Select(RotateAsCube);
    }

    private Vector3 RotateAsCube(Vector3 dirVector) {
        return App.view.cube.transform.rotation * dirVector;
    }

    private bool IsOnHitPlane(Vector3 vector) {
        Vector3 projection = Vector3.ProjectOnPlane(vector, App.model.tools.LineStartPivot.PlaneNormal);
        return projection.magnitude > 1E-4;
    }

    private(Dimension dimension, float projection) GetDimensionProjectionPair(Vector3 rotatedVector) {
        float projection = ProjectOnDifferenceVector(rotatedVector);
        Dimension dimension = new Dimension((DerotateFromCube(rotatedVector)));
        return (
            dimension,
            projection
        );
    }

    private float ProjectOnDifferenceVector(Vector3 vector) {
        Vector3 normalizedDifference = App.model.tools.LineDifferenceVector.normalized;
        return Vector3.Project(normalizedDifference, vector).magnitude;
    }

    private Vector3 DerotateFromCube(Vector3 rotatedDirVector) {
        return Quaternion.Inverse(App.view.cube.transform.rotation) * rotatedDirVector;
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