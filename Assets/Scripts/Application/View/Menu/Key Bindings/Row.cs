using TMPro;
using UnityEngine;
public class Row : ChristofellElement {
    public TMP_Text command;
    public TMP_Text key;

    public string Command {
        get => command.text;
        set => command.SetText(value);
    }
    public string Key {
        get => key.text;
        set => key.SetText(value);
    }
}