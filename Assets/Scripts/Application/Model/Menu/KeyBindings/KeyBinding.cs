public class KeyBinding {
    public string Key { get; protected set; }

    public KeyBinding(string key) {
        Key = key;
    }

    public KeyBinding(char key) {
        Key = key.ToString();
    }

    public virtual void SetKey(string key) {
        Key = key;
    }

    public virtual void SetKey(char key) {
        Key = key.ToString();
    }
}