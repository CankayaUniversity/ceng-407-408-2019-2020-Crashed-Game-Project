using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour {
    public int CountdownTime;
    public TextMeshProUGUI CountdownDisplay;
    public GameObject controllerToDisable;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart() {
        // DISABLE CONTROLLERS
        CreateCars.CreateCarsEnabled = false;
        while (CountdownTime > 0) {
            CountdownDisplay.text = CountdownTime.ToString();
            yield return new WaitForSeconds(1f);
            CountdownTime--;
        }
        CountdownDisplay.text = "GO!";
        // ENABLE CONTROLLERS
        controllerToDisable.SetActive(true);
        yield return new WaitForSeconds(1f);
        CountdownDisplay.enabled = false;
        CreateCars.CreateCarsEnabled = true;
    }
}
