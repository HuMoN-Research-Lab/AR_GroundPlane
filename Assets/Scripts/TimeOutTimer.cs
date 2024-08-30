using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class TimeOutTimer : MonoBehaviour
{

    public float time_out_threshold;
    public AudioClip sad_sound;


    IEnumerator Countdown()
    {
        Debug.Log("Timer has started");
   
        yield return new WaitForSeconds(time_out_threshold);

        Debug.Log("Trial timed out :( ");
        Session.instance.EndCurrentTrial();
        AudioSource.PlayClipAtPoint(sad_sound, transform.position, 1.0f);

        GameObject[] terrain_features;
        terrain_features = GameObject.FindGameObjectsWithTag("Terrain_Feature");

        foreach(GameObject tf in terrain_features)
        {
            Destroy(tf);
        }

        

    }

    // void OnTriggerEnter()
    // {
    //     string this_session_string = Session.instance.CurrentTrial.settings.GetString("File");

    //     Debug.Log(this_session_string);

    //     gameObject.GetComponent<BoxCollider>().enabled = false;

    //     if(!this_session_string.Equals("Calibration") & !this_session_string.Equals("Frisbee"))
    //     {
    //         StartCoroutine(Countdown());
    //     }
    // }
     void OnTriggerExit(Collider other)
    {
        // Remove the tag check to allow any object to trigger the countdown
        string this_session_string = Session.instance.CurrentTrial.settings.GetString("File");

        Debug.Log(this_session_string);

        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (!this_session_string.Equals("Calibration") && !this_session_string.Equals("Frisbee"))
        {
            StartCoroutine(Countdown());
        }
    }
}
