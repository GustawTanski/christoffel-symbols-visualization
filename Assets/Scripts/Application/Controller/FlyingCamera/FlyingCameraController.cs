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

    private void Start() {
        InitializeTranslationCalculator();
        InitializeRotationCalculator();
        // HideAndLockCursor();
        DispatchCursorStateChangedEvent();
    }

    private void DispatchCursorStateChangedEvent() {
        App.cursorStateChanged.DispatchEvent(this, new CursorStateChangedEventArgs(IsCursorActive()));
    }

    private bool IsCursorActive() {
        return !Model.isActive;
    }

    private void InitializeTranslationCalculator() {
        translationCalculator = new TranslationCalculator(View, Model, verticalAction, horizontalAction);
    }

    private void InitializeRotationCalculator() {
        rotationCalculator = new RotationCalculator(Model, mouseDeltaAction);
    }

    private void HideAndLockCursor() {
        HideCursor();
        LockCursor();
    }

    private void HideCursor() {
        Cursor.visible = false;
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if (Model.isActive) RotateAndMove();
        if (Keyboard.current.escapeKey.wasPressedThisFrame) ToggleCursorAndActivityState();
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

    private void ToggleCursorAndActivityState() {
        ToggleCursor();
        ToggleActivityState();
        DispatchCursorStateChangedEvent();
    }

    private void ToggleCursor() {
        if (IsCursorLocked()) FreeAndShowCursor();
        else HideAndLockCursor();
    }

    private bool IsCursorLocked() {
        return Cursor.lockState == CursorLockMode.Locked;
    }

    private void FreeAndShowCursor() {
        FreeCursor();
        ShowCursor();
    }

    private void FreeCursor() {
        Cursor.lockState = CursorLockMode.None;
    }

    private void ShowCursor() {
        Cursor.visible = true;
    }

    private void ToggleActivityState() {
        Model.isActive = !Model.isActive;
    }

    private void OnEnable() {
        mouseDeltaAction.Enable();
        verticalAction.Enable();
        horizontalAction.Enable();
    }

    private void OnDisable() {
        mouseDeltaAction.Disable();
        horizontalAction.Enable();
    }
}