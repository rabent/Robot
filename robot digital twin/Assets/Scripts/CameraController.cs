using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float panSpeed = 0.5f;
    public float zoomSpeed = 300.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 50.0f;

    private Vector3 lastMousePosition;

    void Update()
    {
        HandleRotation();
        HandlePan();
        HandleZoom();
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // 오른쪽 마우스 버튼
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationX = delta.x * rotationSpeed * Time.deltaTime;
            float rotationY = -delta.y * rotationSpeed * Time.deltaTime;
            
            transform.eulerAngles += new Vector3(rotationY, rotationX, 0);
        }
        lastMousePosition = Input.mousePosition;
    }

    void HandlePan()
    {
        if (Input.GetMouseButton(0)) // 가운데 마우스 버튼 (휠 클릭)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x * panSpeed * Time.deltaTime, -delta.y * panSpeed * Time.deltaTime, 0);
            transform.Translate(move, Space.Self);
        }
        lastMousePosition = Input.mousePosition;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Vector3 direction = transform.forward * scroll * zoomSpeed * Time.deltaTime;
            transform.position += direction;

            // 줌 제한 적용
            float distance = Vector3.Distance(transform.position, Vector3.zero);
            if (distance < minZoom)
            {
                transform.position -= direction;
            }
            else if (distance > maxZoom)
            {
                transform.position -= direction;
            }
        }
    }
}
