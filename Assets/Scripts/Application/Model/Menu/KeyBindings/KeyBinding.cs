public class KeyBinding {
    public string Key { get; protected set; }
    public string CommandName { get; set; }

    public KeyBinding(string key, string commandName = "") {
        Key = key;
        CommandName = commandName;
    }

    public KeyBinding(char key, string commandName = "") {
        Key = key.ToString();
        CommandName = commandName;
    }

    public virtual void SetKey(string key) {
        Key = key;
    }

    public virtual void SetKey(char key) {
        Key = key.ToString();
    }
}