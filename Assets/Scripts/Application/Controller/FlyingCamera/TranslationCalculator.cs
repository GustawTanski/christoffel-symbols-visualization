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
    private KeyBindingsModel keyBindings;

    public TranslationCalculator(FlyingCameraView view, FlyingCameraModel model, KeyBindingsModel keyBindings, InputAction moveAction) {
        this.view = view;
        this.model = model;
        this.keyBindings = keyBindings;
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
        if (IsAccelerationKeyPressed()) return model.fastMoveFactor;
        if (IsDecelerationKeyPressed()) return model.slowMoveFactor;
        return 1f;
    }

    private Vector3 GetHorizontalTranslation() {
        return GetHorizontalTranslationVector() * GetScaledTranslationBase();
    }

    private Vector3 GetHorizontalTranslationVector() {
        return view.transform.right * moveAction.ReadValue<Vector2>().x;
    }

    private bool IsAccelerationKeyPressed() {
        return keyBindings.Accelerate.KeyControl.isPressed;
    }

    private bool IsDecelerationKeyPressed() {
        return keyBindings.Decelerate.KeyControl.isPressed;
    }

    private Vector3 GetVerticalTranslation() {
        if (AreBothUpAndDownKeysPressed()) return Vector3.zero;
        if (IsUpKeyPressed()) return GetVerticalTranslationVector() * GetScaledTranslationBase();
        if (IsDownKeyPressed()) return -GetVerticalTranslationVector() * GetScaledTranslationBase();
        return Vector3.zero;
    }

    private bool AreBothUpAndDownKeysPressed() {
        return IsUpKeyPressed() && IsDownKeyPressed();
    }

    private bool IsUpKeyPressed() {
        return keyBindings.Up.KeyControl.isPressed;
    }

    private bool IsDownKeyPressed() {
        return keyBindings.Down.KeyControl.isPressed;
    }

    private Vector3 GetVerticalTranslationVector() {
        return view.transform.up;
    }

}