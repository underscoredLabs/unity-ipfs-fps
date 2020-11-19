using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorSystem_Player : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    private CharacterController characterController;
    private float cameraVerticalAngle;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    private void Update() 
    {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw(GameConstants.k_AxisNameHorizontal), 0f, Input.GetAxisRaw(GameConstants.k_AxisNameVertical));

        // Constrain move input to a maximum magnitude of 1, otherwise diagonal movement might exceed the max move speed defined
        moveVector = Vector3.ClampMagnitude(moveVector, 1);
        moveVector = transform.TransformVector(moveVector);

        float moveSpeed = 10f;
        characterController.Move(moveVector * moveSpeed * Time.deltaTime);



        float rotationSpeed = 1f;
        // Horizontal character rotation
        {
            // Rotate the transform with the input speed around its local Y axis
            transform.Rotate(new Vector3(0f, (Input.GetAxisRaw("Mouse X") * rotationSpeed), 0f), Space.Self);
        }

        // Vertical camera rotation
        {
            // Add vertical inputs to the camera's vertical angle
            cameraVerticalAngle += Input.GetAxisRaw("Mouse Y") * rotationSpeed;

            // Limit the camera's vertical angle to min/max
            cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);

            // Apply the vertical angle as a local rotation to the camera transform along its right axis (makes it pivot up and down)
            playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
        }
    }

}
