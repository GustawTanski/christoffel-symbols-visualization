using TMPro;
using UnityEngine.UI;
public class RowView : ChristoffelElement {
    public TMP_Text command;
    public TMP_Text key;
    public Button keyButton;
    
    public string Command {
        get => command.text;
        set => command.SetText(value);
    }
    public string Key {
        get => key.text;
        set => key.SetText(value);
    }
}