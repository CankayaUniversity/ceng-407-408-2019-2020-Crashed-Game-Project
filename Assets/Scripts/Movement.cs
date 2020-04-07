using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float moveSpeed, speed, speed1;
    void start () {
        moveSpeed = 30;
        speed = 180.0f;
        speed1 = -180.0f;
    }
    void FixedUpdate() {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetKey("d")) transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("a")) transform.Rotate(Vector3.up * speed1 * Time.deltaTime);
    }
}