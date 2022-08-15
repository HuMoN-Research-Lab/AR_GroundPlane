using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class Timer : MonoBehaviour
{
    public float timer_length; // set the length of the trial
    public AudioClip trial_fail_sound;
    private bool trial_started;
    
    void OnTriggerEnter()
    {
        if(trial_started != true)
        {
            trial_started = true;
            Debug.Log("Trial Started!");
        }
    }

    public void Update()
    { 
        if(trial_started)
        {
            timer_length -= Time.deltaTime; // a current quirk of this system; the reason it stops counting is because this object (cloned object) gets deleted
        }

        if(timer_length < 0 & trial_started == true)
        {
            // if we got to this stage, that means we moved too slow
            Session.instance.CurrentTrial.result["outcome"] = "failure";
            Debug.Log("Trial Failed");

            // we will play a clip at position above origin, 100% volume
            AudioSource.PlayClipAtPoint(trial_fail_sound, new Vector3(0, 1.3f, 0), 1.0f);
            trial_started = false;
        }
    }

}
