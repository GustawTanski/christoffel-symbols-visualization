using UnityEngine;
public class TranslationCalculator {
    public Vector3 Translation{
        get;
        private set;
    }
    private FlyingCameraView view;
    private FlyingCameraModel model;

    public TranslationCalculator( FlyingCameraView view, FlyingCameraModel model) {
        this.view = view;
        this.model = model;
    }

    public void CalculateTranslation() {
        Translation = Vector3.zero;
        Translation += GetForwardTranslation();
        Translation += GetHorizontalTranslation();
        Translation += GetVerticalTranslation();
    }

    private Vector3 GetForwardTranslation() {
        return GetForwardTranslationVector() * GetScaledTranslationBase();
    }

    private Vector3 GetForwardTranslationVector() {
        return view.transform.forward * Input.GetAxis("Vertical");
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
        return view.transform.right * Input.GetAxis("Horizontal");
    }

    private bool IsShiftPressed() {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    private bool IsControlPressed() {
        return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
    }

    private Vector3 GetVerticalTranslation() {
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) return Vector3.zero;
        if (Input.GetKey(KeyCode.Q)) return GetVerticalTranslationVector() * GetScaledTranslationBase();
        if (Input.GetKey(KeyCode.E)) return -GetVerticalTranslationVector() * GetScaledTranslationBase();
        return Vector3.zero;
    }

    private Vector3 GetVerticalTranslationVector() {
        return view.transform.up;
    }

}