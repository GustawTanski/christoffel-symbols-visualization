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
        App.cubeRotationStartedEvent.listOfHandlers += OnCubeRotationStarted;
    }

    private void OnCubeRotationStarted(object sender, CubeRotationStartedEventArgs e) {
        RotateAroundAxis(e.axis, e.angle);
    }

    private void RotateAroundAxis(Dimension axis, float angle) {
        AddToTargetRotation(Quaternion.AngleAxis(angle, axis.DirVector));
    }

    private void AddToTargetRotation(Quaternion rotation) {
        Model.TargetRotation = rotation * Model.TargetRotation;
    }

    private void Update() {
        if (!IsTargetRotationReached()) DoLittleRotationTowardsTarget();
    }

    private bool IsTargetRotationReached() {
        return Model.LocalRotation == Model.TargetRotation;
    }

    private void DoLittleRotationTowardsTarget() {
        Model.LocalRotation = CalculateLittleRotationTowardsTarget();
        RotateView();
    }

    private Quaternion CalculateLittleRotationTowardsTarget() {
        return Quaternion.Slerp(Model.LocalRotation, Model.TargetRotation, Time.deltaTime);
    }

    private void RotateView() {
        View.transform.localRotation = Model.LocalRotation * Model.ZeroRotation;
    }
}