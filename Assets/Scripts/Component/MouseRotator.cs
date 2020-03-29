using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class MouseRotator : MonoBehaviour {

    #region ROTATE

    public GameObject target;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    private bool _isRotating;

    #endregion

    void Update() {
        if (_isRotating) {

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            target.transform.Rotate(v, h, 0);

        }
    }

    void OnMouseDown() {
        _isRotating = true;
    }

    void OnMouseUp() {
        _isRotating = false;
    }

}