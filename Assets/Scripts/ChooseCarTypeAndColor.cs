using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Class for Selection of Cars & Color in Multiplayer
public class ChooseCarTypeAndColor : MonoBehaviour {
    // Selection SubUIs for each players
    public GameObject playerSelection1, playerSelection2;
    public GameObject playerSelection3, playerSelection4;
    // Used for Up/Down feature in UI for each player
    bool isPlayer1Up, isPlayer2Up, isPlayer3Up, isPlayer4Up;
    public GameObject p1Up, p1Down;
    public GameObject p2Up, p2Down;
    public GameObject p3Up, p3Down;
    public GameObject p4Up, p4Down;
    // Car Icons
    public GameObject mustangIcon1, cyberTruckIcon1;
    public GameObject mustangIcon2, cyberTruckIcon2;
    public GameObject mustangIcon3, cyberTruckIcon3;
    public GameObject mustangIcon4, cyberTruckIcon4;
    // Colors for cars
    public GameObject colorP1, colorP2, colorP3, colorP4;
    public Color[] colors;
    // Appearence array indicates that if current color is taken by any car currently
    public bool[] isColorTaken;
    // Actives/Deactives related players (Global)
    // public static bool isActived1 = false, isActived2 = false;
    // public static bool isActived3 = false, isActived4 = false;
    int p1i, p2i, p3i, p4i;
    // Update is called once per frame
    // void OnDisable() {
    //     // Debug.Log("Script was disabled");
    // }
    /*-- GLOBAL VARIABLES ----------------------------------------------*/
    // After selection use these GLOBAL VARIABLES to create Cars
    public static Color selectedColor1, selectedColor2, selectedColor3, selectedColor4;
    public static bool isMustang1, isMustang2, isMustang3, isMustang4;
    /*------------------------------------------------------------------*/
    void OnEnable() {
        // Debug.Log("Script was enabled");
        p1i = 0;
        p2i = 1;
        p3i = 2;
        p4i = 3;
        isColorTaken = new bool[6] {false, false, false, false, false, false};
        colors = new Color[6] {Color.blue, Color.red, Color.green, Color.yellow, Color.cyan, Color.magenta};
        isPlayer1Up = true;
        isPlayer2Up = true;
        isPlayer3Up = true;
        isPlayer4Up = true;
        p1Up.SetActive(true);
        p1Down.SetActive(false);
        p2Up.SetActive(true);
        p2Down.SetActive(false);
        p3Up.SetActive(true);
        p3Down.SetActive(false);
        p4Up.SetActive(true);
        p4Down.SetActive(false);
        // Update player status
        // Player 1
        if (ConnectPlayers.isActived1 == true) {
            playerSelection1.SetActive(true);
            colorP1.GetComponent<Image>().color = colors[p1i];
            isColorTaken[p1i] = true;
        } 
        else {
            playerSelection1.SetActive(false);
            isColorTaken[p1i] = false;
        }
        // Player 2
        if (ConnectPlayers.isActived2 == true) {
            playerSelection2.SetActive(true);
            colorP2.GetComponent<Image>().color = colors[p2i];
            isColorTaken[p2i] = true;
        } 
        else {
            playerSelection2.SetActive(false);
            isColorTaken[p2i] = false;
        }
        // Player 3
        if (ConnectPlayers.isActived3 == true) {
            playerSelection3.SetActive(true);
            colorP3.GetComponent<Image>().color = colors[p3i];
            isColorTaken[p3i] = true;
        } 
        else {
            playerSelection3.SetActive(false);
            isColorTaken[p3i] = false;
        }
        // Player 4
        if (ConnectPlayers.isActived4 == true) {
            playerSelection4.SetActive(true);
            colorP4.GetComponent<Image>().color = colors[p4i];
            isColorTaken[p4i] = true;
        } 
        else {
            playerSelection4.SetActive(false);
            isColorTaken[p4i] = false;
        }
    }
    void Update() {
        // UPDATE GLOBAL VARIABLES-------------------------
        selectedColor1 = colorP1.GetComponent<Image>().color;
        isMustang1 = mustangIcon1.active;
        selectedColor2 = colorP2.GetComponent<Image>().color;
        isMustang2 = mustangIcon2.active;
        selectedColor3 = colorP3.GetComponent<Image>().color;
        isMustang3 = mustangIcon3.active;
        selectedColor4 = colorP4.GetComponent<Image>().color;
        isMustang4 = mustangIcon4.active;
        // Debug.Log(isMustang1 + " " + selectedColor1);
        // Debug.Log(isMustang2 + " " + selectedColor2);
        // Debug.Log(isMustang3 + " " + selectedColor3);
        // Debug.Log(isMustang4 + " " + selectedColor4);
        //--------------------------------------------------
        // Debug.Log("p1: " + p1i + " p2: " + p2i + " p3: " + p3i + " p4: " + p4i);
        // Debug.Log("p1: " + ConnectPlayers.isActived1 + 
        // " p2: " + ConnectPlayers.isActived2 + 
        // " p3: " + ConnectPlayers.isActived3 +
        // " p4: " + ConnectPlayers.isActived4);
        // Chooses Car Type for Player 1
        // Input.GetKey("w") -> continuously gets input!
        if (Input.GetKeyDown("w")) {
            isPlayer1Up = true;
            p1Up.SetActive(true);
            p1Down.SetActive(false);
        }
        if (Input.GetKeyDown("s")) {
            isPlayer1Up = false;
            p1Up.SetActive(false);
            p1Down.SetActive(true);
        }
        if (isPlayer1Up) { // Up is active, can choose car
            if (Input.GetKeyDown("a")) {
                mustangIcon1.SetActive(true);
                cyberTruckIcon1.SetActive(false);
            }
            if (Input.GetKeyDown("d")) {
                mustangIcon1.SetActive(false);
                cyberTruckIcon1.SetActive(true);
            }
        } else { // Down is active, can choose color
            if (Input.GetKeyDown("a")) {
                // Start from last location
                for (int i = p1i; i >= 0; i--) {
                    // If next color is not taken, then take
                    if (isColorTaken[i] == false) {
                        colorP1.GetComponent<Image>().color = colors[i];
                        isColorTaken[p1i] = false;
                        isColorTaken[i] = true;
                        p1i = i;
                        break;
                    }
                }
            }
            if (Input.GetKeyDown("d")) {
                // Start from last location
                for (int i = p1i; i < 6; i++) {
                    // If next color is not taken, then take
                    if (isColorTaken[i] == false) {
                        colorP1.GetComponent<Image>().color = colors[i];
                        isColorTaken[p1i] = false;
                        isColorTaken[i] = true;
                        p1i = i;
                        break;
                    }
                }
            }
        }
        
        // Actives Player 2
        if (ConnectPlayers.isActived2 == true) {
            if (Input.GetKeyDown("u")) {
                isPlayer2Up = true;
                p2Up.SetActive(true);
                p2Down.SetActive(false);
            }
            if (Input.GetKeyDown("j")) {
                isPlayer2Up = false;
                p2Up.SetActive(false);
                p2Down.SetActive(true);
            }
            if (isPlayer2Up) { // Up is active
                if (Input.GetKeyDown("h")) {
                    mustangIcon2.SetActive(true);
                    cyberTruckIcon2.SetActive(false);
                }
                if (Input.GetKeyDown("k")) {
                    mustangIcon2.SetActive(false);
                    cyberTruckIcon2.SetActive(true);
                }
            } else { // Down is active
                if (Input.GetKeyDown("h")) {
                    // Start from last location
                    for (int i = p2i; i >= 0; i--) {
                        // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP2.GetComponent<Image>().color = colors[i];
                            isColorTaken[p2i] = false;
                            isColorTaken[i] = true;
                            p2i = i;
                            break;
                        }
                    }
                }
                if (Input.GetKeyDown("k")) {
                    // Start from last location
                    for (int i = p2i; i < 6; i++) {
                         // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP2.GetComponent<Image>().color = colors[i];
                            isColorTaken[p2i] = false;
                            isColorTaken[i] = true;
                            p2i = i;
                            break;
                        }
                    }
                }
            }
        }

        // // Actives Player 3
        if (ConnectPlayers.isActived3 == true) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                isPlayer3Up = true;
                p3Up.SetActive(true);
                p3Down.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                isPlayer3Up = false;
                p3Up.SetActive(false);
                p3Down.SetActive(true);
            }
            if (isPlayer3Up) { // Up is active
                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    mustangIcon3.SetActive(true);
                    cyberTruckIcon3.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    mustangIcon3.SetActive(false);
                    cyberTruckIcon3.SetActive(true);
                }
            } else { // Down is active
                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    // Start from last location
                    for (int i = p3i; i >= 0; i--) {
                        // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP3.GetComponent<Image>().color = colors[i];
                            isColorTaken[p3i] = false;
                            isColorTaken[i] = true;
                            p3i = i;
                            break;
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    // Start from last location
                    for (int i = p3i; i < 6; i++) {
                         // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP3.GetComponent<Image>().color = colors[i];
                            isColorTaken[p3i] = false;
                            isColorTaken[i] = true;
                            p3i = i;
                            break;
                        }
                    }
                }
            }
        }

        // Actives Player 4
        if (ConnectPlayers.isActived4 == true) {
            if (Input.GetKeyDown("[8]")) {
                isPlayer4Up = true;
                p4Up.SetActive(true);
                p4Down.SetActive(false);
            }
            if (Input.GetKeyDown("[5]")) {
                isPlayer4Up = false;
                p4Up.SetActive(false);
                p4Down.SetActive(true);
            }
            if (isPlayer4Up) { // Up is active
                if (Input.GetKeyDown("[4]")) {
                    mustangIcon4.SetActive(true);
                    cyberTruckIcon4.SetActive(false);
                }
                if (Input.GetKeyDown("[6]")) {
                    mustangIcon4.SetActive(false);
                    cyberTruckIcon4.SetActive(true);
                }
            } else { // Down is active
                if (Input.GetKeyDown("[4]")) {
                    // Start from last location
                    for (int i = p4i; i >= 0; i--) {
                        // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP4.GetComponent<Image>().color = colors[i];
                            isColorTaken[p4i] = false;
                            isColorTaken[i] = true;
                            p4i = i;
                            break;
                        }
                    }
                }
                if (Input.GetKeyDown("[6]")) {
                    // Start from last location
                    for (int i = p4i; i < 6; i++) {
                         // If next color is not taken, then take
                        if (isColorTaken[i] == false) {
                            colorP4.GetComponent<Image>().color = colors[i];
                            isColorTaken[p4i] = false;
                            isColorTaken[i] = true;
                            p4i = i;
                            break;
                        }
                    }                    
                }
            }
        }
    }
}
