using UnityEngine;
using UnityEngine.InputSystem;
public partial class FlyingCameraController : ChristofellElement {

    public MiniCubeController miniCube;
    public InputAction mouseDeltaAction;
    public InputAction verticalAction;
    public InputAction horizontalAction;
    private TranslationCalculator translationCalculator;
    private RotationCalculator rotationCalculator;
    private FlyingCameraModel Model => App.model.flyingCamera;
    private FlyingCameraView View => App.view.flyingCamera;

    private void Awake() {
        App.menuChanged.listOfHandlers += OnMenuChanged;
    }

    private void OnMenuChanged(object caller, MenuChangedArgs e) {
        if (e.isOn) FreeAndShowCursor();
        else HideAndLockCursor();
    }

    private void FreeAndShowCursor() {
        Model.isActive = false;
        FreeCursor();
        ShowCursor();
    }

    private void FreeCursor() {
        Cursor.lockState = CursorLockMode.None;
    }

    private void ShowCursor() {
        Cursor.visible = true;
    }

    private void HideAndLockCursor() {
        Model.isActive = true;
        HideCursor();
        LockCursor();
    }

    private void HideCursor() {
        Cursor.visible = false;
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start() {
        InitializeTranslationCalculator();
        InitializeRotationCalculator();
        Model.isActive = !App.model.menu.isMenuOn;
        if (Model.isActive) HideAndLockCursor();
    }

    private void InitializeTranslationCalculator() {
        translationCalculator = new TranslationCalculator(View, Model, verticalAction, horizontalAction);
    }

    private void InitializeRotationCalculator() {
        rotationCalculator = new RotationCalculator(Model, mouseDeltaAction);
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
        verticalAction.Enable();
        horizontalAction.Enable();
    }

    private void OnDisable() {
        mouseDeltaAction.Disable();
        verticalAction.Disable();
        horizontalAction.Disable();
    }
}