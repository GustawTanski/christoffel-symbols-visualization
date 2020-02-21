using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;

    public void Notify(ChristofellNotification notification, object target, params object[] data) {
        foreach (INotifiable controller in GetControllers()) {
            controller.OnNotification(notification, target, data);
        };
    }

    private INotifiable[] GetControllers() {
        return new INotifiable[] {
            controller,
            controller.cube,
            controller.UI
        };
    }
}