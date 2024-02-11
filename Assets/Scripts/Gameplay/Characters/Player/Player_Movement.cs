using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cameraTransform;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 moveDirection = Vector3.zero;

        // Use local directions based on the camera's orientation
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; // Ensure the movement is only on the x-z plane
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        #region arrow keys

        if (Input.GetKey(KeyCode.LeftArrow)) { moveDirection -= right; }
        if (Input.GetKey(KeyCode.RightArrow)) { moveDirection += right; }
        if (Input.GetKey(KeyCode.UpArrow)) { moveDirection += forward; }
        if (Input.GetKey(KeyCode.DownArrow)) { moveDirection -= forward; }

        #endregion

        #region wasd keys

        if (Input.GetKey(KeyCode.A)) { moveDirection -= right; }
        if (Input.GetKey(KeyCode.D)) { moveDirection += right; }
        if (Input.GetKey(KeyCode.W)) { moveDirection += forward; }
        if (Input.GetKey(KeyCode.S)) { moveDirection -= forward; }

        #endregion

        // Normalize the moveDirection to ensure consistent speed in all directions
        moveDirection = moveDirection.normalized;

        // Calculate the speed value
        float speedValue = moveDirection.magnitude * speed;

        // Set the speed_f parameter in the Animator
        // animator.SetFloat("Speed_f", speedValue);

        if (moveDirection != Vector3.zero) {
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
