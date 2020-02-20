using UnityEngine;

public class ChristofellElement : MonoBehaviour {
    public ChristofellApplication App {
        get {
            return GameObject.FindObjectOfType<ChristofellApplication>();
        }
    }
}