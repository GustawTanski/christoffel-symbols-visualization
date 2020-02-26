using UnityEngine;
public class CubeElement : ChristofellElement {
    public DynamicSprite dynamicSpritePrefab;
    private GameObject spriteContainer;
    private DynamicSprite formula;
    private DynamicSprite index;
    private Vector3 position = Vector3.zero;
    private Vector3 translation = Vector3.zero;

    private float Size {
        get {
            return App.model.cube.elementSize;
        }
    }

    public Texture2D IndexTexture {
        set {
            index.SetTexture(value);
        }
    }

    public Texture2D FormulaTexture {
        set {
            formula.SetTexture(value);
        }
    }

    public Vector3 LocalPosition {
        get {
            return position;
        }
        set {
            position = value;
            transform.localPosition = value + translation;
        }
    }

    public Vector3 Translation {
        get {
            return translation;
        }

        set {
            translation = value;
            transform.localPosition = value + position;
        }
    }

    private void Awake() {
        InitializeSpriteContainer();
        InitializeBoxCollider();
        InitializeFormula();
        InitializeIndex();
    }

    private void InitializeSpriteContainer() {
        spriteContainer = new GameObject();
        spriteContainer.name = "Sprite Container";
        spriteContainer.transform.SetParent(transform);
        spriteContainer.transform.localPosition = Vector3.zero;
    }

    private void InitializeBoxCollider() {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = Vector3.one * Size;
        collider.center = GetMiddlePosition();
    }

    private Vector3 GetMiddlePosition() {
        return Vector3.zero;
    }

    private void InitializeFormula() {
        formula = Instantiate(dynamicSpritePrefab, spriteContainer.transform);
        formula.name = "Formula Sprite";
        formula.LocalPosition = GetMiddlePosition();
    }

    private void InitializeIndex() {
        index = Instantiate(dynamicSpritePrefab, spriteContainer.transform);
        index.name = "Index Sprite";
        index.LocalPosition = GetIndexPosition();
        index.Disappear();
    }

    private Vector3 GetIndexPosition() {
        return GetMiddlePosition() + GetIndexTranslation();
    }

    private Vector3 GetIndexTranslation() {
        return new Vector3(0, 0.25f, 0) * Size;
    }

    public void Update() {
        spriteContainer.transform.rotation = Camera.main.transform.rotation;
    }

    public void ToggleIndex() {
        index.ToggleAppear();
    }

    public void ToggleVisibility() {
        if (IsVisible()) Disappear();
        else Appear();
    }

    public void Appear() {
        transform.localScale = Vector3.one;
    }

    public void Disappear() {
        transform.localScale = Vector3.zero;
    }

    private bool IsVisible() {
        return transform.localScale == Vector3.one;
    }

    public void SetFormulaColor(Color color) {
        formula.GetComponent<SpriteRenderer>().color = color;
    }

}