using UnityEngine;
using UnityEngine.EventSystems;

public class PopperShower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Popper popper;
    public string message;

    public void OnPointerEnter(PointerEventData eventData) {
        RectTransform rect = GetComponent<RectTransform>();
        Vector3 popperPosition = transform.localPosition - new Vector3(
            rect.pivot.x * rect.rect.width,
            -rect.pivot.y * rect.rect.height,
            0);
        popper.SetText(message);
        popper.Show(popperPosition);
    }

    public void OnPointerExit(PointerEventData eventData) {
        popper.Hide();
    }
}