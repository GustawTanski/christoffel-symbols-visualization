using System.Collections.Generic;
using System.Linq;

public class ToolsMenuController : ChristofellElement {
    public LineController line;

    public ToolsMenuView View => App.view.menu.toolsMenu;

    private void Awake() {
        App.cursorStateChanged.listOfHandlers += OnCursorStateChanged;
    }

    private void OnCursorStateChanged(object caller, CursorStateChangedEventArgs e) {
        View.SetCanvasActivity(e.isCursorActive);
    }

    private void Start() {
        InitializeToggle();
        InitializeDropdown();
        InitializeResetButton();
    }

    private void InitializeToggle() {
        SetZerosToggleState();
        SetZerosToggleListener();
    }

    private void SetZerosToggleState() {
        View.zerosToggle.isOn = App.model.cube.areZerosVisible;
    }

    private void SetZerosToggleListener() {
        View.zerosToggle.onValueChanged.AddListener(OnZerosToggleChange);
    }

    private void OnZerosToggleChange(bool _) {
        App.zerosHided.DispatchEvent(this, new ZerosHidedArgs());
    }

    private void InitializeDropdown() {
        PopulateDropdown();
        SetDropdownState();
        SetDropdownListener();
    }

    private void SetDropdownState() {
        View.dropdown.value = 0;
        OnSpaceDropdownChanged(View.dropdown.value);
    }

    private void PopulateDropdown() {
        List<string> names = App.model.cube.SpaceDictionaryNew.Keys.ToList();
        View.dropdown.AddOptions(names);
    }

    private void SetDropdownListener() {
        View.dropdown.onValueChanged.AddListener(OnSpaceDropdownChanged);
    }

    private void OnSpaceDropdownChanged(int value) {
        SpaceDropdownChangedArgs e = new SpaceDropdownChangedArgs(View.dropdown.options[value].text);
        App.spaceDropdownChanged.DispatchEvent(View.dropdown, e);
    }

    private void InitializeResetButton() {
        View.resetButton.onClick.AddListener(OnResetButtonPressed);
    }

    public void OnResetButtonPressed() {
        ResetButtonClickedArgs e = new ResetButtonClickedArgs();
        App.resetButtonClicked.DispatchEvent(View.resetButton, e);
    }

}