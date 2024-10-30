using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform body;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    float rotationX;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float verticalInput = -Input.GetAxis("Mouse Y") * verticalSensitivity;

        Vector3 bodyRotation = new Vector3(0f, horizontalInput, 0f);
        body.Rotate(bodyRotation);

        rotationX += verticalInput;

        if (rotationX < -90f)
        {
            rotationX = -90f;
            return;
        }

        else if (rotationX > 90f)
        {
            rotationX = 90f;
            return;
        }

        Vector3 rotation = new Vector3(verticalInput, 0f, 0f);
        transform.Rotate(rotation);
    }
}
