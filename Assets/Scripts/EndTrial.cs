using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class EndTrial : MonoBehaviour
{
    public float delayInSeconds = 1f; // Set the delay time in seconds

    void OnTriggerExit()
    {
        // Start a coroutine to handle the delay before ending the trial
        StartCoroutine(DelayedEndTrial());
    }

    // Coroutine that handles the delay before ending the trial
    IEnumerator DelayedEndTrial()
    {
        if (Session.instance.InTrial) // Check if the session is in a trial
        {
            Debug.Log("Trigger exited. Waiting before ending the trial...");

            // Wait for the specified delay time
            yield return new WaitForSeconds(delayInSeconds);

            // End the current trial
            Debug.Log("Ending Trial after delay");
            Session.instance.EndCurrentTrial();

            // Find all terrain features and destroy them, excluding Start_Bar
            GameObject[] terrain_features = GameObject.FindGameObjectsWithTag("Terrain_Feature");
            foreach (GameObject tf in terrain_features)
            {
                // Exclude the Start_Bar from being destroyed
                if (tf.name != "Start_Bar(Clone)") 
                {
                    Debug.Log($"Destroying: {tf.name}");
                    Destroy(tf);
                }
                else
                {
                    Debug.Log($"Excluding: {tf.name} from destruction.");
                }
            }
        }
    }
}
