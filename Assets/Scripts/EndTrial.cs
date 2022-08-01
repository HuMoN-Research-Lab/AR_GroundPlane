using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class EndTrial : MonoBehaviour
{
    public Session session;
    void OnTriggerEnter()
    {
        if(session.InTrial)
        {
            Debug.Log("Ending Trial");
            session.EndCurrentTrial();

            GameObject[] terrain_features;
            terrain_features = GameObject.FindGameObjectsWithTag("Terrain_Feature");

            foreach(GameObject tf in terrain_features)
            {
                Destroy(tf);
            }
        }
    }
    
}