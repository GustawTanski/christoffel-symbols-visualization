using Data;
using UnityEngine;

public class MiniCubeController : ChristofellElement {

    private MiniCubeView View => App.view.flyingCamera.miniCube;
    private MiniCubeModel Model => App.model.flyingCamera.miniCube;

    private void Start() {
        InitializeModel();
        SetEventListener();
    }

    private void InitializeModel() {
        Model.ZeroRotation = View.transform.localRotation;
        Model.TargetRotation = View.transform.localRotation;
    }

    private void SetEventListener() {
        App.miniCubeRotatorClicked.listOfHandlers += OnCubeRotationStarted;
        App.resetButtonClicked.listOfHandlers += OnResetButtonClicked;
    }

    private void OnCubeRotationStarted(object sender, MiniCubeRotatorClickedEventArgs e) {
        RotateAroundAxis(e.axis, e.angle);
    }

    private void RotateAroundAxis(Dimension axis, float angle) {
        AddToTargetRotation(Quaternion.AngleAxis(angle, Model.TargetRotation * axis.DirVector));
    }

    private void AddToTargetRotation(Quaternion rotation) {
        Model.TargetRotation = rotation * Model.TargetRotation;
    }

    private void Update() {
        if (!IsTargetRotationReached()) DoLittleRotationTowardsTarget();
        UpdateRotationRegardingCameraPosition();
    }

    private void OnResetButtonClicked(object caller, ResetButtonClickedArgs e) {
        Model.TargetRotation = Quaternion.identity;
    }

    private bool IsTargetRotationReached() {
        return Model.LocalRotation == Model.TargetRotation;
    }

    private void DoLittleRotationTowardsTarget() {
        Model.LocalRotation = CalculateLittleRotationTowardsTarget();
        UpdateViewRotation();
    }

    private Quaternion CalculateLittleRotationTowardsTarget() {
        return Quaternion.Slerp(Model.LocalRotation, Model.TargetRotation, Time.deltaTime);
    }

    private void UpdateViewRotation() {
        View.transform.localRotation = Model.RelativeToCubeRotation * Model.LocalRotation * Model.ZeroRotation;
    }

    private void UpdateRotationRegardingCameraPosition() {
        Model.RelativeToCubeRotation = CalculateRelativeToCubeRotationAroundYAxis();
        UpdateViewRotation();
    }

    private Quaternion CalculateRelativeToCubeRotationAroundYAxis() {
        return Quaternion.FromToRotation(CalculateRelativePositionProjectOnXZPlane(), Vector3.back);
    }

    private Vector3 CalculateRelativePositionProjectOnXZPlane() {
        return Vector3.ProjectOnPlane(CalculateRelativePositionBetweenCameraAndCubeCenter(), Vector3.up);
    }

    private Vector3 CalculateRelativePositionBetweenCameraAndCubeCenter() {
        return App.view.flyingCamera.transform.position - App.view.cube.transform.position;
    }
}