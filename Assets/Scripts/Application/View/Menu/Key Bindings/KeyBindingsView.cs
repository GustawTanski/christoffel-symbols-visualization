using UnityEngine;
public class KeyBindingsView : ChristofellElement {
    public GameObject content;
    public Row rowPrefab;
    private KeyBindingsModel Model => App.model.menu.keyBindings;

    private void Start() {
        Model.KeyBindings.ForEach(binding => {
            var row = Instantiate(rowPrefab, content.transform);
            row.Command = binding.CommandName;
            row.Key = binding.Key;
        });
    }
}