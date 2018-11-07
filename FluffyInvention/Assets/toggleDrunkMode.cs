using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class toggleDrunkMode : MonoBehaviour
{

    private bool IsOnDrunkMode = true;

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.K))
	    {
	        IsOnDrunkMode = !IsOnDrunkMode;
	       
        }

	    var postprocessingBehaviour = gameObject.GetComponent<PostProcessingBehaviour>();
        postprocessingBehaviour.enabled = IsOnDrunkMode ? true : false;
	    





	}
}
