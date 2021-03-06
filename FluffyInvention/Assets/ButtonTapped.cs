﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonTapped : MonoBehaviour {

    public AudioSource tuut;


    public void OnButtonDown(Hand fromHand)
        {
            PressedMethod();
            fromHand.TriggerHapticPulse(1000);
        }

        public void OnButtonUp(Hand fromHand)
        {
            if (tuut.isPlaying)
            {
                tuut.Stop();
                Debug.Log("StoppedPlaying");
        }
        }

        private void PressedMethod()
        {
            Debug.Log("Pressed");
            tuut.Play();
        }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PressedMethod();
        }
    }
}
