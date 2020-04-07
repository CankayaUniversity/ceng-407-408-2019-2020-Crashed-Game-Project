// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class CarControl : MonoBehaviour {
//     public float MotorForce, SteerForce, BrakeForce;
//     public WheelCollider FL_L_Wheel, FL_R_Wheel, RE_L_Wheel, RE_R_Wheel;

//     void Start() {

//     }

//     void Update() {
//         float v = MotorForce * Input.GetAxis("Vertical");
//         float h = SteerForce * Input.GetAxis("Horizontal");

//         RE_L_Wheel.motorTorque = v;
//         RE_R_Wheel.motorTorque = v;

//         FL_L_Wheel.steerAngle = h;
//         FL_R_Wheel.steerAngle = h;

//         if (Input.GetKey(KeyCode.Space)) {
//             RE_L_Wheel.brakeTorque = BrakeForce;
//             RE_R_Wheel.brakeTorque = BrakeForce;
//         }
        
//         if (Input.GetKeyUp(KeyCode.Space)) {
//             RE_L_Wheel.brakeTorque = 0;
//             RE_R_Wheel.brakeTorque = 0;
//         }

//         if (Input.GetAxis("Vertical") == 0) {
//             RE_L_Wheel.brakeTorque = BrakeForce;
//             RE_R_Wheel.brakeTorque = BrakeForce;
//         }

//         else {
//             RE_L_Wheel.brakeTorque = 0;
//             RE_R_Wheel.brakeTorque = 0;
//         }
//     }
// }