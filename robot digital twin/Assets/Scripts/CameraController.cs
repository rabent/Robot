using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Robot;
    public float rotationSpeed = 50f;
    public float zoomSpeed = 20f;
    

    void Update()
    {
        HandleRotation();
        HandlePan();
        HandleZoom();
    }

    bool isMain() {
        if(Input.mousePosition.x>1430) return false;
        return true;
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1)&&isMain()) 
        {
            float xRotate = Input.GetAxis("Mouse X") * rotationSpeed;
            float yRotate = Input.GetAxis("Mouse Y") * rotationSpeed;

            Vector3 stagePosition = Robot.transform.position;

            transform.RotateAround(stagePosition, Vector3.right, -yRotate);
            transform.RotateAround(stagePosition, Vector3.up, xRotate);

            transform.LookAt(stagePosition);
        }
    }

    void HandlePan()
    {
        if(Input.GetMouseButtonDown(0)&&isMain()) {
            transform.LookAt(Robot.transform.position);
        }
        if (Input.GetMouseButton(0)&&isMain())
        {
            transform.Translate(-Input.GetAxis("Mouse X")/10, Input.GetAxis("Mouse Y")/10,0);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Camera.main.fieldOfView+=(zoomSpeed*scroll);
            if(Camera.main.fieldOfView<10) Camera.main.fieldOfView=10;
            else if(Camera.main.fieldOfView>50) Camera.main.fieldOfView=50;
        }
    }
}
