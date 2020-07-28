using UnityEngine;
using UnityEngine.EventSystems;

public class PopperShower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Popper popper;
    public string message;

    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        SetMessageAsPopperText();
        MoveAndShowPopper();
    }

    private void SetMessageAsPopperText() {
        popper.SetText(message);
    }

    private void MoveAndShowPopper() {
        popper.MoveAndShow(CalculatePopperPosition());
    }

    private Vector3 CalculatePopperPosition() {
        Vector2 dist = GetPivotToLeftTopCornerTranslation();
        return transform.position - new Vector3(dist.x, dist.y, 0);
    }

    private Vector2 GetPivotToLeftTopCornerTranslation() {
        return new Vector2(rectTransform.pivot.x * rectTransform.rect.width, -rectTransform.pivot.y * rectTransform.rect.height);
    }

    public void OnPointerExit(PointerEventData eventData) {
        popper.Hide();
    }
}