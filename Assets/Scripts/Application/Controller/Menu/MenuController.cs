public class MenuController : ChristoffelElement {
    public MainMenuController mainMenu;
    public GraphicsController graphics;
    public KeyBindingsController keyBindings;
    public MetricSelectionController metricSelection;

    public MenuElement[] menus;

    private MenuModel Model => App.model.menu;

    public void ChangeMenu(MenuElement newMenu) {
        App.menuChanged.DispatchEvent(this, new MenuChangedArgs(newMenu, Model.isMenuOn));
    }

    public void HideMenu() {
        App.menuChanged.DispatchEvent(this, new MenuChangedArgs(Model.currentMenu, false));
    }

    private void Awake() {
        App.menuChanged.listOfHandlers += OnMenuChanged;
    }

    private void OnMenuChanged(object caller, MenuChangedArgs e) {
        IfDistinctFromCurrentSwitchMenu(e.newMenu);
        SetMenuActive(e.isOn);
    }

    private void IfDistinctFromCurrentSwitchMenu(MenuElement newMenu) {
        if (IsDistintFromCurrentMenu(newMenu)) SwitchMenu(newMenu);
    }

    private bool IsDistintFromCurrentMenu(MenuElement newMenu) {
        return newMenu != Model.currentMenu;
    }

    private void SwitchMenu(MenuElement newMenu) {
        Model.currentMenu.gameObject.SetActive(false);
        Model.currentMenu = newMenu;
    }

    private void SetMenuActive(bool isOn) {
        Model.isMenuOn = isOn;
        Model.currentMenu.gameObject.SetActive(isOn);
    }

    private void Start() {
        DisactiveAllMenuScreens();
        IfMenuIsOnActivateCurrentScreen();
    }

    private void DisactiveAllMenuScreens() {
        foreach (MenuElement menu in menus) menu.gameObject.SetActive(false);
    }

    private void IfMenuIsOnActivateCurrentScreen() {
        if (Model.isMenuOn) Model.currentMenu.gameObject.SetActive(true);
    }

    private void Update() {
        if (WasMenuTogglePressed()) ToggleMenu();
    }

    private bool WasMenuTogglePressed() {
        return App.model.menu.keyBindings.MenuToggle.WasPressedThisFrame();
    }

    private void ToggleMenu() {
        App.menuChanged.DispatchEvent(this, new MenuChangedArgs(Model.currentMenu, !Model.isMenuOn));
    }
}