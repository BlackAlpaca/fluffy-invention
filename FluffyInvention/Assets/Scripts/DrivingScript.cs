using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;


[System.Serializable]
public class DrivingScript_Controller : object
{
    public WheelCollider leftWheel;
    public GameObject leftWheelMesh;
    public WheelCollider rightWheel;
    public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
    public bool reverseTurn;
}

public class DrivingScript : MonoBehaviour
{

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<DrivingScript_Controller> truck_Infos;
    public LinearMapping _LinearMapping;
    public GameObject steeringWheel;

    public void VisualizeWheel(DrivingScript_Controller wheelPair)
    {
        Quaternion rot;
        Vector3 pos;
        wheelPair.leftWheel.GetWorldPose(out pos, out rot);
        wheelPair.leftWheelMesh.transform.position = pos;
        wheelPair.leftWheelMesh.transform.rotation = rot;
        wheelPair.rightWheel.GetWorldPose(out pos, out rot);
        wheelPair.rightWheelMesh.transform.position = pos;
        wheelPair.rightWheelMesh.transform.rotation = rot;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            SceneManager.LoadScene("MainScene");
        }

        float lmValue = _LinearMapping.value;

        if (lmValue > 0.5f)
        {
            lmValue = lmValue - 0.5f;
        }
        else
        {
            lmValue = - (1.0f - lmValue);
        }


        Debug.Log(_LinearMapping.value + " - LMval: " + lmValue);

        float motor = maxMotorTorque * lmValue;
        float steering = maxSteeringAngle * gameObject.transform.localRotation.y;
        float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));
        if (brakeTorque > 0.001)
        {
            brakeTorque = maxMotorTorque;
            motor = 0;
        }
        else
        {
            brakeTorque = 0;
        }

        foreach (DrivingScript_Controller truck_Info in truck_Infos)
        {
            if (truck_Info.steering == true)
            {
                truck_Info.rightWheel.steerAngle = truck_Info.leftWheel.steerAngle = ((truck_Info.reverseTurn) ? -1 : 1) * steering;
            }

            if (truck_Info.motor == true)
            {
                truck_Info.leftWheel.motorTorque = motor;
                truck_Info.rightWheel.motorTorque = motor;
            }

            truck_Info.leftWheel.brakeTorque = brakeTorque;
            truck_Info.rightWheel.brakeTorque = brakeTorque;

            VisualizeWheel(truck_Info);
        }

    }


}