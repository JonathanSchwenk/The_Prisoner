using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour, IDoorManager
{
    public GameObject selectedDoor {get; set;}

    // need public for canOpenDoor so you can only press one door

    [SerializeField] private Camera mainDoorCamera;
    [SerializeField] private Camera leftDoorCamera;
    [SerializeField] private Camera rightDoorCamera;
    [SerializeField] private Camera centerDoorCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Checks for a left mouse button click
        {
            Ray ray = mainDoorCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                selectedDoor = hit.collider.gameObject; 
                // print(selectedDoor);
                if (selectedDoor.GetComponent<DoorController>() != null) {
                    selectedDoor.GetComponent<DoorController>().openingDoor = true;
                    selectedDoor.GetComponent<DoorController>().StopDoors();

                    if (selectedDoor.name == "LeftDoor") {
                        leftDoorCamera.gameObject.SetActive(true);
                        mainDoorCamera.gameObject.SetActive(false);
                    } else if (selectedDoor.name == "RightDoor") {
                        rightDoorCamera.gameObject.SetActive(true);
                        mainDoorCamera.gameObject.SetActive(false);
                    } else if (selectedDoor.name == "CenterDoor") {
                        centerDoorCamera.gameObject.SetActive(true);
                        mainDoorCamera.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
