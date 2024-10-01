using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GenerateEndBarAndTerrain : MonoBehaviour
{
    public GameObject prefab_End_Bar; // We'll generate the End Bar from here
    public Vector3 left_bar_location_xyz;
    public Vector3 right_bar_location_xyz;

    private bool endBarGenerated = false;

    // Called when the foot enters the Start Bar area
    void OnTriggerEnter(Collider other)
    {
        if (!endBarGenerated) // Check if the End Bar has already been generated
        {
            // Instantiate the End Bar based on participant's position
            GameObject end_bar = Instantiate(prefab_End_Bar);
            Debug.Log("Generating + Positioning End bar...");

            if (other.transform.position.z < 0)
            {
                // Start bar on the left, end bar on the right
                end_bar.transform.position = right_bar_location_xyz;
            }
            else if (other.transform.position.z > 0)
            {
                // Start bar on the right, end bar on the left
                end_bar.transform.position = left_bar_location_xyz;
            }

            // Mark that the End Bar has been generated
            endBarGenerated = true;
        }
    }
}
