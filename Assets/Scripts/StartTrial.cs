using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial : MonoBehaviour
{
    public LoadTerrain terrain_bool;
    
    //public Session session;
    void OnTriggerEnter(Collider other)
    {
        if(!Session.instance.InTrial)
        {
            if(other.transform.position.z < 0)
            {
                // establish which direction the terrain is "going" 
                terrain_bool.is_mirrored = false;
                Session.instance.BeginNextTrial();
            }
            else if(other.transform.position.z > 0)
            {
                terrain_bool.is_mirrored = true;
                Session.instance.BeginNextTrial();
            }
        }
    }
    
}
