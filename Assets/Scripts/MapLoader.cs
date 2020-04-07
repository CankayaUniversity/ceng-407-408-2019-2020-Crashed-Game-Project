using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
// Loads the selected map
public class MapLoader : MonoBehaviour {
    public GameObject map1, map2, playButton;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update() {
        // Check if there are at least two players
        if (map1.active || map2.active) {
            playButton.SetActive(true);
        } else {
            playButton.SetActive(false);
        }
    }

    // Runs selected map means "scene"
    public void PlaySelectedMap() {
        // Loads map_1 (Change scene name after!)
        if (map1.active) {
            SceneManager.LoadScene("Game");
        } 
        // Loads map_2 (Change scene name after!)
        else if (map2.active) {
            SceneManager.LoadScene("Game");
        }
    }
}