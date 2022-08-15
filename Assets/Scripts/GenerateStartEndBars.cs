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

    void OnTriggerEnter(Collider other)
    {
        if(GameObject.Find("Start_Bar(Clone)") == null)
        {
            GameObject start_bar = Instantiate(prefab_Start_Bar);
            GameObject end_bar = Instantiate(prefab_End_Bar);

            if(other.transform.position.z < 0)
            {
                // If participant starts on the left, have the start bar start on the left and the end bar on the right
                start_bar.transform.position = left_bar_location_xyz;
                end_bar.transform.position = right_bar_location_xyz;

            }
            else if(other.transform.position.z > 0)
            {
                // start bar on the *right*, end bar on the *left*
                start_bar.transform.position = right_bar_location_xyz;
                end_bar.transform.position = left_bar_location_xyz;
            }
        }
    }
}
