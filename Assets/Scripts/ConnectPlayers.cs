using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConnectPlayers : MonoBehaviour {
    public GameObject player1, connectPlayer1;
    public GameObject player2, connectPlayer2;
    public GameObject player3, connectPlayer3;
    public GameObject player4, connectPlayer4;
    public GameObject nextButton;
    // Actives/Deactives related players (Global)
    public static bool isActived1 = false, isActived2 = false;
    public static bool isActived3 = false, isActived4 = false;
    public static int currentNumberOfPlayer;
    // Start is called before the first frame update
    void OnEnable() {
        currentNumberOfPlayer = 0; // MAY HAVE SOME PROBLEMS!
        isActived1 = isActived2 = isActived3 = isActived4 = false;
        connectPlayer1.SetActive(true);
        connectPlayer2.SetActive(true);
        connectPlayer3.SetActive(true);
        connectPlayer4.SetActive(true);
    }

    void OnDisable() {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        connectPlayer1.SetActive(false);
        connectPlayer2.SetActive(false);
        connectPlayer3.SetActive(false);
        connectPlayer4.SetActive(false);
    }
    
    // Update is called once per frame
    void Update() {
        // Debug.Log("Players Size: " + currentNumberOfPlayer);
        // Actives/Deactives Player 1
        // Input.GetKey("w") -> continuously gets input!
        if (Input.GetKeyDown("w")) {
            // Debug.Log("Testing Log");
            player1.SetActive(!isActived1);
            connectPlayer1.SetActive(isActived1);
            isActived1 = !isActived1; // Current player status
            if (isActived1) {
                currentNumberOfPlayer++;
            } else {
                currentNumberOfPlayer--;
            }
        }
        
        // Actives Player 2
        if (Input.GetKeyDown("u")) {
            player2.SetActive(!isActived2);
            connectPlayer2.SetActive(isActived2);
            isActived2 = !isActived2;
            if (isActived2) {
                currentNumberOfPlayer++;
            } else {
                currentNumberOfPlayer--;
            }
        }

        // Actives Player 3
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            player3.SetActive(!isActived3);
            connectPlayer3.SetActive(isActived3);
            isActived3 = !isActived3;
            if (isActived3) {
                currentNumberOfPlayer++;
            } else {
                currentNumberOfPlayer--;
            }
        }

        // Actives Player 4
        if (Input.GetKeyDown("[8]")) {
            player4.SetActive(!isActived4);
            connectPlayer4.SetActive(isActived4);
            isActived4 = !isActived4;
            if (isActived4) {
                currentNumberOfPlayer++;
            } else {
                currentNumberOfPlayer--;
            }
        }

        // Check if there are at least two players
        if (currentNumberOfPlayer >= 2) {
            nextButton.SetActive(true);
        } else {
            nextButton.SetActive(false);
        }
    }
}