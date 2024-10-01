using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEndBar : MonoBehaviour
{
    public GameObject prefab_End_Bar; // Prefab to instantiate the End Bar
    public Vector3 end_bar_location_xyz; // Position to place the End Bar

    private bool endBarGenerated = false; // Ensure End Bar is generated only once

    // Called when any object exits the genesis_box
    void OnTriggerExit(Collider other)
    {
        // Check if the End Bar has not been generated yet and the genesis_box's z position is less than -3
        if (!endBarGenerated && transform.position.z < -3f)
        {
            // Instantiate the End Bar at the designated position
            GameObject end_bar = Instantiate(prefab_End_Bar);
            end_bar.transform.position = end_bar_location_xyz;
            Debug.Log("End Bar generated and positioned at: " + end_bar_location_xyz);

            // Mark that the End Bar has been generated to prevent duplicates
            endBarGenerated = true;

            // Optional: Disable the collider on this genesis_box to prevent further triggers
            GetComponent<Collider>().enabled = false;

            // Destroy the genesis_box GameObject after generating the End Bar
            Destroy(gameObject);
            Debug.Log("Genesis Box destroyed.");
        }
    }
}
