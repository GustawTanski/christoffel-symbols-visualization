using UnityEngine;
public class CubeElement : ChristofellElement {
    public DynamicSprite dynamicSpritePrefab;
    private DynamicSprite formula;
    private DynamicSprite index;
    private float distance;
    private Vector3 position;
    private Vector3 translation;

    public float Distance {
        get {
            return distance;
        }
        set {
            if (value <= 0) distance = 0;
            else distance = value;
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

    private void Start() {
        translation = Vector3.zero;
        position = transform.localPosition;
    }

    public void Initialize() {
        Distance = App.model.cube.distance;
        formula = Instantiate(dynamicSpritePrefab, transform);
        formula.LocalPosition = new Vector3(0.5f, 0.5f, -0.5f) * Distance;
        index = Instantiate(dynamicSpritePrefab, transform);
        index.LocalPosition = new Vector3(0.5f, 0.75f, -0.5f) * Distance;
        index.ToggleAppear();
    }

    public void Update() {
        transform.rotation = Camera.main.transform.rotation;
    }

    public void ToggleIndex() {
        index.ToggleAppear();
    }

    public void ToggleAppear() {
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
}