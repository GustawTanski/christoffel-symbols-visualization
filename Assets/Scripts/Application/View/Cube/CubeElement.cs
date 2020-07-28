using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CubeElement : ChristoffelElement {
    public Material invisibleMaterial;
    public Material visibleMaterial;
    public DynamicSprite dynamicSpritePrefab;
    private GameObject spriteContainer;
    private DynamicSprite formula;
    private DynamicSprite index;
    private Vector3 position = Vector3.zero;
    private Vector3 translation = Vector3.zero;

    private float Size => App.model.cube.elementSize;

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
        IfThereAreDeleteSpriteContainerChildren();
        InitializeSpriteContainer();
        InitializeFormula();
        InitializeIndex();
    }

    private void IfThereAreDeleteSpriteContainerChildren() {
        Transform[] children = GetComponentsInChildren<Transform>();
        children
            .Where(child => child.name == "Sprite Container")
            .ToList()
            .ForEach(child => Destroy(child.gameObject));
    }

    private void InitializeSpriteContainer() {
        spriteContainer = new GameObject();
        spriteContainer.name = "Sprite Container";
        spriteContainer.transform.SetParent(transform);
        spriteContainer.transform.localPosition = GetMiddlePosition();
        spriteContainer.AddComponent<CameraFacer>();
    }

    private Vector3 GetMiddlePosition() {
        return new Vector3(1, 1, -1) * Size * 0.5f;
    }

    private void InitializeFormula() {
        formula = Instantiate(dynamicSpritePrefab, spriteContainer.transform);
        formula.name = "Formula Sprite";
        formula.LocalPosition = GetFormulaTranslation();
    }

    private Vector3 GetFormulaTranslation() {
        return Vector3.zero;
    }

    private void InitializeIndex() {
        index = Instantiate(dynamicSpritePrefab, spriteContainer.transform);
        index.name = "Index Sprite";
        index.LocalPosition = GetIndexTranslation();
        index.Disappear();
    }
    private Vector3 GetIndexTranslation() {
        return new Vector3(0, 0.25f, 0) * Size;
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

    public void Select() {
        GetComponent<MeshRenderer>().material = visibleMaterial;
    }

    public void Deselect() {
        GetComponent<MeshRenderer>().material = invisibleMaterial;
    }

    public void ScaleTo(float scale) {
        spriteContainer.transform.localScale = Vector3.one * scale;
    }

}