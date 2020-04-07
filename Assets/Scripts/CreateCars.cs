using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCars : MonoBehaviour {
    // GLOBAL VARIABLE ENABLES/DISABLES THIS SCRIPT
    public static bool CreateCarsEnabled = true;
    /*-------------------------------------------*/
    public GameObject carPrefab;
    public GameObject[] clones = new GameObject[4] {null, null, null, null}; // For Multiplayer
    public GameObject clone; // For Singleplayer
    public GameObject cameraFollowedMultipleCarObject; // Object to be folloed by camera in Multiplayer
    public GameObject cameraFollowedSingleCarObject; // Object to be folloed by camera in Singleplayer
    // Start is called before the first frame update
    // public static int ConnectPlayers.currentNumberOfPlayer = ConnectPlayers.currentNumberOfPlayer;
    // public bool[] playersActive = new bool[] {ConnectPlayers.isActived1, ConnectPlayers.isActived2, ConnectPlayers.isActived3, ConnectPlayers.isActived4};
    // public Color[] playerColors = new Color[] {ChooseCarTypeAndColor.selectedColor1, ChooseCarTypeAndColor.selectedColor2,
    //                                     ChooseCarTypeAndColor.selectedColor3, ChooseCarTypeAndColor.selectedColor4};
    public Color[] playerColors;
    public bool[] playersActive;
    public bool playerActiveSingle = false;
    public void OnEnable() {
        playersActive = new bool[] {ConnectPlayers.isActived1, ConnectPlayers.isActived2, ConnectPlayers.isActived3, ConnectPlayers.isActived4};
        playerColors = new Color[] {ChooseCarTypeAndColor.selectedColor1, ChooseCarTypeAndColor.selectedColor2,
                                        ChooseCarTypeAndColor.selectedColor3, ChooseCarTypeAndColor.selectedColor4};
        // Debug.Log("Players SizeCreate: " + ConnectPlayers.currentNumberOfPlayer);
        // Multiplayer
        if (ConnectPlayers.currentNumberOfPlayer >= 2) {
            // Debug.Log("Multiplayer Enabled!");
            // Creates cars with selected color and number in the Multiplayer
            if (ConnectPlayers.currentNumberOfPlayer == 2) {
                int x = -3;
                for (int i = 0; i < 4; i++) {
                    // Debug.Log("PlayerActive " + i + ":" + playersActive[i]);
                    if (playersActive[i] == true) { // If player is active
                        clones[i] = Instantiate(carPrefab, new Vector3(x, 2, -10), Quaternion.identity);
                        clones[i].name = "car" + i; // Rename new car
                        clones[i].transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate
                        Material mat = clones[i].transform.Find("Cube").GetComponent<Renderer>().material;
                        mat.color = playerColors[i];
                        x = 3;
                    }
                }
            }
            else if (ConnectPlayers.currentNumberOfPlayer == 3) {
                int x = -3;
                for (int i = 0; i < 4; i++) {
                    if (playersActive[i] == true) { // İf player is active
                        clones[i] = Instantiate(carPrefab, new Vector3(x, 2, -10), Quaternion.identity);
                        clones[i].name = "car" + i; // Rename new car
                        clones[i].transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate
                        Material mat = clones[i].transform.Find("Cube").GetComponent<Renderer>().material;
                        mat.color = playerColors[i];
                        x += 3;
                    }
                }
            }
            else if (ConnectPlayers.currentNumberOfPlayer == 4) {
                float x = -5.5f;
                for (int i = 0; i < 4; i++) {
                    if (playersActive[i] == true) { // İf player is active
                        clones[i] = Instantiate(carPrefab, new Vector3(x, 2, -10), Quaternion.identity);
                        clones[i].name = "car" + i; // Rename new car
                        clones[i].transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate
                        Material mat = clones[i].transform.Find("Cube").GetComponent<Renderer>().material;
                        mat.color = playerColors[i];
                        x += 3;
                    }
                }
            }
        } 
        // Singleplayer
        else {
            playerActiveSingle = true;
            // Creates a car with selected color in the Singleplayer
            // Debug.Log("Singleplayer Enabled!");
            clone = Instantiate(carPrefab, new Vector3(0, 2, -10), Quaternion.identity);
            clone.name = "car"; // Rename new car
            clone.transform.rotation = Quaternion.Euler(0, 90, 0);
            clone.transform.Find("Cube").GetComponent<Renderer>().sharedMaterial.color = SinglePlayerChooseCar.selectedColor;
        }
    }

    /*-----------------------------CAR MOVEMENT CONTROL--------------------------*/
    // SINGLEPLAYER
    public float Speed = 0; // Initial Speed
    public float MaxSpeed = 0.5f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed = 0.3f; // This is the maximum reverse speed
    public float Acceleration = 0.3f; // How fast will object reach a maximum speed
    public float SlowDownRatio = 0.006f; // How fast will object slows down
    public float Deceleration = 0.1f; // How fast will object reach a speed of 0
    
    // MULTIPLAYER - Player 1
    public float Speed1 = 0; // Initial Speed
    public float MaxSpeed1 = 0.5f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed1 = 0.3f; // This is the maximum reverse speed
    public float Acceleration1 = 0.3f; // How fast will object reach a maximum speed
    public float SlowDownRatio1 = 0.006f; // How fast will object slows down
    public float Deceleration1 = 0.1f; // How fast will object reach a speed of 0

    // MULTIPLAYER - Player 2
    public float Speed2 = 0; // Initial Speed
    public float MaxSpeed2 = 0.5f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed2 = 0.3f; // This is the maximum reverse speed
    public float Acceleration2 = 0.3f; // How fast will object reach a maximum speed
    public float SlowDownRatio2 = 0.006f; // How fast will object slows down
    public float Deceleration2 = 0.1f; // How fast will object reach a speed of 0

    // MULTIPLAYER - Player 3
    public float Speed3 = 0; // Initial Speed
    public float MaxSpeed3 = 0.5f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed3 = 0.3f; // This is the maximum reverse speed
    public float Acceleration3 = 0.3f; // How fast will object reach a maximum speed
    public float SlowDownRatio3 = 0.006f; // How fast will object slows down
    public float Deceleration3 = 0.1f; // How fast will object reach a speed of 0

    // MULTIPLAYER - Player 4
    public float Speed4 = 0; // Initial Speed
    public float MaxSpeed4 = 0.5f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed4 = 0.3f; // This is the maximum reverse speed
    public float Acceleration4 = 0.3f; // How fast will object reach a maximum speed
    public float SlowDownRatio4 = 0.006f; // How fast will object slows down
    public float Deceleration4 = 0.1f; // How fast will object reach a speed of 0
    /*---------------------------------------------------------------------------*/
    // Multiplayer Positions
    public Vector3 positionSum = Vector3.zero;
    public Vector3 centerPosition = Vector3.zero;
    // Singleplayer Position
    public Vector3 centerPositionSingle = Vector3.zero;
    // Update is called once per frame
    void Update() {
        // If Multiplayer is Enabled
        if (ConnectPlayers.currentNumberOfPlayer > 1) {
            // For each car object
            foreach (GameObject currentCar in clones) {
                if (currentCar) {
                    positionSum += currentCar.transform.position;
                }
            }
            // Updates center point continuously
            centerPosition = positionSum / ConnectPlayers.currentNumberOfPlayer;
            // Debug.Log("Multiplayer Center Point: " + centerPosition);
            positionSum = Vector3.zero;
            // Updates the objects position
            cameraFollowedMultipleCarObject.transform.position = centerPosition;
        }
        // If Singleplayer is Enabled
        else {
            // Updates center point continuously
            centerPositionSingle = clone.transform.position;
            // Debug.Log("Singleplayer Center Point: " + centerPositionSingle);
            // Object to be folloed by camera in Singleplayer
            // Updates the objects position
            cameraFollowedSingleCarObject.transform.position = centerPositionSingle;
        }
    }

    // Update is called once per frame SMOOTHLY
    void FixedUpdate() { // FixedUpdate
        if (CreateCarsEnabled) {
            // Controls SINGLEPLAYER
            if (playerActiveSingle) {
                if (Input.GetKey("w") && (Speed < MaxSpeed)) {
                    Speed = Speed + (Acceleration * Time.deltaTime);
                    // clone.transform.Translate(-Speed, 0f, 0f);
                }
                if (!Input.GetKey("w") && (Speed > 0)) {
                    Speed -= SlowDownRatio;
                }
                if (Input.GetKey("s") && (Speed > -ReverseMaxSpeed)) {
                    Speed = Speed - (Deceleration * Time.deltaTime);
                    // clone.transform.Translate(Speed, 0f, 0f);
                }
                if (!Input.GetKey("s") && (Speed < 0)) {
                    Speed += SlowDownRatio;
                }
                if (Input.GetKey("a")) {
                    clone.transform.Rotate(Vector3.up * -120 * Time.deltaTime);
                }
                if (Input.GetKey("d")) {
                    clone.transform.Rotate(Vector3.up * 120 * Time.deltaTime);
                }
                clone.transform.Translate(-Speed, 0f, 0f);
                // transform.position.x = transform.position.x + Speed * Time.deltaTime;
            }
            
            // Controls MULTIPLAYER Player 1
            if (playersActive[0]) {
                if (Input.GetKey("w") && (Speed1 < MaxSpeed1)) {
                    Speed1 = Speed1 + (Acceleration1 * Time.deltaTime);
                    // clones[0].transform.Translate(-Speed, 0f, 0f);
                }
                if (!Input.GetKey("w") && (Speed1 > 0)) {
                    Speed1 -= SlowDownRatio1;
                }
                if (Input.GetKey("s") && (Speed1 > -ReverseMaxSpeed1)) {
                    Speed1 = Speed1 - (Deceleration1 * Time.deltaTime);
                    // clones[0].transform.Translate(Speed, 0f, 0f);
                }
                if (!Input.GetKey("s") && (Speed1 < 0)) {
                    Speed1 += SlowDownRatio1;
                }
                if (Input.GetKey("a")) {
                    clones[0].transform.Rotate(Vector3.up * -120 * Time.deltaTime);
                }
                if (Input.GetKey("d")) {
                    clones[0].transform.Rotate(Vector3.up * 120 * Time.deltaTime);
                }
                clones[0].transform.Translate(-Speed1, 0f, 0f);
                // transform.position.x = transform.position.x + Speed * Time.deltaTime;
            }

            // Controls MULTIPLAYER Player 2
            if (playersActive[1]) {
                if (Input.GetKey("u") && (Speed2 < MaxSpeed2)) {
                    Speed2 = Speed2 + (Acceleration2 * Time.deltaTime);
                    // clones[1].transform.Translate(-Speed, 0f, 0f);
                }
                if (!Input.GetKey("u") && (Speed2 > 0)) {
                    Speed2 -= SlowDownRatio2;
                }
                if (Input.GetKey("j") && (Speed2 > -ReverseMaxSpeed2)) {
                    Speed2 = Speed2 - (Deceleration2 * Time.deltaTime);
                    // clones[1].transform.Translate(Speed, 0f, 0f);
                }
                if (!Input.GetKey("j") && (Speed2 < 0)) {
                    Speed2 += SlowDownRatio2;
                }
                if (Input.GetKey("h")) {
                    clones[1].transform.Rotate(Vector3.up * -120 * Time.deltaTime);
                }
                if (Input.GetKey("k")) {
                    clones[1].transform.Rotate(Vector3.up * 120 * Time.deltaTime);
                }
                clones[1].transform.Translate(-Speed2, 0f, 0f);
                // transform.position.x = transform.position.x + Speed * Time.deltaTime;
            }
            
            // Controls MULTIPLAYER Player 3
            if (playersActive[2]) {
                if (Input.GetKey(KeyCode.UpArrow) && (Speed3 < MaxSpeed3)) {
                    Speed3 = Speed3 + (Acceleration3 * Time.deltaTime);
                    // clones[].transform.Translate(-Speed, 0f, 0f);
                }
                if (!Input.GetKey(KeyCode.UpArrow) && (Speed3 > 0)) {
                    Speed3 -= SlowDownRatio3;
                }
                if (Input.GetKey(KeyCode.DownArrow) && (Speed3 > -ReverseMaxSpeed3)) {
                    Speed3 = Speed3 - (Deceleration3 * Time.deltaTime);
                    // clones[2].transform.Translate(Speed, 0f, 0f);
                }
                if (!Input.GetKey(KeyCode.DownArrow) && (Speed3 < 0)) {
                    Speed3 += SlowDownRatio3;
                }
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    clones[2].transform.Rotate(Vector3.up * -120 * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.RightArrow)) {
                    clones[2].transform.Rotate(Vector3.up * 120 * Time.deltaTime);
                }
                clones[2].transform.Translate(-Speed3, 0f, 0f);
                // transform.position.x = transform.position.x + Speed * Time.deltaTime;
            }

            // Controls MULTIPLAYER Player 4
            if (playersActive[3]) {
                if (Input.GetKey("[8]") && (Speed4 < MaxSpeed4)) {
                    Speed4 = Speed4 + (Acceleration4 * Time.deltaTime);
                    // clones[3].transform.Translate(-Speed, 0f, 0f);
                }
                if (!Input.GetKey("[8]") && (Speed4 > 0)) {
                    Speed4 -= SlowDownRatio4;
                }
                if (Input.GetKey("[5]") && (Speed4 > -ReverseMaxSpeed4)) {
                    Speed4 = Speed4 - (Deceleration4 * Time.deltaTime);
                    // clones[3].transform.Translate(Speed, 0f, 0f);
                }
                if (!Input.GetKey("[5]") && (Speed < 0)) {
                    Speed4 += SlowDownRatio4;
                }
                if (Input.GetKey("[4]")) {
                    clones[3].transform.Rotate(Vector3.up * -120 * Time.deltaTime);
                }
                if (Input.GetKey("[6]")) {
                    clones[3].transform.Rotate(Vector3.up * 120 * Time.deltaTime);
                }
                clones[3].transform.Translate(-Speed4, 0f, 0f);
                // transform.position.x = transform.position.x + Speed * Time.deltaTime;
            }


            // // Controls Player 2
            // if (Input.GetKeyDown("u")) {
            // }
            // if (Input.GetKeyDown("j")) {
            // }
            // if (Input.GetKeyDown("h")) {
            // }
            // if (Input.GetKeyDown("k")) {
            // }

            // // Controls Player 3
            // if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // }
            // if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // }
            // if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // }
            // if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // }

            // // Controls Player 4
            // if (Input.GetKeyDown("[8]")) {
            // }
            // if (Input.GetKeyDown("[5]")) {
            // }
            // if (Input.GetKeyDown("[4]")) {
            // }
            // if (Input.GetKeyDown("[6]")) {
            // }
        }
    }
}