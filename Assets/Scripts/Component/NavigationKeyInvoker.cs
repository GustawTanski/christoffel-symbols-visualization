using UnityEngine.EventSystems;
public class NavigationKeyInvoker : ChristoffelElement, IPointerDownHandler, IPointerUpHandler {
    private ToolsController Tools => App.controller.tools;

    public void OnPointerDown(PointerEventData eventData) {
        Tools.SetNavigationKeysVisible(true);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Tools.SetNavigationKeysVisible(false);
    }
}