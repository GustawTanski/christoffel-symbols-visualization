public class MainMenuController : ChristofellElement {
    private MainMenuView View => App.view.menu.mainMenu;

    private void Awake() {
        App.cursorStateChanged.listOfHandlers += OnCursorStateChanged;
    }

    private void OnCursorStateChanged(object caller, CursorStateChangedEventArgs e) {
        
    }
}