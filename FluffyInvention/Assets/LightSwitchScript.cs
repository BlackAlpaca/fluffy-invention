using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour {

    public Light spotLight1;
    public Light spotLight2;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            spotLight1.enabled = !spotLight1.enabled;
            spotLight2.enabled = !spotLight2.enabled;

        }
	}
}
