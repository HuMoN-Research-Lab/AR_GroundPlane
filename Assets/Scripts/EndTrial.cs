using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class EndTrial : MonoBehaviour
{
    public AudioClip trial_succeed_sound;
    
    void OnTriggerEnter()
    {
        if(Session.instance.InTrial) // I do not need to have a public session reference; I can simply use this Session.instance to access the current "session" of UXF
        {
            Debug.Log("Ending Trial");
    
            Session.instance.EndCurrentTrial();

            GameObject[] terrain_features;
            terrain_features = GameObject.FindGameObjectsWithTag("Terrain_Feature");

            foreach(GameObject tf in terrain_features)
            {
                Destroy(tf);
            }

        }
    }
    
}