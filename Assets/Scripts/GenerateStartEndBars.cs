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
        if (GameObject.Find("Start_Bar(Clone)") == null)
        {
            StartCoroutine(GenerateBarsWithDelay(other));
        }
    }

    private IEnumerator GenerateBarsWithDelay(Collider other)
    {
        // wait for 1 second
        yield return new WaitForSeconds(.25f);

        GameObject start_bar = Instantiate(prefab_Start_Bar);
        GameObject end_bar = Instantiate(prefab_End_Bar);
        Debug.Log("Generating + Positioning Start and End bars...");

        if (other.transform.position.z < 0)
        {
            start_bar.transform.position = left_bar_location_xyz;
            end_bar.transform.position = right_bar_location_xyz;
        }
        else if (other.transform.position.z > 0)
        {
            start_bar.transform.position = right_bar_location_xyz;
            end_bar.transform.position = left_bar_location_xyz;
        }
    }
}
