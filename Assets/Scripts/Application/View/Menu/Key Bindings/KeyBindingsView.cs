using System.Collections.Generic;
using UnityEngine;
public class KeyBindingsView : MenuElement {
    public GameObject content;
    public RowView rowPrefab;
    private KeyBindingsModel Model => App.model.menu.keyBindings;

    private List<RowView> rows = new List<RowView>();

    private void Start() {
        Model.KeyBindings.ForEach(binding => {
            RowView row = Instantiate(rowPrefab, content.transform);
            rows.Add(row);
            row.Command = binding.CommandName;
            row.Key = binding.DisplayKey;
            row.keyButton.onClick.AddListener(() => App.controller.menu.keyBindings.Pies(binding));
        });
    }

    public void UpdateBinding(KeyBinding binding) {
        rows[Model.KeyBindings.IndexOf(binding)].Key = binding.DisplayKey;
    }
}