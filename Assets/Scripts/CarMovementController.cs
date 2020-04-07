using UnityEngine;
using System.Collections;
using System.Collections.Generic;
     
public class CarMovementController : MonoBehaviour {
    // public float MotorForce, SteerForce, BrakeForce;
    public WheelCollider frontLeft, frontRight, backLeft, backRight;
    float motor = 0.0f, steering = 0.0f;
    /*-----------------------------CAR MOVEMENT CONTROL--------------------------*/
    public float Speed = 0; // Initial Speed
    public float MaxSpeed = 3000f; // This is the maximum speed that the object will get
    public float ReverseMaxSpeed = 1000f; // This is the maximum reverse speed
    public float Acceleration = 500f; // How fast will object reach a maximum speed
    public float SlowDownRatio = 300f; // How fast will object slows down
    public float Deceleration = 300f; // How fast will object reach a speed of 0
    /*---------------------------------------------------------------------------*/
    public void FixedUpdate() {
        if (Input.GetKey("w") && (Speed < MaxSpeed)) {
            Speed += (Acceleration * Time.deltaTime);
        }
        // if (!Input.GetKey("w") && (Speed > 0)) {
        //     Speed -= (Acceleration * Time.deltaTime);
        // }
        if (Input.GetKey("s") && (Speed > -ReverseMaxSpeed)) {
            Speed -= (Deceleration * Time.deltaTime);
        }
        // if (!Input.GetKey("s") && (Speed < 0)) {
        //     Speed += SlowDownRatio;
        // }
        // Smooth Rotating Front Wheels to Left
        if (Input.GetKey("a") && (steering > -50.0f)) {
            steering -= 7.0f;
        }
        if (!Input.GetKey("a")  && (steering < 0)) {
            steering += 7.0f;
        }
        // Smooth Rotating Front Wheels to Right
        if (Input.GetKey("d") && (steering < 50.0f)) {
            steering += 7.0f;
        }
        if (!Input.GetKey("d") && (steering > 0)) {
            steering -= 7.0f;
        }
        frontRight.steerAngle = steering;
        frontLeft.steerAngle = steering;
        backRight.motorTorque = Speed;
        backLeft.motorTorque = Speed;
    }
}