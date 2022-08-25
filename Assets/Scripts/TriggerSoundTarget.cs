using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundTarget : MonoBehaviour
{
    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip soundTrigger;
  
    public float dwell_time_threshold; // how many frames we need to detect before we trigger the sound

    private float dwell_time_tracker; // tracks the number of frames that the object has been inside of the collider


    /// OnTriggerStay is called almost every frame; https://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
    void OnTriggerStay(Collider other)
    {

        dwell_time_tracker += 1; // add TIME to tracker for every frame
        
        Debug.Log("dwell_time_tracker:" + dwell_time_tracker);
    

        if (dwell_time_tracker > dwell_time_threshold)
        {

            // play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(soundTrigger, transform.position, 1.0f);
            Debug.Log("Triggered Tar:" + other.transform.position.ToString("F4"));

            // co-routines might be an option here

        }
        
    }

    void OnTriggerExit()
    {

       dwell_time_tracker = 0;
         
        
    }
}

