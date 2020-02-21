public class ChristofellController : ChristofellElement, INotifiable {
    public CubeController cube;
    public UIController UI;
    public void OnNotification(ChristofellNotification notification, object target, params object[] data) {}

}