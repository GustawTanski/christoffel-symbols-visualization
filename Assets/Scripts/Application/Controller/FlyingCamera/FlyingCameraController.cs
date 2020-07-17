using UnityEngine;
using UnityEngine.InputSystem;
public partial class FlyingCameraController : ChristofellElement {

    public MiniCubeController miniCube;
    public InputAction mouseDeltaAction;
    private TranslationCalculator translationCalculator;
    private RotationCalculator rotationCalculator;
    private FlyingCameraModel Model => App.model.flyingCamera;
    private FlyingCameraView View => App.view.flyingCamera;

    private void Awake() {
        App.menuChanged.listOfHandlers += OnMenuChanged;
    }

    private void OnMenuChanged(object caller, MenuChangedArgs e) {
        SetCameraActive(!e.isOn);
    }

    private void SetCameraActive(bool isCameraActive) {
        if (isCameraActive) ActivateCamera();
        else DisactivateCamera();
    }

    private void ActivateCamera() {
        Model.isActive = true;
        DisactivateCursor();
    }

    private void DisactivateCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DisactivateCamera() {
        Model.isActive = false;
        ActivateCursor();
    }

    private void ActivateCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Start() {
        InitializeTranslationCalculator();
        InitializeRotationCalculator();
        InitializeCamera();
    }

    private void InitializeTranslationCalculator() {
        translationCalculator = new TranslationCalculator(View, Model, App.model.menu.keyBindings);
    }

    private void InitializeRotationCalculator() {
        rotationCalculator = new RotationCalculator(Model, mouseDeltaAction);
    }

    private void InitializeCamera() {
        SetCameraActive(!App.model.menu.isMenuOn);
    }

    private void Update() {
        if (Model.isActive) RotateAndMove();
    }

    private void RotateAndMove() {
        Rotate();
        Move();
    }

    private void Rotate() {
        rotationCalculator.Calculate();
        View.RotateTo(rotationCalculator.Rotation);
    }

    private void Move() {
        translationCalculator.Calculate();
        View.Translate(translationCalculator.Translation);
    }

    private void OnEnable() {
        mouseDeltaAction.Enable();
    }

    private void OnDisable() {
        mouseDeltaAction.Disable();
    }
}