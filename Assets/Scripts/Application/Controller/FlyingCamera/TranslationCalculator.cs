using UnityEngine;
using UnityEngine.InputSystem;
public class TranslationCalculator {
    public Vector3 Translation {
        get;
        private set;
    }

    private InputAction moveAction;
    private FlyingCameraView view;
    private FlyingCameraModel model;

    public TranslationCalculator(FlyingCameraView view, FlyingCameraModel model, InputAction moveAction) {
        this.view = view;
        this.model = model;
        this.moveAction = moveAction;
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
        return view.transform.forward * moveAction.ReadValue<Vector2>().y;
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
        return view.transform.right * moveAction.ReadValue<Vector2>().x;
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