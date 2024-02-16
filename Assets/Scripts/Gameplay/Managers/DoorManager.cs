using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour, IDoorManager {
    public GameObject selectedDoor { get; set; }
    public string enemyToSpawn { get; set; }

    // need public for canOpenDoor so you can only press one door

    [SerializeField] private Camera mainDoorCamera;
    [SerializeField] private Camera leftDoorCamera;
    [SerializeField] private Camera rightDoorCamera;
    [SerializeField] private Camera centerDoorCamera;

    [SerializeField] private GameObject[] doorList;
    [SerializeField] private Player_Weapons weaponDictionary;

    private string[] listOfEnemies = new string[] { "HumansDoor", "ElfDoor", "GoblinsDoor", "UndeadDoor" };

    private bool hasSpawned = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) // Checks for a left mouse button click
        {
            Ray ray = mainDoorCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                selectedDoor = hit.collider.gameObject;
                // print(selectedDoor);
                if (selectedDoor.GetComponent<DoorController>() != null) {
                    ActivateDoorSpawners();
                    
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

    private void ActivateDoorSpawners() {

        if (hasSpawned == false) {
            // Pick what to spawn
            bool spawnWeapon = Random.Range(0f, 1f) < 0.75f; // 75% chance

            if (spawnWeapon) {
                // Spawn one weapon and two enemies
                int weaponDoorIndex = Random.Range(0, 3); // Choose which door gets the weapon

                for (int i = 0; i < 3; i++)
                    if (i == weaponDoorIndex) {
                        Weapon weapon = GetRandomEntryFromDictionary(weaponDictionary.playerWeaponsDict).Value;
                        doorList[i].GetComponent<DoorSpawner>().SpawnBehindDoor(weapon.name);
                        print("Spawned " + weapon.name + " behind door " + i);
                    } else {
                        // Spawn enemy behind this door
                        doorList[i].GetComponent<DoorSpawner>().SpawnBehindDoor(listOfEnemies[Random.Range(0, listOfEnemies.Length)]);
                        print("Spawned " + listOfEnemies[Random.Range(0, listOfEnemies.Length)] + " behind door " + i);
                    }
            } else {
                // Spawn enemies behind all doors
                for (int i = 0; i < 3; i++) {
                    doorList[i].GetComponent<DoorSpawner>().SpawnBehindDoor(listOfEnemies[Random.Range(0, listOfEnemies.Length)]);
                }
            }
        }

        hasSpawned = true;

    }
    private KeyValuePair<string, Weapon> GetRandomEntryFromDictionary(Dictionary<string, Weapon> dict) {
        List<KeyValuePair<string, Weapon>> entries = new List<KeyValuePair<string, Weapon>>(dict);
        int randomIndex = Random.Range(0, entries.Count);
        return entries[randomIndex];
    }
}
