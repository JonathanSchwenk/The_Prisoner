using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public bool openingDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

    IEnumerator MoveDoors(float time) {
        yield return new WaitForSeconds(time);
        openingDoor = false;
    }
}
