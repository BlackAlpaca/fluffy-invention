using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonTapped : MonoBehaviour {

    public AudioClip tuut;
    private AudioSource source;


    public void OnButtonDown(Hand fromHand)
        {
            PressedMethod();
            fromHand.TriggerHapticPulse(1000);
        }

        public void OnButtonUp(Hand fromHand)
        {
           
        }

        private void PressedMethod()
        {
            Debug.Log("Pressed");
            source = GetComponent<AudioSource>();
            source.PlayOneShot(tuut, 100);
        }
}
