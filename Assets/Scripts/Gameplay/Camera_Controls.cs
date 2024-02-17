using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Camera_Controls : MonoBehaviour {

    private float inputX;
    private float inputY;

    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 15f;

    private float backupDuration = 2f;
    private Vector3 backupPositionOffset = new Vector3(0, 5, -10);
    private Vector3 backupRotation = new Vector3(45, 0, 0);
    private float cameraVerticalRotation = 0f;
    private bool isBackingUp = false;
    private float backupTimer = 0f;

    private bool lockedCursor = true;

    private IGameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameManager = ServiceLocator.Resolve<IGameManager>();
    }

    // Update is called once per frame
    void Update() {
        // Get the mouse input
        inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera around its local x axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        // Rotate the player around its y axis
        player.Rotate(Vector3.up * inputX);


        if (isBackingUp) {
            BackupCamera();
        }
    }


    public void TriggerCameraBackup() {
        isBackingUp = true;
        backupTimer = 0f;
    }

    private void BackupCamera() {
        backupTimer += Time.deltaTime;
        float fraction = backupTimer / backupDuration;

        // Interpolate position
        Vector3 targetPosition = player.position + backupPositionOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, fraction);

        // Interpolate rotation
        Quaternion targetRotation = Quaternion.Euler(backupRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, fraction);

        if (backupTimer >= backupDuration) {
            isBackingUp = false;
        }
    }

    private void BackUpCam() {
        TriggerCameraBackup();
    }
}
