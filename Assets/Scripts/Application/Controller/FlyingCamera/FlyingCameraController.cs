using UnityEngine;
public partial class FlyingCameraController : ChristofellElement {

    public MiniCubeController miniCube;
    private TranslationCalculator translationCalculator;
    private RotationCalculator rotationCalculator;
    private FlyingCameraModel Model => App.model.flyingCamera;
    private FlyingCameraView View => App.view.flyingCamera;

    private void Start() {
        InitializeTranslationCalculator();
        InitializeRotationCalculator();
        HideAndLockCursor();
        DispatchCursorStateChangedEvent();
    }

    private void DispatchCursorStateChangedEvent() {
        App.cursorStateChanged.DispatchEvent(this, new CursorStateChangedEventArgs(IsCursorActive()));
    }

    private bool IsCursorActive() {
        return !Model.IsActive;
    }

    private void InitializeTranslationCalculator() {
        translationCalculator = new TranslationCalculator(View, Model);
    }

    private void InitializeRotationCalculator() {
        rotationCalculator = new RotationCalculator(Model);
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
        if (Model.IsActive) RotateAndMove();
        if (Input.GetKeyDown(KeyCode.Escape)) ToggleCursorAndActivityState();
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
        Model.IsActive = !Model.IsActive;
    }
}