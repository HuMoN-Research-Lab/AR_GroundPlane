using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class WaitingZoneController : MonoBehaviour
{
    public GameObject waitingZone; // Assign this in the Inspector
    public LoadTerrain terrainLoader; // Assign this in the Inspector if needed

    void Start()
    {
        // Ensure the waiting zone is visible initially
        waitingZone.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the participant is leaving the waiting zone and if a trial isn't already in progress
        if (!Session.instance.InTrial)
        {
            // Start the trial
            terrainLoader.is_mirrored = other.transform.position.z > 0;
            Session.instance.BeginNextTrial();
            Debug.Log("Trial started, direction mirrored: " + terrainLoader.is_mirrored);

            // Hide the waiting zone
            waitingZone.SetActive(false);
            Debug.Log("Waiting Zone is now hidden as the trial starts.");
        }
    }

    void OnTrialEnd()
    {
        // Optionally, make the waiting zone visible again after the trial ends if it needs to be reused
        waitingZone.SetActive(true);
        Debug.Log("Waiting Zone is visible again for the next trial.");
    }
}
