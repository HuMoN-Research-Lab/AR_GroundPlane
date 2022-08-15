using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial : MonoBehaviour
{
    public LoadTerrain LoadTerrainScript; // attach LoadTerrain Script to gameobject
    
    //public Session session;
    void OnTriggerEnter(Collider other)
    {  
        Debug.Log("Session start collider triggered");
        if(!Session.instance.InTrial)
        {
            Debug.Log("Not in session, check terrain mirror and begin next trial");
            if(other.transform.position.z < 0)
            {
                // establish which direction the terrain is "going" 
                LoadTerrainScript.is_mirrored = false;

                Session.instance.BeginNextTrial();
            }
            else if(other.transform.position.z > 0)
            {
                LoadTerrainScript.is_mirrored = true;

                Session.instance.BeginNextTrial();
            }
        }
    }
    
}
