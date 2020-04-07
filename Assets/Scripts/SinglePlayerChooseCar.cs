using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerChooseCar : MonoBehaviour {
    public GameObject p1Up, p1Down;
    // Car Icons
    public GameObject mustangIcon1, cyberTruckIcon1;
    // Colors for cars
    public GameObject colorP1;
    public Color[] colors = new Color[6] {Color.blue, Color.red, Color.green, Color.yellow, Color.cyan, Color.magenta};
    // Appearence array indicates that if current color is taken by any car currently
    bool isPlayer1Up;
    int p1i;
    /*-- GLOBAL VARIABLES ----------------------------------------------*/
    // After selection use these GLOBAL VARIABLES to create Car
    public static Color selectedColor;
    public static bool isMustang;
    /*------------------------------------------------------------------*/
    void OnEnable() {
        // Debug.Log("Script was enabled");
        colorP1.GetComponent<Image>().color = Color.blue;
        p1i = 0;
        isPlayer1Up = true;
        p1Up.SetActive(true);
        p1Down.SetActive(false);
        ConnectPlayers.currentNumberOfPlayer = 1;
    }
    void Update() {
        // Debug.Log("Sinle PLayer Size: " + ConnectPlayers.currentNumberOfPlayer);
        // UPDATE GLOBAL VARIABLES-------------------------
        selectedColor = colorP1.GetComponent<Image>().color;
        if (mustangIcon1.active) {
            isMustang = true;
        } else {
            isMustang = false;
        }
        // Debug.Log("MustangActive: " + isMustang);
        // Debug.Log("SelectedColor: " + selectedColor);
        //--------------------------------------------------
        // Chooses Car Type for Player
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
                for (int i = p1i - 1; i >= 0; i--) {
                    colorP1.GetComponent<Image>().color = colors[i];
                    p1i = i;
                    break;
                }
            }
            if (Input.GetKeyDown("d")) {
                // Start from last location
                for (int i = p1i + 1; i < 6; i++) {
                    colorP1.GetComponent<Image>().color = colors[i];
                    p1i = i;
                    break;
                }
            }
        }
    }
}