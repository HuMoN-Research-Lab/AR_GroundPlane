using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class StartTrial_Mirrored : MonoBehaviour
{
    public LoadTerrain terrain_bool;
    public Session session;
    void OnTriggerEnter()
    {   
        if(!session.InTrial)
        {
            terrain_bool.is_mirrored = true;
            session.BeginNextTrial();
        }
    }
    
}
