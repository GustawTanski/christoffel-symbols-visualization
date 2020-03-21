using UnityEngine;
public partial class FlyingCameraController : ChristofellElement {

    public TranslationCalculator translationCalculator;
    public RotationCalculator rotationCalculator;
    private FlyingCameraModel Model {
        get {
            return App.model.flyingCamera;
        }
    }

    private FlyingCameraView View {
        get {
            return App.view.flyingCamera;
        }
    }
    private void Start() {
        InitializeTranslationCalculator();
        InitializeRotationCalculator();
        HideAndLockCursor();
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
        rotationCalculator.CalculateRotation();
        View.RotateTo(rotationCalculator.Rotation);
    }

    private void Move() {
        translationCalculator.CalculateTranslation();
        View.Translate(translationCalculator.Translation);
    }

    private void ToggleCursorAndActivityState() {
        ToggleCursor();
        ToggleActivityState();
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