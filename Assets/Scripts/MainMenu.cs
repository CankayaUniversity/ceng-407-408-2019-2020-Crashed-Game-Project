using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    // Runs the game
    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    // Quits from game
    public void QuitGame() {
        Application.Quit();
    }
}