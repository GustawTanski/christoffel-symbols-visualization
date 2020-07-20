using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
public partial class FlyingCameraController : ChristofellElement {

    public MiniCubeController miniCube;
    private TranslationCalculator translationCalculator;
    private RotationCalculator rotationCalculator;
    private FlyingCameraModel Model => App.model.flyingCamera;
    private FlyingCameraView View => App.view.flyingCamera;

    private void Awake() {
        Model.InitialPosition = View.transform.localPosition;
        SetListeners();
    }

    private void SetListeners() {
        App.menuChanged.listOfHandlers += OnMenuChanged;
        App.resetButtonClicked.listOfHandlers += OnResetButtonClicked;
    }

    private void OnMenuChanged(object caller, MenuChangedArgs e) {
        SetCameraActive(!e.isOn);
    }

    private void SetCameraActive(bool isCameraActive) {
        if (isCameraActive) ActivateCamera();
        else DisactivateCamera();
    }

    private void ActivateCamera() {
        DisactivateCursor();
        Model.isActive = true;
    }

    private void DisactivateCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DisactivateCamera() {
        ActivateCursor();
        Model.isActive = false;
    }

    private void ActivateCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnResetButtonClicked(object caller, ResetButtonClickedArgs e) {
        ResetRotation();
        ResetViewPosition();
    }

    private void ResetRotation() {
        ResetRotationData();
        ResetViewRotation();
    }

    private void ResetRotationData() {
        Model.FromXAxisAngle = 0;
        Model.FromYAxisAngle = 0;
    }

    private void ResetViewRotation() {
        View.RotateTo(Quaternion.identity);
    }

    private void ResetViewPosition() {
        View.TranslateTo(Model.InitialPosition);
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
        rotationCalculator = new RotationCalculator(Model);
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

}