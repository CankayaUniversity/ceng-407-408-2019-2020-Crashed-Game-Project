using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour {
    // Changes the background color with dark color
    public void changeBackgroundColorDark() {
        Image img = GameObject.Find("Background").GetComponent<Image>();
        img.color = Color.gray;
    }

    // Changes the background color with white color
    public void changeBackgroundColorWhite() {
        Image img = GameObject.Find("Background").GetComponent<Image>();
        img.color = Color.white;
    }
}