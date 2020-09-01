using TMPro;
using UnityEngine;

public class MainMenuView : MenuElement {
    public TMP_Text header;

    private void Awake() {
        header.text = $"<color=#FFC000>Welcome to Christoffel symbol visualisation</color>\n<color=#9F9FDF><size=-30> v. {Application.version}</size></color>";
    }
}