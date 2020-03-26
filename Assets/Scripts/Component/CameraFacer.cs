using UnityEngine;

public class CameraFacer : MonoBehaviour {
    public void Update() {
        transform.rotation = Camera.main.transform.rotation;
    }
}