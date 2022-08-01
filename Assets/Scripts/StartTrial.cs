using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial : MonoBehaviour
{
    public LoadTerrain terrain_bool;
    public Session session;
    void OnTriggerEnter()
    {
        if(!session.InTrial)
        {
            terrain_bool.is_mirrored = false;
            session.BeginNextTrial();
        }
    }
    
}
