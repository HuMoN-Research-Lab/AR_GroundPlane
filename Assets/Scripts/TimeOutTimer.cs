using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class TimeOutTimer : MonoBehaviour
{

    public float time_out_threshold;
    public AudioClip sad_sound;
    private LoadTerrain loadTerrain;

    IEnumerator Countdown()
    {
        Debug.Log("Timer has started");
   
        yield return new WaitForSeconds(time_out_threshold);

        Debug.Log("Trial timed out :( ");

        // Destroy terrain features before restarting trial
        if (loadTerrain != null)
        {
            loadTerrain.ClearTerrainFeatures();
        }

        // Fetch the previous trial using GetPrevTrial
        var CurrentTrial = Session.instance.CurrentTrial;

        // If a previous trial exists, restart it
        if (CurrentTrial != null)
        {
            Debug.Log("Repeating Current Trial...");
        CurrentTrial.Begin();
        }
        else
        {
            Debug.Log("No Previous Trial to Repeat");
        }

        AudioSource.PlayClipAtPoint(sad_sound, transform.position, 1.0f);

    }
     void OnTriggerExit(Collider other)
    {
        // Remove the tag check to allow any object to trigger the countdown
        string this_session_string = Session.instance.CurrentTrial.settings.GetString("File");

        Debug.Log(this_session_string);

        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (!this_session_string.Equals("Calibration") & !this_session_string.Equals("Frisbee"))
        {
            StartCoroutine(Countdown());
        }
    }
}
