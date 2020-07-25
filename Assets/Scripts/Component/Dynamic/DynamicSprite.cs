using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class DynamicSprite : MonoBehaviour {

    public int dimensionLimit = int.MaxValue;

    public Vector3 LocalPosition {
        get {
            return transform.localPosition;
        }
        set {
            transform.localPosition = value;
        }
    }

    private const int PIXELS_PER_UNIT = 100;
    private const float ADDITIONAL_SCALING_FACTOR = 0.95f;
    private Texture2D texture;
    private Vector3 initialScale;

    private void Awake() {
        InitializeScale();
    }

    private void InitializeScale() {
        initialScale = transform.localScale;
    }

    public void SetTexture(Texture2D texture) {
        this.texture = texture;
        SetSprite();
        ScaleSpriteIfOutOfTheLimit();
    }

    private void SetSprite() {
        GetComponent<SpriteRenderer>().sprite = SpriteCreator.Create(texture, PIXELS_PER_UNIT);
    }

    private void ScaleSpriteIfOutOfTheLimit() {

        if (IsSpriteOutOfTheLimit()) ScaleSpriteToFit();
        else ResetScale();
    }

    private bool IsSpriteOutOfTheLimit() {
        return GetBiggerDimension() > dimensionLimit;
    }

    private float GetBiggerDimension() {
        return (float) (texture.width > texture.height ? texture.width : texture.height) / PIXELS_PER_UNIT;
    }

    private void ScaleSpriteToFit() {
        transform.localScale = CalculateScaleToFit();
    }

    private Vector3 CalculateScaleToFit() {
        return initialScale * ((float) dimensionLimit / GetBiggerDimension()) * ADDITIONAL_SCALING_FACTOR;
    }

    private void ResetScale() {
        transform.localScale = initialScale;
    }

    public void ToggleAppear() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void Appear() {
        if (!gameObject.activeInHierarchy) {
            gameObject.SetActive(true);
        }
    }

    public void Disappear() {
        if (gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
        }
    }
}