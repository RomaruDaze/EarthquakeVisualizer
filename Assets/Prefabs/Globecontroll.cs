using UnityEngine;

public class GlobeControll : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // 回転の感度
    private Vector3 _lastMousePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _lastMousePos;
            float rotX = -delta.y * rotationSpeed * Time.deltaTime;
            float rotY = delta.x * rotationSpeed * Time.deltaTime;

            // マウスの動きに応じて地球を回転
            transform.Rotate(Vector3.up, rotY, Space.World);
            transform.Rotate(Vector3.right, rotX, Space.World);

            _lastMousePos = Input.mousePosition;
        }
    }
}