using UnityEngine.EventSystems;

public class MenuOnClickToggler : ChristoffelElement, IPointerClickHandler {

    private MenuModel MenuModel => App.model.menu;
    public void OnPointerClick(PointerEventData pointerEventData) {
        App.menuChanged.DispatchEvent(this, new MenuChangedArgs(MenuModel.currentMenu, !MenuModel.isMenuOn));
    }
}