using UnityEngine;
using UnityEngine.InputSystem;
public class MenuController : ChristofellElement {
    public MainMenuController mainMenu;
    public ToolsMenuController toolsMenu;

    public MenuElement[] menus;

    private MenuModel Model => App.model.menu;

    public void ChangeMenu(MenuElement newMenu) {
        App.menuChanged.DispatchEvent(this, new MenuChangedArgs(newMenu, Model.isMenuOn));
    }

    private void Awake() {
        App.menuChanged.listOfHandlers += OnMenuChanged;
    }

    private void OnMenuChanged(object caller, MenuChangedArgs e) {
        if (e.newMenu != Model.currentMenu) {
            Model.currentMenu.gameObject.SetActive(false);
            Model.currentMenu = e.newMenu;
        }
        Model.isMenuOn = e.isOn;
        Model.currentMenu.gameObject.SetActive(e.isOn);
    }

    private void Start() {
        foreach (var menu in menus) menu.gameObject.SetActive(false);
        if (Model.isMenuOn) Model.currentMenu.gameObject.SetActive(true);
    }

    private void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            App.menuChanged.DispatchEvent(this, new MenuChangedArgs(Model.currentMenu, !Model.isMenuOn));
    }
}