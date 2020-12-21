using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    public GameObject playerObject;
    public Vector2 rotationSpeed;
    public bool reverse;

    private Camera mainCamera;
    private Vector2 lastMousePosition;
    private Vector3 lastTargetPosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mainCamera.transform.position += playerObject.transform.position - lastTargetPosition;
        lastTargetPosition = playerObject.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var x = (lastMousePosition.x - Input.mousePosition.x);
                var y = (Input.mousePosition.y - lastMousePosition.y);

                if (Mathf.Abs(x) < Mathf.Abs(y))
                    x = 0;
                else
                    y = 0;

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, newAngle.x);
                mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, newAngle.y);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (Input.mousePosition.x - lastMousePosition.x);
                var y = (lastMousePosition.y - Input.mousePosition.y);

                if (Mathf.Abs(x) < Mathf.Abs(y))
                    x = 0;
                else
                    y = 0;

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, newAngle.x);
                mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, newAngle.y);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
