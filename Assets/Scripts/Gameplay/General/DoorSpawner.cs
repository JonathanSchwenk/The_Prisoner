using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class DoorSpawner : MonoBehaviour
{

    private IObjectPooler objectPooler;

    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ServiceLocator.Resolve<IObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBehindDoor(string objectToSpawn) {
        go = objectPooler.SpawnFromPool(objectToSpawn, transform.position, Quaternion.identity);
    }

    public void DeactivateBehindDoor() {
        go.SetActive(false);
    }
}
