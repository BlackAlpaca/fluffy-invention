using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBackCollision : MonoBehaviour {
    private Rigidbody myRigidbody;

    void Start()
    {
        this.myRigidbody = this.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision entered");
        myRigidbody.AddForce(-transform.forward * 100);
        myRigidbody.useGravity = true;
    }
}
