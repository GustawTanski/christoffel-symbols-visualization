using UnityEngine;

public class ChristoffelElement : MonoBehaviour {
    protected ChristoffelApplication App {
        get {
            return GameObject.FindObjectOfType<ChristoffelApplication>();
        }
    }
}

public class MenuElement : ChristoffelElement {}