using System.Collections;
using System.Collections.Generic;
using Dorkbots.ServiceLocatorTools;
using UnityEngine;

public class DoorManager : MonoBehaviour, IDoorManager {
    public GameObject selectedDoor { get; set; }
    public string chosenObject { get; set; }
    public bool canOpenDoor { get; set; }
    public int selectedDoorIndex { get; set; }
    public string[] doorContents { get; set; }


    // need public for canOpenDoor so you can only press one door

    [SerializeField] private Camera mainDoorCamera;
    [SerializeField] private Camera leftDoorCamera;
    [SerializeField] private Camera rightDoorCamera;
    [SerializeField] private Camera centerDoorCamera;

    [SerializeField] private GameObject[] doorList;
    [SerializeField] private GameObject[] doorParentList;
    [SerializeField] private Player_Weapons weaponDictionary;

    [SerializeField] private GameObject preOpenDoors;
    [SerializeField] private GameObject openFirstDoor;
    [SerializeField] private GameObject openSecondDoor;

    private string[] listOfEnemies = new string[] { "HumansDoor", "ElfDoor", "GoblinsDoor", "UndeadDoor" };

    private bool hasSpawned = false;
    private int numTimesOpened = 0;

    private IGameManager gameManager;
    private ISpawnManager spawnManager;
    private IStatsManager statsManager;

    // Start is called before the first frame update
    void Start() {
        canOpenDoor = true;
        doorContents = new string[3];

        gameManager = ServiceLocator.Resolve<IGameManager>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) // Checks for a left mouse button click
        {
            Ray ray = mainDoorCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (canOpenDoor) {
                if (Physics.Raycast(ray, out hit)) {
                    selectedDoor = hit.collider.gameObject;

                    // print(selectedDoor);
                    if (selectedDoor.GetComponent<DoorController>() != null) {
                        ActivateDoorSpawners();
                        
                        selectedDoor.GetComponent<DoorController>().openingDoor = true;
                        selectedDoor.GetComponent<DoorController>().StopDoors();
                        selectedDoor.GetComponent<DoorController>().hasMoved = true;

                        numTimesOpened++;

                        if (selectedDoor.name == "LeftDoor") {
                            leftDoorCamera.gameObject.SetActive(true);
                            mainDoorCamera.gameObject.SetActive(false);
                            selectedDoorIndex = 0;
                        } else if (selectedDoor.name == "RightDoor") {
                            rightDoorCamera.gameObject.SetActive(true);
                            mainDoorCamera.gameObject.SetActive(false);
                            selectedDoorIndex = 2;
                        } else if (selectedDoor.name == "CenterDoor") {
                            centerDoorCamera.gameObject.SetActive(true);
                            mainDoorCamera.gameObject.SetActive(false);
                            selectedDoorIndex = 1;
                        }

                        canOpenDoor = false;

                        ChangeDoorUi();
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

                        doorContents[i] = weapon.name;
                    } else {
                        // Spawn enemy behind this door
                        string randomEnemy = listOfEnemies[Random.Range(0, listOfEnemies.Length)];
                        doorList[i].GetComponent<DoorSpawner>().SpawnBehindDoor(randomEnemy);

                        doorContents[i] = randomEnemy;
                    }
            } else {
                // Spawn enemies behind all doors
                for (int i = 0; i < 3; i++) {
                    string randomEnemy = listOfEnemies[Random.Range(0, listOfEnemies.Length)];
                    doorList[i].GetComponent<DoorSpawner>().SpawnBehindDoor(randomEnemy);

                    doorContents[i] = randomEnemy;
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

    private void ChangeDoorUi() {
        if (numTimesOpened == 1) {
            preOpenDoors.SetActive(false);
            openFirstDoor.SetActive(true);
        } else if (numTimesOpened == 2) {
            preOpenDoors.SetActive(false);
            openSecondDoor.SetActive(true);
        }
    }

     public void SelectButton() {
        chosenObject = doorContents[selectedDoorIndex];
        print(chosenObject);
        canOpenDoor = true;

        // Reset doors canvas
        preOpenDoors.SetActive(true);
        openFirstDoor.SetActive(false);
        openSecondDoor.SetActive(false);

        // Reset cameras
        leftDoorCamera.gameObject.SetActive(false);
        rightDoorCamera.gameObject.SetActive(false);
        centerDoorCamera.gameObject.SetActive(false);
        mainDoorCamera.gameObject.SetActive(true);

        numTimesOpened = 0;

        // Need to reset doors to be shut and despawn the enemies
        foreach (GameObject door in doorParentList) {
            if (door.GetComponent<DoorController>().hasMoved == true) {
                door.GetComponent<DoorController>().CloseDoors();
                door.GetComponent<DoorController>().openingDoor = false;
                door.GetComponent<DoorController>().hasMoved = false;
            }
        }

        // Resets enemies
        foreach (GameObject door in doorList) {
            door.GetComponent<DoorSpawner>().DeactivateBehindDoor();
        }
        hasSpawned = false;

        // Tell the game manager to update the game state
        gameManager.UpdateGameState(GameState.Playing);

        // Change enemiesToSpawn in spawnManager to chosenObject
        if (chosenObject == "HumansDoor")
            spawnManager.enemyToSpawn = "Humans";
        else if (chosenObject == "ElfDoor")
            spawnManager.enemyToSpawn = "Elves";
        else if (chosenObject == "GoblinsDoor")
            spawnManager.enemyToSpawn = "Goblins";
        else if (chosenObject == "UndeadDoor")
            spawnManager.enemyToSpawn = "Undead";
        else {
            statsManager.playerUnlockedWeapons.Add(weaponDictionary.playerWeaponsDict[chosenObject].name, weaponDictionary.playerWeaponsDict[chosenObject]);
        }

    }

    // Choose again button
    public void ChooseAgainButton() {
        canOpenDoor = true;

        // Reset doors canvas
        preOpenDoors.SetActive(true);
        openFirstDoor.SetActive(false);
        openSecondDoor.SetActive(false);

        // reset cameras
        leftDoorCamera.gameObject.SetActive(false);
        rightDoorCamera.gameObject.SetActive(false);
        centerDoorCamera.gameObject.SetActive(false);
        mainDoorCamera.gameObject.SetActive(true);
    }
}
