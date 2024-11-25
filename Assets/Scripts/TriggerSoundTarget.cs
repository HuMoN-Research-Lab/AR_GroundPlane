using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundTarget : MonoBehaviour
{
    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip soundTrigger;
  
    public float dwell_time_threshold; // how many frames we need to detect before we trigger the sound

    private float dwell_time_tracker; // tracks the number of frames that the object has been inside of the collider

    private bool something_is_in_this_trigger = false;

    private bool sound_has_played = false;

    private string name_of_the_thing_in_this_trigger;

    /// OnTriggerStay is called almost every frame; https://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
    void OnTriggerStay(Collider colliding_object)
    {
        if(!something_is_in_this_trigger)
        {
            something_is_in_this_trigger = true;
            name_of_the_thing_in_this_trigger = colliding_object.name;

        }

        if(colliding_object.name == name_of_the_thing_in_this_trigger)
        {
            dwell_time_tracker += Time.deltaTime; // add TIME to tracker for every frame
            
        }

        if(dwell_time_tracker > dwell_time_threshold)
        {
            if(!sound_has_played)
            {
                // play the collect sound (at the same position as the target, 100% volume)
                AudioSource.PlayClipAtPoint(soundTrigger, transform.position, 1.0f);
                sound_has_played = true;
                System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
                int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
                //Debug.Log("Triggered Tar:" + colliding_object.transform.position.ToString("F4") + " at Epoch Time " + cur_time.ToString());
            }
        }
        
    }
}

