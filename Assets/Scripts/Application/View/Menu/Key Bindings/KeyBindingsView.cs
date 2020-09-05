using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class KeyBindingsView : MenuElement {
    public GameObject content;
    public RowView rowPrefab;
    public GameObject popUp;
    public bool isAllowedToRebind;

    private KeyBindingsModel Model => App.model.menu.keyBindings;

    private List<RowView> rows = new List<RowView>();

    private void Start() {
        CreateRows();
    }

    private void CreateRows() {
        rows = Model.KeyBindings.Select(CreateRow).ToList();
    }

    private RowView CreateRow(KeyBinding binding) {
        RowView row = CreateEmptyRow();
        row.Command = binding.CommandName;
        row.Key = binding.DisplayKey;
        if (isAllowedToRebind) row.keyButton.onClick.AddListener(
            () => App.controller.menu.keyBindings.StartListeningForKeyAndRebind(binding));
        return row;
    }

    private RowView CreateEmptyRow() {
        return Instantiate(rowPrefab, content.transform);
    }

    public void UpdateBinding(KeyBinding binding) {
        if (rows.Count > 0)
            rows[GetIndexOfRowByBinding(binding)].Key = binding.DisplayKey;
    }

    public int GetIndexOfRowByBinding(KeyBinding binding) {
        return Model.KeyBindings.IndexOf(binding);
    }
}