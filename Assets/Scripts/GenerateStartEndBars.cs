using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GenerateStartEndBars : MonoBehaviour
{
    public GameObject prefab_Start_Bar;
    public GameObject prefab_End_Bar;

    public Vector3 left_bar_location_xyz;
    public Vector3 right_bar_location_xyz;

    private bool barsGenerated = false;

    // Called when the participant's foot exits the box
    void OnTriggerExit(Collider other)
    {
        // Check if the bars have not been generated already
        if (!barsGenerated && GameObject.Find("Start_Bar(Clone)") == null)
        {
            // Instantiate the Start and End bars
            GameObject start_bar = Instantiate(prefab_Start_Bar);
            GameObject end_bar = Instantiate(prefab_End_Bar);
            Debug.Log("Generating and positioning Start and End bars upon trigger exit...");

            // Position the Start and End bars based on participant's position relative to the box
            if (other.transform.position.z < 0)
            {
                // If participant starts on the left, position start bar on the left and end bar on the right
                start_bar.transform.position = left_bar_location_xyz;
                end_bar.transform.position = right_bar_location_xyz;
            }
            else if (other.transform.position.z > 0)
            {
                // If participant starts on the right, position start bar on the right and end bar on the left
                start_bar.transform.position = right_bar_location_xyz;
                end_bar.transform.position = left_bar_location_xyz;
            }

            // Mark that the bars have been generated
            barsGenerated = true;
        }
    }
}
