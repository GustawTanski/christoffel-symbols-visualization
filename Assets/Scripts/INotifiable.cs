public interface INotifiable {
    void OnNotification(ChristofellNotification notification, object target, params object[] data);
}