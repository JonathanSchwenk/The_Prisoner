using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour
{

    private float inputX;
    private float inputY;

    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 15f;
    private float cameraVerticalRotation = 0f;

    private bool lockedCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse input
        inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera around its local x axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        // Rotate the player around its y axis
        player.Rotate(Vector3.up * inputX);
    }
}
