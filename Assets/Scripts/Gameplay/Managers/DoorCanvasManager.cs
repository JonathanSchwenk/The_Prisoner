using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class DoorCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject preOpenDoors;
    [SerializeField] private GameObject openFirstDoor;
    [SerializeField] private GameObject openSecondDoor;

    
    private IDoorManager doorManager;

    // Start is called before the first frame update
    void Start()
    {
        doorManager = ServiceLocator.Resolve<IDoorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Select button
    // Want to take in the selected door and then do something with the item inside
    public void SelectButton() {
        doorManager.chosenObject = doorManager.doorContents[doorManager.selectedDoorIndex];
        doorManager.canOpenDoor = false;
    }

    // Choose again button
    public void ChooseAgainButton() {
        doorManager.canOpenDoor = true;
    }

}
