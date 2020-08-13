using System;
public class MenuChangedArgs : EventArgs {
    public bool isOn;
    public MenuElement newMenu;

    public MenuChangedArgs(MenuElement newMenu, bool isOn = true) {
        this.newMenu = newMenu;
        this.isOn = isOn;
    }
}