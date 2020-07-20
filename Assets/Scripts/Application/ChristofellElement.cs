using UnityEngine;

public class ChristofellElement : MonoBehaviour {
    protected ChristofellApplication App {
        get {
            return GameObject.FindObjectOfType<ChristofellApplication>();
        }
    }
}

public class MenuElement : ChristofellElement {}