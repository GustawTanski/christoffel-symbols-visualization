using UnityEngine;
using UnityEngine.InputSystem;
public class TranslationCalculator {
    public Vector3 Translation {
        get;
        private set;
    }

    private InputAction verticalAction;
    private InputAction horizontalAction;
    private FlyingCameraView view;
    private FlyingCameraModel model;

    public TranslationCalculator(FlyingCameraView view, FlyingCameraModel model, InputAction verticalAction, InputAction horizontalAction) {
        this.view = view;
        this.model = model;
        this.verticalAction = verticalAction;
        this.horizontalAction = horizontalAction;
    }

    public void Calculate() {
        Translation = Vector3.zero;
        Translation += GetForwardTranslation();
        Translation += GetHorizontalTranslation();
        Translation += GetVerticalTranslation();
    }

    private Vector3 GetForwardTranslation() {
        return GetForwardTranslationVector() * GetScaledTranslationBase();
    }

    private Vector3 GetForwardTranslationVector() {
        return view.transform.forward * verticalAction.ReadValue<float>();
    }

    private float GetScaledTranslationBase() {
        return GetTranslationBase() * GetScalingFactor();
    }

    private float GetTranslationBase() {
        return Time.deltaTime * model.normalMoveSpeed;
    }

    private float GetScalingFactor() {
        if (IsShiftPressed()) return model.fastMoveFactor;
        if (IsControlPressed()) return model.slowMoveFactor;
        return 1f;
    }

    private Vector3 GetHorizontalTranslation() {
        return GetHorizontalTranslationVector() * GetScaledTranslationBase();
    }

    private Vector3 GetHorizontalTranslationVector() {
        return view.transform.right * horizontalAction.ReadValue<float>();
    }

    private bool IsShiftPressed() {
        return Keyboard.current.shiftKey.isPressed;
    }

    private bool IsControlPressed() {
        return Keyboard.current.ctrlKey.isPressed;
    }

    private Vector3 GetVerticalTranslation() {
        if (IsKeyPressed("Q") && IsKeyPressed("E")) return Vector3.zero;
        if (IsKeyPressed("Q")) return GetVerticalTranslationVector() * GetScaledTranslationBase();
        if (IsKeyPressed("E")) return -GetVerticalTranslationVector() * GetScaledTranslationBase();
        return Vector3.zero;
    }

    private bool IsKeyPressed(string key) {
        return Keyboard.current[key].IsPressed();
    }

    private Vector3 GetVerticalTranslationVector() {
        return view.transform.up;
    }

}