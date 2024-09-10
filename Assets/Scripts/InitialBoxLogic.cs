using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialBoxLogic : MonoBehaviour
{
    public GameObject prefab_Start_Bar;
    public Vector3 left_bar_location_xyz;
    public Vector3 right_bar_location_xyz;

    private bool startBarGenerated = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the start bar has already been generated
        if (!startBarGenerated)
        {
            // Instantiate the start bar only the first time
            GameObject start_bar = Instantiate(prefab_Start_Bar);
            Debug.Log("Generating and positioning Start bar...");

            // Positioning logic based on foot position
            if (other.transform.position.z < 0)
            {
                start_bar.transform.position = left_bar_location_xyz;
            }
            else if (other.transform.position.z > 0)
            {
                start_bar.transform.position = right_bar_location_xyz;
            }

            // Mark that the start bar has been generated
            startBarGenerated = true;
        }
    }

    // Handle when the foot leaves the initial box
    void OnTriggerExit(Collider other)
    {
        if (startBarGenerated)
        {
            // Disable or destroy the initial box after the foot exits
            Debug.Log("Foot exited the initial box. Destroying the box...");
            Destroy(gameObject, 0.1f); // This destroys the trigger box itself after 0.1 delay
        }
    }
}



