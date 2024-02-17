using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class DoorController : MonoBehaviour
{

    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public bool openingDoor = false;

    private Vector3 leftDoorPos;
    private Vector3 rightDoorPos;

    private IAudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        leftDoorPos = leftDoor.transform.position;
        rightDoorPos = rightDoor.transform.position;

        audioManager = ServiceLocator.Resolve<IAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openingDoor) {
            OpenDoor();
        }
    }

    public void OpenDoor() {
        leftDoor.transform.position += new Vector3(0.6f * Time.deltaTime, 0, 0);
        rightDoor.transform.position += new Vector3(-0.6f * Time.deltaTime, 0, 0);
    }

    public void StopDoors() {
        StartCoroutine(MoveDoors(3.5f));
    }

    public void CloseDoors() {
        leftDoor.transform.position = leftDoorPos;
        rightDoor.transform.position = rightDoorPos;
    }

    IEnumerator MoveDoors(float time) {
        yield return new WaitForSeconds(time);
        openingDoor = false;
        audioManager.StopSFX("DoorSlide");
    }
}
