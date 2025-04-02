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
        if (Input.GetMouseButton(1)) 
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
        if (Input.GetMouseButton(0))
        {
            transform.Translate(-Input.GetAxis("Mouse X")/10, Input.GetAxis("Mouse Y")/10,0);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Camera.main.fieldOfView+=(20*scroll);
            if(Camera.main.fieldOfView<10) Camera.main.fieldOfView=10;
            else if(Camera.main.fieldOfView>50) Camera.main.fieldOfView=50;
        }
    }
}
